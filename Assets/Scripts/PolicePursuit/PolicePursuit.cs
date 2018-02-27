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
	//public GameObject intersection;
	public GameObject ownObject;
    [SerializeField]private GameObject roadsParent;
    private Transform[] roads = new Transform[4];

	//PRIVATE
	private AudioSource aSource;
	public GameManager gameManager;
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
        roads = new Transform[roadsParent.transform.childCount];
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i] = roadsParent.transform.GetChild(i);
        }
		aSource = GetComponent<AudioSource> ();
	}

    public Transform getWays(int pos)
    {
        return roads[pos];
    }
    //*************************************************************************************************
    public override string ToString()
	{
		return "Police Pursuit! (Idea by Roger)";
	}
	//*************************************************************************************************Update
	void Update () {
		if (gameStarted && !movementStarted) {
			CheckPlayerInput ();
			//countDown ();
		}
	}
	//*************************************************************************************************Check Player Inputs
	private void CheckPlayerInput(){
		h = InputManager.Instance.GetAxisHorizontal ();
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
	}
	//*************************************************************************************************
	private void initMovement(){
		movementStarted = true;
		ownObject.GetComponent<ThiefCar> ().StartMoving (this,knucklesPos);
		aSource.clip = clicking;
		aSource.Play ();
	}

	//*************************************************************************************************Moves Knuckes to start way
	private void UpdateKnucklesPos(){
		ownObject.transform.position = new Vector3 (roads [knucklesPos].transform.position.x, ownObject.transform.position.y, ownObject.transform.position.z);

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
