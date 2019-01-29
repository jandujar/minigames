using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_MarcEscobar : IMiniGame {
	public GameManager gameManager;
	public bool gameStarted = false;
	public override void beginGame()
	{
		gameStarted = true;
		Debug.Log(this.ToString() + " game Begin");
	}
	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		this.gameManager = gm;
	}

	public override string ToString()
	{
		return "Do u know da wae?";
	}
}
