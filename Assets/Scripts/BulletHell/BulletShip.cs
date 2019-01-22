using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavierRibasDeTorres;

public class BulletShip : MonoBehaviour
{
    public float timelife;
    public float VelDisp;

    private GameObject GameMan;
    private GameObject Player;
    private BulletHell bullscript;

    // Start is called before the first frame update
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        GameMan = GameObject.Find("Game");
        bullscript = GameMan.GetComponent<BulletHell>();
        transform.GetComponent<Rigidbody2D>().velocity.Set(bullscript.getVelocityBullets(), bullscript.getVelocityBullets());
    }

    // Update is called once per frame
    void Update()
    {
        VelDisp = bullscript.getVelocityBullets();
        Vector2 bulldisp = new Vector2(Player.transform.position.x, Player.transform.position.y);

        //transform.position = Vector2.MoveTowards(transform.position, bulldisp, VelDisp * Time.deltaTime);
        
        Debug.Log(transform.GetComponent<Rigidbody2D>().velocity);

        timelife -= Time.deltaTime;
        if(timelife <= 0)
        {
            DestroyObject(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        DestroyObject(gameObject);
    }
    
}
