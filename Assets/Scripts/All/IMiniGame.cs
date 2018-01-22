using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMiniGame : MonoBehaviour {

	public enum MiniGameDificulty{
		EASY,
		NORMAL,
		HARD
	}

	public enum MiniGameResult{
		WIN,
		LOSE
	}

	// Use this for initialization
	public abstract void initGame(MiniGameDificulty difficulty, GameManager gm);

	//The game begins
	public abstract void beginGame ();
}
