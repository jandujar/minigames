using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour {

	// Use this for initialization
	void Start () {

        transform.GetChild(Random.Range(0, transform.childCount)).GetComponent<Renderer>().material.color = Color.blue;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
