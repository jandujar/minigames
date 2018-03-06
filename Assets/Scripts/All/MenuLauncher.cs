using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLauncher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MenuManager.Instance.LaunchMiniGame ();
	}
}
