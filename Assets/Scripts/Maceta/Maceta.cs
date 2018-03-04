using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maceta : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Down")
        {
            DestroyObject(this.gameObject);
        }
        else if(collision.gameObject.name == "Enemy")
        {
            Debug.Log("hit");
        }
        
    
    }
    // Update is called once per frame
    void Update () {
		
	}
}
