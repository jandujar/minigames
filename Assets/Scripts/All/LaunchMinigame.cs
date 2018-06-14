using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMinigame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LaunchMiniGame", 2);	
	}
	
    void LaunchMiniGame(){
        MenuManager.Instance.LaunchMiniGame();
    }
}
