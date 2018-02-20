using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : IMiniGame {

	private bool gameStarted = false;
	private GameManager gameManager;	


	//*************************************************************************************************Start game
	public override void beginGame()
	{
		Debug.Log(this.ToString() + " game Begin");
		gameStarted = true;
	}
	//*************************************************************************************************Start Loading
	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		this.gameManager = gm;

	}
	//*************************************************************************************************
	public override string ToString()
	{
		return "Do u know da wae?";
	}
	//*************************************************************************************************Update
	void Update () {
		if (gameStarted) {

		}

	}
}
