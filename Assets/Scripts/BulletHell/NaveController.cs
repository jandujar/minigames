using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavierRibasDeTorres;

public class NaveController : MonoBehaviour
{
    public GameObject GameMan;
    public GameObject Shoot;

    private float direction;
    private float rotat;
    private BulletHell BullHellScript;

    // Start is called before the first frame update
    void Start()
    {
        BullHellScript = GameMan.GetComponent<BulletHell>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = InputManager.Instance.GetAxisVertical();
        rotat = InputManager.Instance.GetAxisHorizontal();

        

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(Shoot, transform.position, transform.rotation);
            Rigidbody2D bulletdisp = bullet.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(bullet.GetComponent<PolygonCollider2D>(), transform.GetComponent<PolygonCollider2D>());
            bulletdisp.AddForce(transform.TransformDirection(Vector2.up)*100, ForceMode2D.Impulse);

        }

        transform.Translate(0, direction, 0);
            
        if(rotat > 0)
        {
            transform.Rotate(0, 0, 1);
        }
        else if(rotat < 0)
        {
            transform.Rotate(0, 0, -1);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "BulletShipEnemy")
        {
            Debug.Log("Tocado");
            BullHellScript.Lose();
        }
        
    }
}
