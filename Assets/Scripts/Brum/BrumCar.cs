using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumCar : MonoBehaviour {

    public bool isColliding = false;
    float speed = 0f;
    float maxSpeed = 0.1f;
    float acceleration = 0.15f;
    float deceleration = 0.1f;
    bool stop = false;
    bool run = true;

    void Update()
    {
        if (run && !stop)
        {
            if (Random.Range(0, 100) < 1)
            {
                stop = true;
            }
            speed += acceleration * Time.deltaTime;
            if (speed > maxSpeed) { speed = maxSpeed; }
        }
        speed -= deceleration * Time.deltaTime;
        if (speed < 0) {
            speed = 0;
            if (stop)
            {
                stop = false;
            }
        }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - speed);
    }

    public virtual void OnTriggerEnterChild(Collider collider ) {
        isColliding = true;
    }

    public virtual void OnTriggerStayChild(Collider collider)
    {
        isColliding = true;
        if (!collider.gameObject.GetComponent<BrumCar>().isColliding)
        {
            run = true;
        }
    }

    public virtual void OnTriggerExitChild(Collider collider)
    {
        isColliding = false;
    }

}
