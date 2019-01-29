using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MyArray{
	public GameObject[] myArray;
}

public class DoYouKnowTheWay : IMiniGame {
	//PUBLIC
	[Tooltip("value btween 1 and 9 ")]
	public int numberOfIntersections = 3;
	public float maxTime = 5;
	public Text timerText;
	private float actualTime;
	public float distanceBtweenIntersections = 0.5f;
	public GameObject intersection;
	public Transform[] intersectionPos = new Transform[3];
	public GameObject uganda;
	public GameObject knuckles;
	public Transform[] ways = new Transform[4];

	//PRIVATE
	private AudioSource aSource;
	private GameManager gameManager;
	private int knucklesPos = 0;
	private bool gameStarted = false;
	private float h;
	private bool alreadyMoved = false;
	private bool movementStarted = false;

	private int randomPos;
	private int actualRow = 0;

	public MyArray[] intersectionRows;

	public AudioClip start;
	public AudioClip clicking;
	//*************************************************************************************************Start game
	public override void beginGame()
	{
		Debug.Log(this.ToString() + " game Begin");
		gameStarted = true;
		actualTime = maxTime;
		aSource.clip = start;
		aSource.Play ();
	}
	//*************************************************************************************************Start Loading
	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		this.gameManager = gm;
		RandomUgandaPosition ();
		GenerateIntersection ();
		aSource = GetComponent<AudioSource> ();
	
	}
	//*************************************************************************************************
	public override string ToString()
	{
		return "Do u know da wae?";
	}
	//*************************************************************************************************Update
	void Update () {
		if (gameStarted && !movementStarted) {
			CheckPlayerInput ();
			countDown ();
		}
		
	}
	private void countDown(){
		actualTime -= Time.deltaTime;
		timerText.text = actualTime.ToString ();
		if (actualTime < 0) {
			initMovement();
			timerText.enabled = false;
		}
	}
	//*************************************************************************************************Check Player Inputs
	private void CheckPlayerInput(){
		h = InputManager.Instance.GetAxisHorizontal ();
		//Change Knuckeles Pos
		if (!alreadyMoved && h <= -0.1 && knucklesPos > 0) {
			alreadyMoved = true;
			knucklesPos--;
			UpdateKnucklesPos ();
		}
		if (!alreadyMoved && h >= 0.1 && knucklesPos < 3) {
			alreadyMoved = true;
			knucklesPos++;
			UpdateKnucklesPos ();
		}
		if (alreadyMoved && h < 0.1 && h > -0.1) {
			alreadyMoved = false;
		}
		//Start Moving
		if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) {
			initMovement ();
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			RandomUgandaPosition ();
			GenerateIntersection ();
		}
	}
	//*************************************************************************************************
	private void initMovement(){
		movementStarted = true;
		knuckles.GetComponent<Knuckles> ().StartMoving (this,knucklesPos);
		aSource.clip = clicking;
		aSource.Play ();
	}
	//*************************************************************************************************Put uganda Randomly
	private void RandomUgandaPosition(){
		int rNumber = Random.Range (0, 4);
		uganda.transform.position = new Vector3 (ways [rNumber].transform.position.x, uganda.transform.position.y, uganda.transform.position.z);
	}

	//*************************************************************************************************Moves Knuckes to start way
	private void UpdateKnucklesPos(){
		knuckles.transform.position = new Vector3 (ways [knucklesPos].transform.position.x, knuckles.transform.position.y, knuckles.transform.position.z);

	}
	//*************************************************************************************************Random Intersection generator
	private void GenerateIntersection(){
		bool exit = false;
		for (int i = 0; i < numberOfIntersections; i++) {
			if (actualRow > 2) {
				actualRow = 0;
			} 
		
			//Bucle generacion
			while (!exit) {
				randomPos = Random.Range (0, 8);

				switch (actualRow) {
				case 0:
					if ((intersectionRows [actualRow].myArray [randomPos].activeSelf == false) && (intersectionRows [actualRow + 1].myArray [randomPos].activeSelf == false)) {
						exit = true;
					}
					break;
				case 1:
					if ((intersectionRows [actualRow].myArray [randomPos].activeSelf == false) && 
						(intersectionRows [actualRow + 1].myArray [randomPos].activeSelf == false) &&
						(intersectionRows [actualRow-1].myArray [randomPos].activeSelf == false)) {
						exit = true;
					}
					break;
				case 2:
					if ((intersectionRows [actualRow].myArray [randomPos].activeSelf == false) && (intersectionRows [actualRow -1].myArray [randomPos].activeSelf == false)) {
						exit = true;
					}
					break;
				}
			}
			//activa intersection
			intersectionRows [actualRow].myArray [randomPos].SetActive (true);
			exit = false;
			actualRow++;
		}
	}

	public void MovementFinished(bool _correctWay){
		aSource.Stop ();
		if (!_correctWay) {
			gameManager.EndGame (IMiniGame.MiniGameResult.LOSE);
		}
		else{
			gameManager.EndGame (IMiniGame.MiniGameResult.WIN);
		}
	}
}
