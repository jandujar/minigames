using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointRotation : MonoBehaviour {
    public float speed;

    private bool isRunning;

	// Use this for initialization
	void Start () {
        isRunning = false;

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
}