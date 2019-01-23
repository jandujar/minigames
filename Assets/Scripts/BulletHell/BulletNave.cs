using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNave : MonoBehaviour
{
    public AudioSource BulletSoundHit;
    public AudioSource BulletSoundhoot;

    private float TimeDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
        TimeDestroy = 5;
        BulletSoundhoot.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeDestroy -= Time.deltaTime;
        if (TimeDestroy < 0)
        {
            DestroyObject(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "EnemyShip")
        {
           
            BulletSoundHit.Play();
        }
        DestroyObject(gameObject);
    }
}
