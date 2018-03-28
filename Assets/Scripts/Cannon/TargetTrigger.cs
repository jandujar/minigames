using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetTrigger : MonoBehaviour {


	public bool interactable;
	public bool skullTarget;
	public GameObject scoreManager;

	void Start(){
		interactable = true;
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && Input.GetButton ("Fire1") && interactable && skullTarget == false) {
			interactable = false;
			scoreManager.GetComponent<CannonScore> ().score += 5;
			Debug.Log ("colision pal jandu");
			GetComponent<SpriteRenderer> ().enabled = false;
		} else if (other.tag == "Player" && Input.GetButton ("Fire1") && interactable && skullTarget == true) {
			interactable = false;
			scoreManager.GetComponent<CannonScore> ().score -= 3;
			Debug.Log ("colision pal jandu");
			GetComponent<SpriteRenderer> ().enabled = false;	
		}
	}




}
