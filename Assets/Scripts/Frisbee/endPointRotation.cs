using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointRotation : MonoBehaviour {

    private bool isRunning;
    private float speed;
    
	// Use this for initialization
	void Start () {
        isRunning = false;
        speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (isRunning)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    public void startRun()
    {
        isRunning = true;
    }

    public void stopRun()
    {
        isRunning = false;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

}