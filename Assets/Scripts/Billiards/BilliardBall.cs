using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardBall : MonoBehaviour {

    private BilliardPlayer Bp;
    private GameManager Gm;
    public bool VelocityLoose = false;


    private float force = 40;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, 0, 9.8f);
        Bp = GameObject.Find("Player").GetComponent<BilliardPlayer>();
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.x < 3.2 && GetComponent<Rigidbody>().velocity.x > -3.2) {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (VelocityLoose) {
            if (GetComponent<Rigidbody>().velocity.x == 0) {
                Gm.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Holes") {
            GameObject.Find("Background").GetComponent<Collider>().enabled = false;
            VelocityLoose = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            if (other.GetComponent<Renderer>().material.color == Color.blue)
            {
                StartCoroutine(EndGame(IMiniGame.MiniGameResult.WIN));
            }
            else {
                StartCoroutine(EndGame(IMiniGame.MiniGameResult.LOSE));
            }
        }
    }

    IEnumerator EndGame(IMiniGame.MiniGameResult result)
    {
        yield return new WaitForSecondsRealtime(3f);
        Gm.EndGame(result);
    }

    void OnCollisionEnter(Collision other)
    {
        // If the object we hit is the enemy
        if (other.gameObject.tag == "Finish")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = other.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force * Bp.Power);
            force -= 10;
            VelocityLoose = false;
            StartCoroutine(VLoose());
        }
    }

    IEnumerator VLoose()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        VelocityLoose = true;
    }
}
