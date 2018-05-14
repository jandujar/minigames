using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControlsInfo : MonoBehaviour {

public GameObject Text01;
public GameObject Text02;
private bool ShowHide;
private bool Deactive = false;


	// Use this for initialization
void Start () {
Text01.SetActive (false);
Text02.SetActive (false);
}
	
// Update is called once per frame
void Update () {
if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) 
	|| Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4)
    || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6)
	|| Input.GetKeyDown(KeyCode.Alpha7)){ 
	if (ShowHide == false)
	{
	Deactive = true;
	Text01.SetActive (true);
	if(Text02 == null){
		Text02 = null;
		}
	else{
	Text02.SetActive (true);
	}
	}
	}
if(Input.GetKeyDown(KeyCode.Tab) && Deactive == true){ 
	if(ShowHide){
	ShowHide = false;	
	Text01.SetActive (true);
	if(Text02 == null){
		Text02 = null;
		}
	else{
	Text02.SetActive (true);
	}
	}
	else{
	ShowHide = true;	
	Text01.SetActive (false);
	Destroy (Text02);
	}
	}
}
}