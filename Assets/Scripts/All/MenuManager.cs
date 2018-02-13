using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MenuManager it's a manager for games it only loads the next game
using UnityEngine.SceneManagement;


public class MenuManager : Singleton<MenuManager> {

    private enum MINIGAMES_ENUM { PONG, GOATTHROW, END };
    private MINIGAMES_ENUM currentGame = MINIGAMES_ENUM.PONG;

    //Load all minigames
    void Awake(){

    }

    void Start(){
        LaunchMiniGame();
    }

    public void LaunchMiniGame(){
        switch (currentGame)
        {
            case MINIGAMES_ENUM.GOATTHROW:
                SceneManager.LoadScene("GoatThrow");
                break;
            case MINIGAMES_ENUM.PONG:
                SceneManager.LoadScene("Pong");
                break;
            default:
                SceneManager.LoadScene("Pong");
                break;
        }

        currentGame = currentGame + 1;
        if (currentGame == MINIGAMES_ENUM.END)
        {
            currentGame = MINIGAMES_ENUM.PONG;
        }
    }
}
