using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
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

        if (Input.GetAxis("Vertical") > 0)
        {
            Vector3 v3Force = (mAcceleration * transform.forward)*Time.deltaTime;
            Debug.Log(v3Force);
            if (mRb.velocity.magnitude < topSpeed)
            {
                mRb.AddForce(-v3Force);
            }

        }

        if (Input.GetAxis("Vertical") < 0)
        {
            Vector3 v3Force = (mAcceleration * transform.forward)*Time.deltaTime;

            if (mRb.velocity.magnitude < backTopSpeed)
            {
                mRb.AddForce(v3Force);
            }
        }


        //Rotate Player
        transform.Rotate(0, Input.GetAxis("Horizontal") * mRotationSpeed * Time.deltaTime, 0);

    }
}