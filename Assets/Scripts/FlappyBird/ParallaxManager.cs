using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour {
	public float[] parallaxSpeed = new float[4];
	 
    public GameObject[] elements = new GameObject[4];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveBackground ();
	}

    public void MoveBackground() {
		for (int i = 0; i < elements.Length; i++) { 
			elements[i].transform.Translate(-elements[i].transform.right *parallaxSpeed[i] * Time.deltaTime);
        }
    }
}
