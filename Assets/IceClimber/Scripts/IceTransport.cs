using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTransport : MonoBehaviour
{

    private GameObject player;
    private bool movePlayer = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movePlayer){
            //player.transform.Translate(transform.position*(0.5f*Vector2.right));
            rb.AddForce(4.5f*Vector2.right, ForceMode2D.Force);
            Debug.Log(rb.velocity.x);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            movePlayer =true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            movePlayer =false;
        }
    }
}
