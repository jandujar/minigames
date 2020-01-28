using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePaharo : MonoBehaviour
{

    [SerializeField]
    private float maxY = 0.5f;
    [SerializeField]
    private float minY = -2.5f;
    [SerializeField]
    private float speedXVar = 2.5f;
    private bool sentidoV = true;
    private bool sentidoX = true;

    private float speedX = 0.1f;
    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(0.8f, 4f);
        
        if(speedX <= 0.5f) sentidoX = true; else if(speedX > speedXVar) sentidoX = false;

        if(sentidoX) speedX = speedX+Time.deltaTime*speedXVar; else speedX = speedX+(-1*Time.deltaTime)*speedXVar;

        if(sentidoV){
            transform.Translate(new Vector2(-speedX, -rand) * Time.deltaTime);
            if(transform.position.x < -10f) transform.position = new Vector2(6f, transform.position.y);
        }
        else{
            transform.Translate(new Vector2(-speedX, rand) * Time.deltaTime);
            if(transform.position.x > 6f) transform.position = new Vector2(-10f, transform.position.y);
        }


        if(transform.position.y < minY) sentidoV = false; else if(transform.position.y > maxY) sentidoV = true;



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
