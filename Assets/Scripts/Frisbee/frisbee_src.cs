using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbee_src : MonoBehaviour {

    float speedX = 10;
    float speedY = 18;
    float maxSpeedX = 30;
    float maxSpeedY = 36;
    float direction = 1;

    void Update () {
        Debug.Log(" frisbeePOS:" + transform.position);
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime * direction, 0);
        if (speedX >= maxSpeedX)
        {
            speedX = maxSpeedX;
        }
        if (transform.position.y >= 16)
        {
            direction = -1;
        }else if(transform.position.y <= -17)
        {
            direction = 1;
        }
        
	}
}
