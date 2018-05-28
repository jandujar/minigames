using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildWestRunnerManager: MonoBehaviour {

	private GameManager gm;
	private AudioSource source;
	private bool startGame;
	private int goalScore;
	public static WildWestRunnerManager instance = null;

	void Awake(){
		//Search for all 
//		objective = GameObject.FindGameObjectsWithTag("Player");
//		gameReady = false;
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
		} else {
			instance = this;

			source = this.GetComponent<AudioSource> ();
			startGame = false;
			DontDestroyOnLoad( this.gameObject );
		}
	}
		
	public void InitGame(GameManager manager){
		startGame = true;
		source.Play ();
		gm = manager;
	}

	public void endGame(IMiniGame.MiniGameResult res){
		source.Stop ();
		gm.EndGame (res);
	}

	//*******************************************************************************************SETTERS
	public void setGoalScore(int newGoalScore){
		goalScore = newGoalScore;
	}

	//*******************************************************************************************GETTERS
	public bool getStartGame(){
		return startGame;
	}

	public int getGoalScore(){
		return goalScore;
	}

}
