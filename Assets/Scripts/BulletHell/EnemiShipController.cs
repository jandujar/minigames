using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiShipController : MonoBehaviour
{

    public GameObject bullet;

    private RaycastHit detector;
    private Vector3 posInbullet;
    private Vector3 bulletDir;
    
    // Start is called before the first frame update
    void Start()
    {
        posInbullet.Set(transform.position.x, transform.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D coll = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 100);

        if(coll.collider.tag == "Player")
        {

           
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * coll.distance, Color.green);
            shoot(coll);

        }
        else
        {
            transform.Rotate(0, 0, 1);
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * coll.distance, Color.red);
        }

        
    }

    private void shoot(RaycastHit2D collid)
    {
        Quaternion zero = new Quaternion(0, 0, 0, 0);
        GameObject bullets = Instantiate(bullet, posInbullet, zero);
        Rigidbody2D bullrig = bullets.GetComponent<Rigidbody2D>();
        Vector2 bulldisp;
        Debug.Log("Posicion nave x: " + collid.collider.transform.position.x + " y: " + collid.collider.transform.position.y);
        if (collid.collider.transform.position.x > transform.position.x)
        {
            if(collid.collider.transform.position.y > transform.position.y)
            {
                Debug.Log("Disparo a");
                bulldisp = new Vector2(collid.collider.transform.position.x, collid.collider.transform.position.y);
            }
            else
            {
                Debug.Log("Disparo b");
                bulldisp = new Vector2(collid.collider.transform.position.x, -collid.collider.transform.position.y);
            }
            
        }
        else
        {
            if (collid.collider.transform.position.y > transform.position.y)
            {
                Debug.Log("Disparo c");
                bulldisp = new Vector2(-collid.collider.transform.position.x, collid.collider.transform.position.y);
            }
            else
            {
                Debug.Log("Disparo d");
                bulldisp = new Vector2(-collid.collider.transform.position.x, -collid.collider.transform.position.y);
            }


        }


      
        bullrig.AddForce(bulldisp, ForceMode2D.Impulse);
        
        //bullets.transform.Translate(Vector3.up*collid.distance);
    }
}
