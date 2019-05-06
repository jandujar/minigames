using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float oldyaw, oldpitch;

    public Camera CameraChild;


    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        yaw += speedH * InputManager.Instance.GetAxisHorizontal();
        pitch -= speedV * InputManager.Instance.GetAxisVertical();

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);


        if (pitch < -80) {

            pitch = -80;
        }
        else  if(pitch > 80)
        {
            pitch = 80;
        }

        
        CameraChild.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        


    }
}