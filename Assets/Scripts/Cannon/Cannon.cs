using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : IMiniGame
{
	public Cannon cannon;
	private GameManager gameManager;
	private int score;
	public int targetScore;
	public GameObject scoreManager;
	bool toLose;
	public Text countDown;
	public int textNum;

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
		yield return new WaitForSeconds (13f);
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

		countDown.text = textNum + " ";
	}

	IEnumerator StartCount(){
		yield return new WaitForSeconds (1f);
		textNum -= 1;
		if (textNum > 0) {
			StartCoroutine (StartCount ());
		}
	}




	public void Start(){
	
	StartCoroutine(BooleanToTrue());
	
	}
	public override void beginGame()
	{
		StartCoroutine(StartCount());
	}

    public override string ToString()
    {
        return "Cannon by Roger";
    }
}
