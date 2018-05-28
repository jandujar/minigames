using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float MotorForce;
    public WheelCollider WheelColFR;
    public WheelCollider WheelColFL;
    public WheelCollider WheelColBR;
    public WheelCollider WheelColBL;

    public float SteerForce;
    public float BrakeForce;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float v = Input.GetAxis("Vertical") * MotorForce;
        float h = Input.GetAxis("Horizontal") * SteerForce;

        WheelColBL.motorTorque = v;
        WheelColBR.motorTorque = v;

        WheelColFL.steerAngle = h;
        WheelColFR.steerAngle = h;

        if (Input.GetKey(KeyCode.Space))
        {
            WheelColBL.brakeTorque = BrakeForce;
            WheelColBR.brakeTorque = BrakeForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            WheelColBL.brakeTorque = 0;
            WheelColBR.brakeTorque = 0;
        }

    }
}
