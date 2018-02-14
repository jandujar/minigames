using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MenuManager it's a manager for games it only loads the next game
using UnityEngine.SceneManagement;


public class MenuManager : Singleton<MenuManager> {

    //Load all minigames
    public override void Awake(){

    }

    void Start(){
        LaunchMiniGame();
    }

    public void LaunchMiniGame(){
        //TODO: Load next minigame
        SceneManager.LoadScene("BottleFlip");
    }
}
