using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	
	public int lifetime = 2 ;

	// Use this for initialization

void Update () {
	
Destroy(gameObject,lifetime);
	
}
}