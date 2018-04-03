using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    [SerializeField]
    public float friction = 1;
    [SerializeField]
    public float rotationSpeed = 10;

    private float xDeg = 0;
    private float yDeg = 0;
    private Quaternion toRotation;

    void Update()
    {
        if (InputManager.Instance.GetAxisVertical() != 0 || InputManager.Instance.GetAxisHorizontal() != 0)
        {
            xDeg -= InputManager.Instance.GetAxisHorizontal() * friction;
            yDeg += InputManager.Instance.GetAxisVertical() * friction;
            toRotation = Quaternion.Euler(yDeg, xDeg, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }
        if (getAnyInput())
        {
            Debug.Log("CheckTreasure");
        }
    }

    private bool getAnyInput()
    {
        return (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) ||
                InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2) ||
                InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3) ||
                InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4));
    }
}