using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillaController : MonoBehaviour {
   
    private Rigidbody rb;
    public float speed;
    public float jumpForce = 2000f;	// Variable that determines the forward force

    private Vector3 moveDirection;
    public float gravity;
    public CharacterController characterController;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal * speed, 0,  moveVertical*speed);
        

        if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            moveDirection.y = jumpForce;
            rb.AddForce(moveDirection * speed);
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravity);
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
