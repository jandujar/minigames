using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTop : MonoBehaviour
{
    public float begin;

    public float dist = 5;

    public float speedUp = 5;

    public float speedDown = 2;

    public int dir;
    
    void Start ()
    {
        begin = transform.position.y;
        dir = 1;
    }
    void Update()
    {   
        if(transform.position.y > begin+dist){
            dir = -1;
        }
        else if(transform.position.y < begin-dist){
            dir = 1;
        }
        if(dir == -1){
            transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime * speedDown * dir, transform.position.z);
        }
        else if (dir == 1){
            transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime * speedUp * dir, transform.position.z);
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
