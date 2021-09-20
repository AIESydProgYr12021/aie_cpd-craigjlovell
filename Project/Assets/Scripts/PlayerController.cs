using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{    
    Canvas canvas = null;

    public Inv Inventory;
    public CharacterController controller;
    public VirtualJoyStickMain joystick;
    public JoystickLook lookstick;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public TextMeshProUGUI itemsText;
    public int items;

    float moveX;
    float moveZ;

    bool isKeyboard;
    bool isJoysticks;


    void Start()
    {
        items = 0;
        SetItemText();

        isJoysticks = FindObjectOfType<InputControls>().joysticks;
        isKeyboard = FindObjectOfType<InputControls>().keyboard;

    }

    void SetItemText()
    {
        itemsText.text = "Item: " + items.ToString();         
    }

    void Update()
    {
        isJoysticks = FindObjectOfType<InputControls>().joysticks;
        isKeyboard = FindObjectOfType<InputControls>().keyboard;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isJoysticks)
        {
            moveX = joystick.Direction.x;
            moveZ = joystick.Direction.y;
        }

        if (isKeyboard)
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(items == 3 && other.gameObject.CompareTag("car"))
        {
            Time.timeScale = 0;
            canvas = null;
            canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();
            canvas.enabled = false;
            canvas = GameObject.FindGameObjectWithTag("Gameover").GetComponent<Canvas>();
            canvas.enabled = true;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        InvItems item = hit.collider.GetComponent<InvItems>();
        if(item != null)
        {
            Inventory.AddItem(item);            
            SetItemText();
        }
    }
}
