using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 10f;
    public float jumpForce = 30f;
    public GameObject player, box;
    private bool hasJumped = false;
    private Rigidbody rb, rb2;
	// Use this for initialization
	void Start () {
        rb = player.GetComponent<Rigidbody>();
        rb2 = box.GetComponent<Rigidbody>();
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
            //player.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            rb.AddForce(Vector3.forward * Time.deltaTime * jumpForce);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            //player.transform.Translate(Vector3.left * Time.deltaTime * speed);
            rb.AddForce(Vector3.left * Time.deltaTime * jumpForce);
        }
        else if(Input.GetKey(KeyCode.S)) 
        {
            //player.transform.Translate(Vector3.back * Time.deltaTime * speed);
            rb.AddForce(Vector3.back * Time.deltaTime * jumpForce);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            //player.transform.Translate(Vector3.right* Time.deltaTime * speed);
            rb.AddForce(Vector3.right * Time.deltaTime * jumpForce);
        }

        if(Input.GetKeyDown(KeyCode.Space) && hasJumped == false)
        {
            //player.transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
            rb.AddForce(Vector3.up * jumpForce);
            //hasJumped = true;
        }
        
    }
    void OnMouseDown()
    {
        float force = 500f;
        rb2.AddForce(Vector3.back * force);
    }
}
