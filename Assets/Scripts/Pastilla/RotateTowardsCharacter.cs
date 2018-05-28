using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCharacter : MonoBehaviour {
    [SerializeField]
    GameObject targetToRotate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {        
       transform.rotation = Quaternion.RotateTowards(transform.rotation,targetToRotate.transform.rotation,180.0f);
	}
}
