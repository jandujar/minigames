using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_MarcEscobar : MonoBehaviour {
	public GameObject Text;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Text.transform.Translate (Text.transform.up * speed * Time.deltaTime);
		if (Input.anyKeyDown) {
			BackToMenu ();
		}
	}

	void BackToMenu(){
		//CARGAR EL MENU DE NUEVO
		Debug.Log("Skip");
	}
}
