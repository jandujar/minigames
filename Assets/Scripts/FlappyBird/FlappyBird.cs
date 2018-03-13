using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBird : IMiniGame {

	private bool gameStarted = false;
	private GameManager gameManager;

	private int actualScore;

	public int maxScore;
	public GameObject[] obstacles = new GameObject[5];
	public float obstacleSpeed = 3f;
	public float limitPosX;
	public float initPosX;
	public float maxPosY;
	public float minPosY;
	public Text scoreTxt;
	public Bird bird;
	public AudioSource aSource;
	public AudioClip destroy, score, tap;

	//*************************************************************************************************Start game
	public override void beginGame()
	{
		Debug.Log(this.ToString() + " game Begin");
		gameStarted = true;
		bird.init ();
		actualScore = 0;
	}
	//*************************************************************************************************Start Loading
	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		this.gameManager = gm;
		aSource = GetComponent<AudioSource> ();

	}
	//*************************************************************************************************
	public override string ToString()
	{
		return "Tap tap tap";
	}

	//*************************************************************************************************Update
	void Update () {
		if (gameStarted) {
			MoveObstacles ();
			PoolManager ();

		}

	}

	//*************************************************************************************************move
	private void MoveObstacles(){
		for(int i = 0; i < obstacles.Length; i ++){
			obstacles[i].transform.Translate(-obstacles[i].transform.right *  obstacleSpeed * Time.deltaTime);
		}
	}
	//*************************************************************************************************pool
	private void PoolManager(){
		for(int i = 0; i < obstacles.Length; i ++){
			if (obstacles [i].transform.position.x < limitPosX) {
				
				obstacles [i].transform.position = new Vector3 (initPosX, Random.Range(minPosY,maxPosY), 0);
			}
		}
	}

	//*************************************************************************************************
	public void EndGame(bool result){
		if (!result) {
			aSource.clip = destroy;
			aSource.Play ();
			gameManager.EndGame (IMiniGame.MiniGameResult.LOSE);
		}
		else{
			gameManager.EndGame (IMiniGame.MiniGameResult.WIN);
		}
	}
	//*************************************************************************************************
	public void UpdateScore(){
		aSource.clip = score;
		aSource.Play ();
		actualScore++;
		scoreTxt.text = actualScore.ToString();
		if (actualScore >= maxScore) {
			EndGame (true);
		}
	}
	public void playTap(){
		aSource.clip = tap;
		aSource.Play ();
	}
}
