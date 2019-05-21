using HyperJump;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallController : MonoBehaviour
{
    public float breakVelocity;
    RaycastHit hit;
    Ray ray ;
    public float jumpForce;
    Rigidbody rb;
    

    private void Start()
    {  
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (hit.distance <= 0.30f)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    
    
    //void OnCollisionEnter(Collision collision)
    //{
    //    try
    //    {
    //        if (collision.gameObject.GetComponentInParent<ObstacleController>().isEnemy)
    //        {
                
    //            if (rb.velocity.y > breakVelocity)
    //            {
    //                collision.gameObject.GetComponentInParent<ObstacleController>().Shoot();
    //                collision.gameObject.transform.parent.GetComponentInChildren<Collider>().enabled = false;
    //                Debug.Log("I tried");
    //            }
    //            else
    //            {
    //                Debug.Log("GameOver");
    //            }
    //        }
    //    }
    //    catch { }
       
    //}

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.GetComponentInParent<ObstacleController>().isEnemy)
            {

                if (rb.velocity.y > breakVelocity)
                {
                    other.gameObject.GetComponentInParent<ObstacleController>().Shoot();
                    other.gameObject.transform.parent.GetComponentInChildren<Collider>().enabled = false;
                    Debug.Log("I tried");
                }
                else
                {
                    Debug.Log("GameOver");
                }
            }
        }
        catch { }
    }
}
