using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShip : MonoBehaviour
{
    public float timelife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timelife -= Time.deltaTime;
        if(timelife <= 0)
        {
            DestroyObject(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.collider.tag);
        DestroyObject(gameObject);
    }

}
