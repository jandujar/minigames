using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulledScript : MonoBehaviour
{
    private int hits = 2;
    void Update(){
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Walls"){
            hits--;
            if(hits <= 0){
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Bulled"){
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player"){
            //Debug.Log("MUERO");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }   
        if (collision.gameObject.tag == "Box"){
            Destroy(gameObject);
        }      
    }
}
