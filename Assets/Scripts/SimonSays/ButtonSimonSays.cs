using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSimonSays : MonoBehaviour {
	[Tooltip("Purple = 0 , Red = 1, White = 2, Green = 3")]
	public int indexColor;
	public Color colorCorrect;
	public Color colorIncorrect;
	public GameObject haloCorrect;
	public GameObject haloIncorrect;
	public GameObject managerSimon;

	private Light lumus;
	// Use this for initialization
	void Start () {
		lumus = this.GetComponent<Light> ();
	}

	public void emitLumus(bool correct){
		if (correct) {
			lumus.color = colorCorrect;
			haloCorrect.GetComponent<HaloActivate> ().activeHalo ();
		} else {
			lumus.color = colorIncorrect;
			haloIncorrect.GetComponent<HaloActivate> ().activeHalo ();
		}
	}

	void OnTriggerEnter(Collider other){
		managerSimon.GetComponent<ManagerSimonSays> ().addButtonPlayer (indexColor);
	}
}
