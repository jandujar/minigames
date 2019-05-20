using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitation : MonoBehaviour
{


    [SerializeField] Transform CenterPoint;

    float speed = 30f;

    float InputAxisX, InputAxisY;

    public Vector3 EulerInitRotation;

    // Start is called before the first frame update
    void Start()
    {
        EulerInitRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {


        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON3))
        {

            InputAxisX = 0;
            InputAxisY = 0;
            InputAxisX = InputManager.Instance.GetAxisHorizontal();
            InputAxisY = InputManager.Instance.GetAxisVertical();
            transform.Rotate(Time.deltaTime * (InputAxisY*speed*-1), Time.deltaTime * (InputAxisX * speed*-1), 0);
        }

        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
            transform.rotation = Quaternion.Euler(EulerInitRotation); 

    }
}
