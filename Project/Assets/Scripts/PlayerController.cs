using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public player_health health;
    public CharacterController controller;
    public VirtualJoyStickMain joystick;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public TextMeshProUGUI itemsText;
    private int items;

    void Start()
    {
        items = 0;
        SetItemText();
    }
    void SetItemText()
    {
        itemsText.text = "Item: " + items.ToString();
        if (items >= 4)
        {

        }

    }
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = joystick.Direction.x;
        float y = joystick.Direction.y;

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            items = items + 1;
            SetItemText();
        }

        if(items == 2 && other.gameObject.CompareTag("car"))
        {
            SceneManager.LoadScene("Gameover");
        }

    }
}
