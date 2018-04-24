using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

    public float GetAxisHorizontal(){
        return Input.GetAxis("Horizontal");
    }

    public float GetAxisVertical(){
        return Input.GetAxis("Vertical");
    }
    public float GetAxisHorizontal2()
    {
        return Input.GetAxis("Mouse X");
    }

    public float GetAxisVertical2()
    {
        return Input.GetAxis("Mouse Y");
    }

    public enum MiniGameButtons{
        BUTTON1,
        BUTTON2,
        BUTTON3,
        BUTTON4,
        BUTTON5,
        BUTTON6
    }

    public bool GetButton(MiniGameButtons button){
        switch (button)
        {
            case MiniGameButtons.BUTTON1:
                return Input.GetButton("Fire1");
            case MiniGameButtons.BUTTON2:
                return Input.GetButton("Fire2");
            case MiniGameButtons.BUTTON3:
                return Input.GetButton("Fire3");
            case MiniGameButtons.BUTTON4:
                return Input.GetButton("Fire4");
            case MiniGameButtons.BUTTON5:
                return Input.GetButton("Fire5");
            case MiniGameButtons.BUTTON6:
                return Input.GetButton("Fire6");
            default:
                return false;
        }
    }

    public bool GetButtonDown(MiniGameButtons button){
        switch (button)
        {
            case MiniGameButtons.BUTTON1:
                return Input.GetButtonDown("Fire1");
            case MiniGameButtons.BUTTON2:
                return Input.GetButtonDown("Fire2");
            case MiniGameButtons.BUTTON3:
                return Input.GetButtonDown("Fire3");
            case MiniGameButtons.BUTTON4:
                return Input.GetButtonDown("Fire4");
            case MiniGameButtons.BUTTON5:
                return Input.GetButtonDown("Fire5");
            case MiniGameButtons.BUTTON6:
                return Input.GetButtonDown("Fire6");
            default:
                return false;
        }
    }

    public bool GetButtonUp(MiniGameButtons button){
        switch (button)
        {
            case MiniGameButtons.BUTTON1:
                return Input.GetButtonUp("Fire1");
            case MiniGameButtons.BUTTON2:
                return Input.GetButtonUp("Fire2");
            case MiniGameButtons.BUTTON3:
                return Input.GetButtonUp("Fire3");
            case MiniGameButtons.BUTTON4:
                return Input.GetButtonUp("Fire4");
            case MiniGameButtons.BUTTON5:
                return Input.GetButtonUp("Fire5");
            case MiniGameButtons.BUTTON6:
                return Input.GetButtonUp("Fire6");
            default:
                return false;
        }
    }
}
