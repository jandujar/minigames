using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 10f;
    public float jumpForce = 30f;
    public GameObject player;
    private bool hasJumped = false;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        SimpleMovement();
        //OnMouseDown();

    }
    void SimpleMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * Time.deltaTime * jumpForce);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * Time.deltaTime * jumpForce);
        }
        else if(Input.GetKey(KeyCode.S)) 
        {
            rb.AddForce(Vector3.back * Time.deltaTime * jumpForce);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(Vector3.right * Time.deltaTime * jumpForce);
        }

        if(Input.GetKeyDown(KeyCode.Space) && hasJumped == false)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }
}
