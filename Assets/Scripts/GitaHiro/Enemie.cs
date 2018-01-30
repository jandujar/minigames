using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour {
    private float move;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposy = 5.9f;
    public Ball ball;

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x > 0)
        {
            if(ball.transform.position.y > transform.position.y)
            {
                move = 1.0f;
            }else if (ball.transform.position.y < transform.position.y)
            {
                move = -1.0f;
            }
        }else
        {
            move = 0;
        }

        transform.Translate(0, move * vely * Time.deltaTime, 0);

        if (transform.position.y > maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.y < -maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, -maxposy, transform.position.z);
            transform.position = tmpPosition;
        }
    }
}
