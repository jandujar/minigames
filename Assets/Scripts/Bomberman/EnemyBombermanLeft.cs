using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombermanLeft : MonoBehaviour
{
    public float speed = 2;

    public int dir;
    
    void Start ()
    {
        dir = 1;
    }
    void Update()
    {   
        transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed * dir, transform.position.y, transform.position.z);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Walls"){
            dir*=-1;
        }
        if(other.gameObject.tag == "Breakable"){
            dir*=-1;
        }
        if(other.gameObject.tag == "Enemy"){
            dir*=-1;
        }
        if(other.gameObject.tag == "Player"){
            dir*=-1;
        }
        if(other.gameObject.tag == "Explosion"){
            Destroy(this.gameObject);
        }
    }

}
