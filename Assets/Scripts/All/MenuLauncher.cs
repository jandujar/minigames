using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLauncher : MonoBehaviour {

	// Use this for initialization
	public void LaunchGame () {
		MenuManager.Instance.InitGames();
	}

    public void Update(){
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) {
            LaunchGame();
        }
    }
}
