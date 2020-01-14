using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomberManEnd : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    Vector2 movement;

    bool lose = false;
    public Bomberman game;

    public GameManager gameManager;



    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        
    }
    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
            losing();
        }
    }

    public void losing () {

        Debug.Log("Losing");
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);

    }

    
}
