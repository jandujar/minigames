using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIA : MonoBehaviour
{
    public float mAcceleration = 7.0F;
    public int topSpeed = 10;
    public int backTopSpeed = 5;
    private int mRotationSpeed = 130;
    private Rigidbody mRb;


    // Use this for initialization
    void Start()
    {
        mRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v3Force = (mAcceleration * transform.forward) * Time.deltaTime;

        if (mRb.velocity.magnitude < topSpeed)
        {
            mRb.AddForce(-v3Force);
        }
        goLeft();

    }

    void goLeft()
    {
        transform.Rotate(0, 1 * mRotationSpeed * Time.deltaTime, 0);

    }
}
