using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : IMiniGame
{
	public GameObject[] dianas;//array de objetos
	public Cannon cannon;
	private GameManager gameManager;
	private int score;
	public int targetScore;
	bool toLose;

	IEnumerator Win (){
		yield return new WaitForSeconds (2f);
		gameManager.EndGame (IMiniGame.MiniGameResult.WIN);
	}

	IEnumerator Lose(){
		yield return new WaitForSeconds (2f);
		gameManager.EndGame (IMiniGame.MiniGameResult.LOSE);	
	}

	IEnumerator BooleanToTrue(){
		yield return new WaitForSeconds (10f);
		toLose = true;
	}


	void Update(){
		if (score == targetScore) {
			StartCoroutine (Win ());
		} else if(toLose) {
			StartCoroutine (Lose ());
		}
	}



	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		gameManager = gm;
	}

	public override void beginGame()
	{

	}

    public override string ToString()
    {
        return "Cannon by Roger";
    }
}
