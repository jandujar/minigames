using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private float moveVer;
    private float moveHor;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposy = 5.9f;
    public float maxposx = 10f;

    // Update is called once per frame
    void Update()
    {

        moveVer = Input.GetAxis("Vertical");
        moveHor = Input.GetAxis("Horizontal");

        transform.Translate(0, moveVer * vely * Time.deltaTime, 0);
        transform.Translate(moveHor * vely * Time.deltaTime, 0, 0);

        if (transform.position.y > maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x > maxposx)
        {
            tmpPosition = new Vector3(maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.y < -maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, -maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x < -maxposx)
        {
            tmpPosition = new Vector3(-maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
    }
}