using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : IMiniGame
{
	public Cannon cannon;
	private GameManager gameManager;
	private int score;
	public int targetScore;
	public GameObject scoreManager;
	bool toLose;

	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		this.gameManager = gm;
	}

	IEnumerator Win(){
		yield return new WaitForSeconds (2f);
		gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
	}

	IEnumerator Lose(){
		yield return new WaitForSeconds (2f);
		gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);	
	}

	IEnumerator BooleanToTrue(){
		yield return new WaitForSeconds (10f);
		toLose = true;
	}


	void Update(){
		Debug.Log (score);
		score = scoreManager.GetComponent<CannonScore>().score;
		if (score == 20) {
			StartCoroutine(Win());
		} 

		if(toLose) {
			StartCoroutine(Lose());
		}
	}




	public void Start(){
	
	StartCoroutine(BooleanToTrue());
	
	}
	public override void beginGame()
	{
		//StartCoroutine(BooleanToTrue());
	}

    public override string ToString()
    {
        return "Cannon by Roger";
    }
}
