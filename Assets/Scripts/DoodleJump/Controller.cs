using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;


    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

    }
}
