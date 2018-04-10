using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillaController : MonoBehaviour {
    public float speed;

    private Rigidbody rb;

    public float jumpForce = 2000f;	// Variable that determines the forward force

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);


        if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
        }
    }
}
