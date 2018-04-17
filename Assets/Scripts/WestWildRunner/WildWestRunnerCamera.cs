using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildWestRunnerCamera : MonoBehaviour {
	//Position To Look
	private Transform posToLook;
	//La distancia a la que empieza la camara
	private Vector3 distanceToObjective;


	private Animation animController;

	// Use this for initialization
	void Start () {
		animController = this.GetComponent<Animation> ();
		//animController.Play ("WalkingCamera");
		posToLook = GameObject.FindGameObjectWithTag ("Player").transform;
		distanceToObjective = this.transform.position - posToLook.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = posToLook.position + distanceToObjective;
		//this.transform.LookAt (posToLook);
	}
}
