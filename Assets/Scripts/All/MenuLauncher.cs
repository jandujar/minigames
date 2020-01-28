using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLauncher : MonoBehaviour {

	// Use this for initialization
	public void LaunchGame () {
		MenuManager.Instance.InitGames();
	}

    public void Launch_2017_2019_Minigames_2(){
        MenuManager.Instance.Launch_2017_2019_Minigames_2();
    }

    public void Launch_2017_2019_Minigames_3(){
        MenuManager.Instance.Launch_2017_2019_Minigames_3();
    }

    public void Launch_2019_2020_Minigames_1(){
        MenuManager.Instance.Launch_2019_2020_Minigames_1();
    }

    public void Launch_2019_2020_Minigames_2(){
        MenuManager.Instance.Launch_2019_2020_Minigames_2();
    }

    /*
    public void Update(){
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) {
            LaunchGame();
        }
    }
    */
}
