using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoYouKnowTheWay : IMiniGame {
	//PUBLIC
	[Tooltip("value btween 1 and 6")]
	public int numberOfIntersections = 3;
	public float distanceBtweenIntersections = 0.5f;
	public GameObject intersection;
	public float intersectionMaxY;
	public float intersectionMinY;
	public Transform[] intersectionPos = new Transform[3];
	public GameObject uganda;
	public GameObject knuckles;
	public Transform[] ways = new Transform[4];

	//PRIVATE
	private GameManager gameManager;
	private int knucklesPos = 0;
	private bool gameStarted = false;
	private float h;
	private bool alreadyMoved = false;
	private bool movementStarted = false;

	private float randomPos;
	private float lastRandomPos;
	private float[] lastRowPos = new float[3];
	private int intersectionRow = 0;
	private float actualDistance;

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
		RandomUgandaPosition ();
		GenerateIntersection ();
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
			movementStarted = true;
			knuckles.GetComponent<Knuckles> ().StartMoving (this,knucklesPos);
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			RandomUgandaPosition ();
			GenerateIntersection ();
		}
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
		for (int i = 0; i < numberOfIntersections; i++) {
			GameObject go = Instantiate (intersection);

			if (intersectionRow > 2) {
				intersectionRow = 0;
			}
			 
			do{
			randomPos = Random.Range (intersectionMinY, intersectionMaxY);
			actualDistance = Mathf.Abs (lastRandomPos - randomPos);
			Debug.Log(Mathf.Abs(actualDistance));
			}while(Mathf.Abs(actualDistance) < distanceBtweenIntersections);

			go.transform.position = new Vector3 (intersectionPos[intersectionRow].transform.position.x,randomPos,0);
			//guardamos la posicion de la interseccion
			lastRandomPos = randomPos;

			intersectionRow++;




		}
	}

	public void MovementFinished(bool _correctWay){
		Debug.Log ("TERMINAO " + _correctWay);
	}
}
