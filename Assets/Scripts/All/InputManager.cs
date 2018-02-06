﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

    public float GetAxisHorizontal(){
        return Input.GetAxis("Horizontal");
    }

    public float GetAxisVertical(){
        return Input.GetAxis("Vertical");
    }

    public enum MiniGameButtons{
        BUTTON1,
        BUTTON2,
        BUTTON3,
        BUTTON4
    }

    public bool GetButton(MiniGameButtons button){
        switch (button)
        {
            case MiniGameButtons.BUTTON1:
                return Input.GetButton("Fire1");
                break;
            case MiniGameButtons.BUTTON2:
                return Input.GetButton("Fire2");
                break;
            case MiniGameButtons.BUTTON3:
                return Input.GetButton("Fire3");
                break;
            case MiniGameButtons.BUTTON4:
                return Input.GetButton("Fire4");
                break;
            default:
                return false;
        }
    }

    public bool GetButtonDown(MiniGameButtons button){
        switch (button)
        {
            case MiniGameButtons.BUTTON1:
                return Input.GetButtonDown("Fire1");
                break;
            case MiniGameButtons.BUTTON2:
                return Input.GetButtonDown("Fire2");
                break;
            case MiniGameButtons.BUTTON3:
                return Input.GetButtonDown("Fire3");
                break;
            case MiniGameButtons.BUTTON4:
                return Input.GetButtonDown("Fire4");
                break;
            default:
                return false;
        }
    }

    public bool GetButtonUp(MiniGameButtons button){
        switch (button)
        {
            case MiniGameButtons.BUTTON1:
                return Input.GetButtonUp("Fire1");
                break;
            case MiniGameButtons.BUTTON2:
                return Input.GetButtonUp("Fire2");
                break;
            case MiniGameButtons.BUTTON3:
                return Input.GetButtonUp("Fire3");
                break;
            case MiniGameButtons.BUTTON4:
                return Input.GetButtonUp("Fire4");
                break;
            default:
                return false;
        }
    }
}
