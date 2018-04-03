using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 10f;
    public float jumpForce = 50f;
    public GameObject player;

    private Rigidbody rb;
    private bool isGrounded;
    /*private int jumps = 0;
    private bool doubleJump = false;
    private bool hasJumped = false;*/
    // Use this for initialization
    void Start () {
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        SimpleMovement();
	}
    void SimpleMovement()
    {
        if (Input.GetKey(KeyCode.W))//InputManager.Instance.GetAxisVertical(Input.GetAxis("Vertical")))
        {
            rb.AddForce(Vector3.forward * Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.A))//InputManager.Instance.GetAxisVertical(Input.GetAxis("Vertical")))
        {
            rb.AddForce(Vector3.left * Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.S))//InputManager.Instance.GetAxisHorizontal(Input.GetAxis("Horizontal"))) 
        {
            rb.AddForce(Vector3.back * Time.deltaTime * speed);
        }
        else if(Input.GetKey(KeyCode.D))//InputManager.Instance.GetAxisHorizontal(Input.GetAxis("Horizontal"))) 
        {
            rb.AddForce(Vector3.right* Time.deltaTime * speed);
        }

        if(Input.GetKeyDown(KeyCode.Space))//InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
        {
            //player.transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
