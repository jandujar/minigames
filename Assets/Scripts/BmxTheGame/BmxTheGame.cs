using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BmxTheGame  : IMiniGame {
	private GameManager gameManager;
	public BikeController bike;
	public override void beginGame()
	{
		//begins
		Debug.Log(this.ToString() + " game Begin");
		bike.gameStarted = true;
	}

	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		this.gameManager = gm;
	}

	public override string ToString()
	{
		return "BmxTheGame by Dídac";
	}


	public void gameEnd(bool result){
		if (result) {
			gameManager.EndGame (IMiniGame.MiniGameResult.WIN);
		} else {
			gameManager.EndGame (IMiniGame.MiniGameResult.LOSE);
		}
	}
}
