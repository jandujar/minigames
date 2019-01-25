using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavierRibasDeTorres;

public class NaveController : MonoBehaviour
{
    public GameObject GameMan;
    public GameObject Shoot;
    public GameObject Pointer;
    public AudioSource Explosion;
    
    private float horit;
    private float vert;
    private float shoot;
    private Vector3 dist;
    private float rot;
    private BulletHell BullHellScript;

    // Start is called before the first frame update
    void Start()
    {
        BullHellScript = GameMan.GetComponent<BulletHell>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horit = InputManager.Instance.GetAxisHorizontal();
        vert = InputManager.Instance.GetAxisVertical();


        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            GameObject bullet = Instantiate(Shoot, transform.position, transform.rotation);
            Rigidbody2D bulletdisp = bullet.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(bullet.GetComponent<PolygonCollider2D>(), transform.GetComponent<PolygonCollider2D>());
            bulletdisp.AddForce(transform.TransformDirection(Vector2.up)*100, ForceMode2D.Impulse);

        }

        if (horit > 0)
        {
            
            transform.Translate(1, 0, 0);
        }
        else if (horit < 0)
        {
            transform.Translate(-1, 0, 0);
        }
        else
        {
            transform.Translate(0, 0, 0);
        }
        
            
        if(vert > 0)
        {
            Debug.Log("vertical + 1");
            transform.Translate(0, 1, 0);
        }
        else if(vert < 0)
        {
            transform.Translate(0, -1, 0);
        }
        else
        {
            transform.Translate(0, 0, 0);
        }

        dist = Pointer.transform.position - transform.position;
        dist.Normalize();

        rot = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot - 90);
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "BulletShipEnemy")
        {
            Explosion.Play();
            
            BullHellScript.Lose();
        }
        
    }
}
