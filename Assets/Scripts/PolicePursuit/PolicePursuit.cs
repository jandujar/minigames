using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RoadArray{
	public GameObject[] myArray;
}

public class PolicePursuit : IMiniGame {
	//PUBLIC
	[Tooltip("value btween 1 and 9 ")]
	public int numberOfIntersections = 3;
	public float maxTime = 5;
	public Text timerText;
	private float actualTime;
	public float distanceBtweenIntersections = 0.5f;
	public GameObject intersection;
    [SerializeField]private GameObject intersectionPosParent;
    private Transform[] intersectionPos = new Transform[3];
	public GameObject finalObject;
	public GameObject ownObject;
    [SerializeField]private GameObject waysParent;
    private Transform[] ways = new Transform[4];

	//PRIVATE
	private AudioSource aSource;
	private GameManager gameManager;
	private int knucklesPos = 0;
	private bool gameStarted = false;
	private float h;
	private bool alreadyMoved = false;
	private bool movementStarted = false;

	private int randomPos;
	private float lastRandomPos;
	private float[] lastRowPos = new float[3];
	private int actualRow = 0;
	private float actualDistance;
    
    [SerializeField]private GameObject intersectionRowsParent;
    private MyArray[] intersectionRows;

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
        intersectionPos = new Transform[intersectionPosParent.transform.childCount];
        for (int i = 0; i < intersectionPos.Length; i++)
        {
            intersectionPos[i] = intersectionPosParent.transform.GetChild(i);
        }
        ways = new Transform[waysParent.transform.childCount];
        for (int i = 0; i < ways.Length; i++)
        {
            ways[i] = waysParent.transform.GetChild(i);
        }
        intersectionRows = new MyArray[intersectionRowsParent.transform.childCount];
        for (int i = 0; i < intersectionRows.Length; i++)
        {
            //Esto es null reference por algun motivo
            intersectionRows[i].myArray = new GameObject[intersectionRowsParent.transform.GetChild(i).transform.childCount];
            for (int j = 0; j < intersectionRows[i].myArray.Length; j++)
            {
                intersectionRows[i].myArray[j] = intersectionRowsParent.transform.GetChild(i).transform.GetChild(i).gameObject;
            }
        }
        //(intersectionRows [actualRow + 1].myArray [randomPos].activeSelf == false)
        RandomFinalPosition();
		GenerateIntersection ();
		aSource = GetComponent<AudioSource> ();
	
	}

    /*public Transform getIntersectionPos(int pos)
    {
        return intersectionPos[pos];
    }*/

    public Transform getWays(int pos)
    {
        return ways[pos];
    }
    //*************************************************************************************************
    public override string ToString()
	{
		return "Police Pursuit!";
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
			RandomFinalPosition ();
			GenerateIntersection ();
		}
	}
	//*************************************************************************************************
	private void initMovement(){
		movementStarted = true;
		ownObject.GetComponent<ThiefCar> ().StartMoving (this,knucklesPos);
		aSource.clip = clicking;
		aSource.Play ();
	}
	//*************************************************************************************************Put uganda Randomly
	private void RandomFinalPosition(){
		int rNumber = Random.Range (0, 4);
		finalObject.transform.position = new Vector3 (ways [rNumber].transform.position.x, finalObject.transform.position.y, finalObject.transform.position.z);
	}

	//*************************************************************************************************Moves Knuckes to start way
	private void UpdateKnucklesPos(){
		ownObject.transform.position = new Vector3 (ways [knucklesPos].transform.position.x, ownObject.transform.position.y, ownObject.transform.position.z);

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
