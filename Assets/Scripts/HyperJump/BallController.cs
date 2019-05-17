using HyperJump;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallController : MonoBehaviour
{
    public float breakVelocity;

    private void Update()
    {
        Debug.Log(GetComponent<Rigidbody>().velocity);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.red)
        {
            Debug.Log("Game Over");
            if(GetComponent<Rigidbody>().velocity.z > breakVelocity)
            {
                collision.transform.parent.gameObject.GetComponent<ObstacleController>().Shoot();
            }
        }
    }
}
