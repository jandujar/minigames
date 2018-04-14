using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 15f;
    public float jumpForce = 5f;
    public float artificialGravity = 5f;
    public GameObject player;

    private Rigidbody rb;
    private bool isGrounded = true;
    void Start () {
        rb = player.GetComponent<Rigidbody>();
	}
	
	
	void Update () {
        CheckGrounded();
        SimpleMovement();
	}

    void CheckGrounded()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(rb.gameObject.transform.position, Vector3.down, out hit, 1.1f);
    }

    void SimpleMovement()
    {
        if (InputManager.Instance.GetAxisVertical() > 0)
        {
            rb.AddForce(Vector3.forward * Time.deltaTime * speed);
        }
        if(InputManager.Instance.GetAxisHorizontal() < 0)
        {
            rb.AddForce(Vector3.left * Time.deltaTime * speed);
        }
        if(InputManager.Instance.GetAxisVertical() < 0)
        {
            rb.AddForce(Vector3.back * Time.deltaTime * speed);
        }
        if(InputManager.Instance.GetAxisHorizontal() > 0)
        {
            rb.AddForce(Vector3.right* Time.deltaTime * speed);
        }

        if((InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) && isGrounded))
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;            
        }

        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * artificialGravity * Time.deltaTime);
        }
    }
}
