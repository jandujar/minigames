using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MenuManager it's a manager for games it only loads the next game
using UnityEngine.SceneManagement;


public class MenuManager : Singleton<MenuManager> {

    private enum MINIGAMES_ENUM { 
		PONG, 
		GOATTHROW, 
		BILLIARDS,
		BOTTLEFLIP,
		CARROT,
		DYKTW,
		GITAHIRO,
		KNIFEFINGERS,
		MSEGADA,
		PICKFISH,
		DUCKSHOOTER,
		EQUILIBRIO,
		MOVIMIENTO,
		MATHEMATICS,
		VEGAN,
		SAFEBOX,
        BOXING,
        FLAPPY,
        POLICE,
        DUELO,
		END };
	
    private MINIGAMES_ENUM currentGame = MINIGAMES_ENUM.PONG;

    void Start(){
        LaunchMiniGame();
    }

    public void LaunchMiniGame(){

		Debug.LogError ("Launch MiniGame: " + currentGame.ToString ());

		if (currentGame == MINIGAMES_ENUM.BOTTLEFLIP) {
			currentGame = MINIGAMES_ENUM.DYKTW;
		} else if (currentGame == MINIGAMES_ENUM.GITAHIRO) {
			currentGame = MINIGAMES_ENUM.KNIFEFINGERS;
		} else if (currentGame == MINIGAMES_ENUM.MOVIMIENTO) {
            currentGame = MINIGAMES_ENUM.MATHEMATICS;
		}

		switch (currentGame) {
		case MINIGAMES_ENUM.PONG:
			SceneManager.LoadScene("Pong");
			break;
		case MINIGAMES_ENUM.GOATTHROW:
			SceneManager.LoadScene("GoatThrow");
			break;
		case MINIGAMES_ENUM.BILLIARDS:
			SceneManager.LoadScene("Billiards");
			break;
		case MINIGAMES_ENUM.BOTTLEFLIP:
			SceneManager.LoadScene("BottleFlip");
			break;
		case MINIGAMES_ENUM.CARROT:
			SceneManager.LoadScene("Carrot");
			break;
		case MINIGAMES_ENUM.DYKTW:
			SceneManager.LoadScene("DoYouKnowTheWay");
			break;
		case MINIGAMES_ENUM.GITAHIRO:
			SceneManager.LoadScene("GitaHiro");
			break;
		case MINIGAMES_ENUM.KNIFEFINGERS:
			SceneManager.LoadScene("KnifeFingers");
			break;
		case MINIGAMES_ENUM.MSEGADA:
			SceneManager.LoadScene("MSegada");
			break;
		case MINIGAMES_ENUM.PICKFISH:
			SceneManager.LoadScene("PickAFish");
			break;
		case MINIGAMES_ENUM.DUCKSHOOTER:
			SceneManager.LoadScene("DuckShooter");
			break;
		case MINIGAMES_ENUM.EQUILIBRIO:
			SceneManager.LoadScene("Equilibrio");
			break;
		case MINIGAMES_ENUM.MOVIMIENTO:
			SceneManager.LoadScene("Movimiento");
			break;
		case MINIGAMES_ENUM.MATHEMATICS:
			SceneManager.LoadScene("MathematicalOperations");
			break;
		case MINIGAMES_ENUM.VEGAN:
			SceneManager.LoadScene("VeganKnows");
			break;
		case MINIGAMES_ENUM.SAFEBOX:
			SceneManager.LoadScene("SafeBox");
			break;
        case MINIGAMES_ENUM.BOXING:
            SceneManager.LoadScene("Boxing");
            break;
        case MINIGAMES_ENUM.FLAPPY:
            SceneManager.LoadScene("FlappyBird");
            break;
        case MINIGAMES_ENUM.POLICE:
            SceneManager.LoadScene("PolicePursuit");
            break;
        case MINIGAMES_ENUM.DUELO:
            SceneManager.LoadScene("KauboiDueru");
            break;
		case MINIGAMES_ENUM.END:
		default:
			SceneManager.LoadScene ("Pong");
			break;
		}

        currentGame = currentGame + 1;
        if (currentGame == MINIGAMES_ENUM.END)
        {
            currentGame = MINIGAMES_ENUM.PONG;
        }
    }
}