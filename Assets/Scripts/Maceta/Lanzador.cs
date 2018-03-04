using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour {
    private float move;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposx = 5.9f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move = InputManager.Instance.GetAxisHorizontal();
        
        transform.Translate( move * vely * Time.deltaTime,0, 0);

        if (transform.position.x > maxposx)
        {
            tmpPosition = new Vector3(maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x < -maxposx)
        {
            tmpPosition = new Vector3(-maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
    }
}
