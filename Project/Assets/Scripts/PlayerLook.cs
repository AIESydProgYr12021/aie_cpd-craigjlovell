using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    VirtualJoyStickMain joystick;

    public float mouseSpeed = 100f;

    public Transform playerBody;

    float xRot = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;        
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}