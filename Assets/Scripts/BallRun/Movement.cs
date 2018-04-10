using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 15f;
    public float jumpForce = 5f;
    public GameObject player;

    private Rigidbody rb;
    private bool isGrounded = true;
    private int jumps = 0;
    private float vertical, horizontal;
    private float maxDistanceY = 8.2f;
    void Start () {
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        SimpleMovement();
	}
    void SimpleMovement()
    {
        if (InputManager.Instance.GetAxisVertical() > 0)//InputManager.Instance.GetAxisVertical(Input.GetAxis("Horizontal")))
        {
            rb.AddForce(Vector3.forward * Time.deltaTime * speed);
        }
        else if(InputManager.Instance.GetAxisHorizontal() < 0)//InputManager.Instance.GetAxisVertical(Input.GetAxis("Horizontal")))
        {
            rb.AddForce(Vector3.left * Time.deltaTime * speed);
        }
        else if(InputManager.Instance.GetAxisVertical() < 0)//InputManager.Instance.GetAxisHorizontal(Input.GetAxis("Vertical"))) 
        {
            rb.AddForce(Vector3.back * Time.deltaTime * speed);
        }
        else if(InputManager.Instance.GetAxisHorizontal() > 0)//InputManager.Instance.GetAxisHorizontal(Input.GetAxis("Vertical"))) 
        {
            rb.AddForce(Vector3.right* Time.deltaTime * speed);
        }

        if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1) || Input.GetKeyDown(KeyCode.Space) && isGrounded) //InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
        {
            //RAYCAST PARA COMPROBAR SI ESTA TOCANDO EL SUELO
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
            jumps += 1;
            if (jumps > 0)
            {
                isGrounded = false;
            }
                
            
        }
        isGrounded = true;
    }
}
