using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavierRibasDeTorres;

public class EnemiShipController : MonoBehaviour
{

    public GameObject bullet;
    public LayerMask mask;

    private RaycastHit detector;
    private Vector3 posInbullet;
    private Vector3 bulletDir;
    private GameObject GameMan;
    private GameObject Player;
    private BulletHell bullscript;

    // Start is called before the first frame update
    void Start()
    {
        posInbullet.Set(transform.position.x, transform.position.y, transform.position.z);
        Player = GameObject.FindGameObjectWithTag("Player");
        GameMan = GameObject.Find("Game");
        bullscript = GameMan.GetComponent<BulletHell>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D coll = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 100, mask);
        Debug.Log(coll.collider.tag);
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
        Rigidbody2D bulldisp = bullets.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bullets.GetComponent<PolygonCollider2D>(), transform.GetComponent<BoxCollider2D>());
        bulldisp.AddForce(transform.TransformDirection(Vector2.up) * 40, ForceMode2D.Impulse);
            
        //bullets.transform.Translate(Vector3.up*collid.distance);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "NaveShoot")
        {
            DestroyObject(gameObject);
        }
    }
}
