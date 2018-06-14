using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Luka : MonoBehaviour {

    [SerializeField]
    float rotationSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
	}
}
