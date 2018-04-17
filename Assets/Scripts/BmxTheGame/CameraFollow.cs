using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);
	}
}
