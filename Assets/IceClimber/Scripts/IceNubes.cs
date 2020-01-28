using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNubes : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;

    [SerializeField]
    private float sentido = 1;

    // Update is called once per frame
    void Update()
    {
        if(sentido == 1){
            transform.Translate(Vector2.left*speed * Time.deltaTime);
            if(transform.position.x < -10f) transform.position = new Vector2(6f, transform.position.y);
        }
        else{
            transform.Translate(Vector2.right*speed * Time.deltaTime);
            if(transform.position.x > 10f) transform.position = new Vector2(-10f, transform.position.y);
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            other.transform.parent = this.transform; 
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            other.transform.parent = null;
        }
    }
}
