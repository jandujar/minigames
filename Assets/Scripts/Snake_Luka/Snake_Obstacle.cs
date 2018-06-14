using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);
        transform.position = pos;

        transform.Rotate(45f, 45f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
