using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MenuManager it's a manager for games it only loads the next game
using UnityEngine.SceneManagement;
using System;
using System.Linq;


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
		//MOVIMIENTO,
		MATHEMATICS,
		VEGAN,
		SAFEBOX,
        BOXING,
        FLAPPY,
        POLICE,
        DUELO,
		//FRISBEE,
		BROCHETA,
		BURGUER,
		FROGGER,
		KNIFETHROW,
		MACETA,
		SAFEPRESIDENT,
		SHOOTINGALEX,
		SHOOTCAN,
		SIMON,
		WOODCUTTER,
		ZUMBA,
        BOMB,
        BRUM,
        BMX,
        DESTROY,
        BALLRUN,
        TREASURE,
        SHOOTTHEBALL,
        RACINGSHIP,
        CANNON,
        ZOMBIENITE,
        BOWLING,
        //DISARM,
        WHACA,
        ARCO,
        MATRIX,
        MOSQUITO,
        PASTILLA,
        ROLLINGBALL,
        WESTWILL,
		END };
	
    private MINIGAMES_ENUM currentGame = MINIGAMES_ENUM.PONG;

    private ArrayList games;

    public int currentScore;


    public void InitGames(){
        currentScore = 0;
        games = new ArrayList();

        foreach (MINIGAMES_ENUM min in Enum.GetValues(typeof(MINIGAMES_ENUM)).Cast<MINIGAMES_ENUM>())
        {
            if (min != MINIGAMES_ENUM.END)
            {
                games.Add(min);
            }
        }
        LaunchMiniGame();
    }

    public void LaunchMiniGame(){
        if (games == null)
        {
            InitGames();
        }
        if (games.Count == 0)
        {
            SceneManager.LoadScene("EndGame");
            return;
        }
		
        int actual = UnityEngine.Random.Range((int)0,(int)games.Count);
        currentGame = (MINIGAMES_ENUM)games[actual];
        Debug.Log ("Launch MiniGame: " + currentGame.ToString ());

        games.RemoveAt(actual);


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
		case MINIGAMES_ENUM.FROGGER:
			SceneManager.LoadScene("Frogger");
			break;
		case MINIGAMES_ENUM.BURGUER:
			SceneManager.LoadScene("BurgerBuilder");
			break;
		case MINIGAMES_ENUM.KNIFETHROW:
			SceneManager.LoadScene("KnifeThrow");
			break;
		case MINIGAMES_ENUM.MACETA:
			SceneManager.LoadScene("Maceta");
			break;
		case MINIGAMES_ENUM.SAFEPRESIDENT:
			SceneManager.LoadScene("SavePresident");
			break;
		case MINIGAMES_ENUM.SHOOTINGALEX:
			SceneManager.LoadScene("ShootingAlex");
			break;
		case MINIGAMES_ENUM.SHOOTCAN:
			SceneManager.LoadScene("ShotTheCan");
			break;
		case MINIGAMES_ENUM.SIMON:
			SceneManager.LoadScene("SimonSays");
			break;
		case MINIGAMES_ENUM.WOODCUTTER:
			SceneManager.LoadScene("WoodCutter");
			break;
		case MINIGAMES_ENUM.ZUMBA:
			SceneManager.LoadScene("ZumbaClass");
			break;
        case MINIGAMES_ENUM.BOMB:
            SceneManager.LoadScene("Bomb");
            break;
		
		/* Not working games 
		case MINIGAMES_ENUM.FRISBEE:
			SceneManager.LoadScene("Frisbee");
            break;
		case MINIGAMES_ENUM.MOVIMIENTO:
			SceneManager.LoadScene("Movimiento");
			break;
        */         
		case MINIGAMES_ENUM.BROCHETA:
			SceneManager.LoadScene("Brocheta");
			break;
        case MINIGAMES_ENUM.BRUM:
            SceneManager.LoadScene("Brum");
            break;
        case MINIGAMES_ENUM.BMX:
            SceneManager.LoadScene("BmxTheGame");
            break;
        case MINIGAMES_ENUM.DESTROY:
            SceneManager.LoadScene("DestroyTheWorld");
            break;
        case MINIGAMES_ENUM.BALLRUN:
            SceneManager.LoadScene("BallRun");
            break;
        case MINIGAMES_ENUM.TREASURE:
            SceneManager.LoadScene("FindTreasure");
            break;
        case MINIGAMES_ENUM.SHOOTTHEBALL:
            SceneManager.LoadScene("ShootTheBall");
            break;
        case MINIGAMES_ENUM.RACINGSHIP:
            SceneManager.LoadScene("RacingShips");
            break;
        case MINIGAMES_ENUM.CANNON:
            SceneManager.LoadScene("Cannon");
            break;
        case MINIGAMES_ENUM.ZOMBIENITE:
            SceneManager.LoadScene("Zombienite");
            break;
        case MINIGAMES_ENUM.BOWLING:
            SceneManager.LoadScene("Bowling");
            break;
                /*
        case MINIGAMES_ENUM.DISARM:
            SceneManager.LoadScene("DisarmTheNuke");
            break;
            */
        case MINIGAMES_ENUM.WHACA:
            SceneManager.LoadScene("Whacamole");
            break;
        case MINIGAMES_ENUM.ARCO:
            SceneManager.LoadScene("Arco");
            break;
        case MINIGAMES_ENUM.MATRIX:
            SceneManager.LoadScene("Matrix");
            break;
        case MINIGAMES_ENUM.MOSQUITO:
            SceneManager.LoadScene("Mosquito");
            break;
        case MINIGAMES_ENUM.PASTILLA:
            SceneManager.LoadScene("PastillaScene");
            break;
        case MINIGAMES_ENUM.ROLLINGBALL:
            SceneManager.LoadScene("RollingBallScene");
            break;
        case MINIGAMES_ENUM.WESTWILL:
            SceneManager.LoadScene("WestWilldRunner");
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

    public void WonGame(){
        currentScore += 10;
    }
}