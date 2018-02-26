using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour {
	public float[] parallaxSpeed = new float[4];
	 
    public GameObject[] elements = new GameObject[5];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveBackground ();
		for (int i = 0; i < 2; i++) {
			if (elements [i].transform.position.x < -39.27f) {
				elements [i].transform.position = new Vector3(-19.65f,elements [i].transform.position.y,elements [i].transform.position.z);
			}
		}
	}

    public void MoveBackground() {
		for (int i = 0; i < elements.Length; i++) { 
			elements[i].transform.Translate(-elements[i].transform.right *parallaxSpeed[i] * Time.deltaTime);
        }
    }
}
