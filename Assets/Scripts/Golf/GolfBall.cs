using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] GolfController controller;
    float timer;
    bool runTimer, inZone;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ResetForces();
    }

    private void Update()
    {
        if (runTimer)
        {
            timer += Time.deltaTime;
            if (timer >= 3 && Mathf.Abs(Vector3.Magnitude(rb.velocity)) > 0.1f)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                if (inZone)
                {
                    controller.NextRound();
                    Debug.Log("IN");
                }
                else
                {
                    controller.ResetPosition();
                }
                timer = 0;
                runTimer = false;
            }
        }
    }

    public void ResetForces()
    {
        
    }

    public void AddForce(float force, Vector3 direction)
    {
        runTimer = true;
        timer = 0;
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        rb.AddForce(force * direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            inZone = false;
        }
    }

}

