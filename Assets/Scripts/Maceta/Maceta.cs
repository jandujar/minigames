using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maceta : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        
        DestroyObject(this.gameObject);
    
    }
    // Update is called once per frame
    void Update () {
		
	}
}
