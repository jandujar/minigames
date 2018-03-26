using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloActivate : MonoBehaviour {

	Component halo;

	void Awake(){
		halo = this.GetComponent ("Halo");
	}


	public void activeHalo(){
		halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
		StartCoroutine (waitDisableHalo ());
	}

	private IEnumerator waitDisableHalo(){
		yield return new WaitForSeconds (1.5f);
		halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
	} 

}
