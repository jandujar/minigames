using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEnemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    private float range;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer(){
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
    }
}
