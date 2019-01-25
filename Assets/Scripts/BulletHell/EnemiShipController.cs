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
    private LineRenderer laservigilante;
    private Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        posInbullet.Set(transform.position.x, transform.position.y, transform.position.z);
        Player = GameObject.FindGameObjectWithTag("Player");
        GameMan = GameObject.Find("Game");
        bullscript = GameMan.GetComponent<BulletHell>();
        laservigilante = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction = transform.TransformDirection(Vector3.up);
        RaycastHit2D coll = Physics2D.Raycast(transform.position, Direction, 100, mask);

        if(coll.collider.tag == "Player")
        {
            laservigilante.SetPosition(0, transform.position);
            laservigilante.SetPosition(1, transform.position + coll.distance * Direction);
            laservigilante.startColor = Color.red;
            laservigilante.endColor = Color.red;
            
            shoot(coll);

        }
        else
        {
            laservigilante.SetPosition(0, transform.position);
            laservigilante.SetPosition(1, transform.position + 100 * Direction);
            laservigilante.startColor = Color.green;
            laservigilante.endColor = Color.green;

            transform.Rotate(0, 0, 1);
            
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
