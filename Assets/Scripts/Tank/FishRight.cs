using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRight : MonoBehaviour
{
    public float begin;

    public float dist = 5;

    public int dir;

    public float speed = 5;

    public int range = 1;

    private Transform target;

    public bool alive;

    public int hp;

    void Start()
    {   
        begin = transform.position.x;
        dir = 1;
    }

    void Update()
    {
        
        if(range != 1){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime * -1);
            dir *= -1;
            begin = transform.position.x;
        }
        else{
            if(transform.position.x > begin+dist){
                dir = -1;
            }
            else{
                if(transform.position.x < begin-dist){
                    dir = 1;
                }
            }
        transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed * dir, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            Vector3 Restart = new Vector3(19000f,0.5f,13000f);
            transform.position = Restart;
        }
    }

}

