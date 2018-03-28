using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumPlayer : BrumCar {

    public bool killed = false;
    private void Start()
    {
        run = false;
        acceleration = 0.5f;
        deceleration = 0.3f;
    }

    public override void OnTriggerEnterChild(Collider collider)
    {
        isColliding = true;
    }

    public override void OnTriggerStayChild(Collider collider)
    {
        isColliding = true;
    }

    public override void OnTriggerExitChild(Collider collider)
    {
        isColliding = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            run = true;
        }

        if (Input.GetKeyUp("space"))
        {
            run = false;
        }

        if (run)
        {
            speed += acceleration * Time.deltaTime;
        }

        speed -= deceleration * Time.deltaTime;
        if (speed < 0) speed = 0;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - speed);
    }

    public void Kill()
    {
        if (killed) return;
        killed = true;
        Debug.Log("Lose");
    }

    public void Win()
    {
        Debug.Log("Win");
    }
}
