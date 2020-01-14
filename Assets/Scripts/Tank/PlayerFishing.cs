using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public int totalFish = 7;
    public int lives = 1;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish"){
            totalFish--;
            Debug.Log(totalFish);
        }
        if (collision.gameObject.tag == "EnemyShip"){
            lives--;
            Debug.Log(lives);
        }
    }
}
