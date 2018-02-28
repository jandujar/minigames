using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbee_src : MonoBehaviour {

    float speedX = 30;
    float speedY = 30;
    float maxSpeedX = 30;
    float maxSpeedY = 36;
    float Ydirecction = 1;
    public float Xdirection = 1;
    public float topRange = 20;
    public float bottomRange = 0;

    void Update () {
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime * Ydirecction, 0);
        if (speedX >= maxSpeedX)
        {
            speedX = maxSpeedX;
        }
        if (transform.position.y >= 24)
        {
            Ydirecction = -1;
        }else if(transform.position.y <= 0)
        {
            Ydirecction = 1;
        }
        
	}
}
