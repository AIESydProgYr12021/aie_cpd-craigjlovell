using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public JoystickLook joystick;

    public float mouseSpeed = 100f;
    public float joySpeed = 5000f;

    public Transform playerBody;

    float xRot = 0f;

    public bool useMouse = false;
    public bool useKeyboard = false;
    public bool useJoystick = false;

    float mouseX = 0f;
    float mouseY = 0f;
    void Update()
    {        
        if (useMouse == true)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        }
        else if (useKeyboard == true)
        {
            mouseX = Input.GetAxis("HozX") * mouseSpeed * Time.deltaTime;
            mouseY = Input.GetAxis("VertY") * mouseSpeed * Time.deltaTime;
        }
        else if(useJoystick == true)
        {
            mouseX = joystick.Direction.x / joySpeed / Time.deltaTime;
            mouseY = joystick.Direction.y / joySpeed / Time.deltaTime;
        }

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}