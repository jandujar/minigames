using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumCar : MonoBehaviour {

    public bool isColliding = false;
    public GameObject player;
    protected float speed = 0f;
    protected float maxSpeed = 0.07f;
    protected float acceleration = 0.1f;
    protected float deceleration = 0.09f;
    protected bool stop = false;
    protected bool run = true;

    void Update()
    {
        if (transform.name != "Player")
        {
            if (run && !stop)
            {
                if (transform.localPosition.z < player.transform.localPosition.z && Random.Range(0, 300) < 1)
                {
                    stop = true;
                }
                speed += acceleration * Time.deltaTime;
                if (speed > maxSpeed) { speed = maxSpeed; }
            }
            speed -= deceleration * Time.deltaTime;
            if (speed < 0)
            {
                speed = 0;
                if (stop)
                {
                    stop = false;
                }
            }
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - speed);
        }
    }

    public virtual void OnTriggerEnterChild(Collider collider ) {
        isColliding = true;
    }

    public virtual void OnTriggerStayChild(Collider collider)
    {
        isColliding = true;
        if (collider.gameObject.transform.name == "Player")
        {
            if (!collider.gameObject.GetComponent<BrumPlayer>().isColliding && !collider.gameObject.GetComponent<BrumPlayer>().killed)
            {
                run = true;
            }
            else {
                run = false;
            }
        }
        else
        {
            run = false;
        }
    }

    public virtual void OnTriggerExitChild(Collider collider)
    {
        isColliding = false;
        run = true;
    }

}
