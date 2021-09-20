using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour
{
    public bool joysticks;
    public bool keyboard;

    public VirtualJoyStickMain moveJoystick = null;
    public JoystickLook lookJoystick = null;
    public PlayerLook look;


    void Update()
    {

        if (joysticks)
        {
            moveJoystick.gameObject.SetActive(true);
            lookJoystick.gameObject.SetActive(true);
            look.useJoystick = true;
            look.useMouse = false;
            moveJoystick.syncJoyStickInput = !joysticks;
        }
        else
        {
            moveJoystick.gameObject.SetActive(false);
            lookJoystick.gameObject.SetActive(false);
            look.useJoystick = false;
            look.useMouse = true;
            moveJoystick.syncJoyStickInput = joysticks;
        }

    }
}
