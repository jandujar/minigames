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
	public float distanceBtweenIntersections = 0.5f;
	//public GameObject intersection;
	public GameObject thief;
    public GameObject police;
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
        knucklesPos = 0;
        thief.transform.position = new Vector3(roads[0].transform.position.x, thief.transform.position.y, thief.transform.position.z);
        police.transform.position = new Vector3(roads[0].transform.position.x, police.transform.position.y, police.transform.position.z);
        initMovement();
        //aSource.clip = start;
        //aSource.Play ();
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
	//*************************************************************************************************
	private void initMovement(){
		movementStarted = true;
		thief.GetComponent<ThiefCar> ().StartMoving (this,knucklesPos);
        police.GetComponent<ThiefCar>().StartMoving(this, knucklesPos);
        aSource.clip = clicking;
		aSource.Play ();
	}

	public void MovementFinished(bool gameResult){
		aSource.Stop ();
		if (!gameResult) {
			gameManager.EndGame (IMiniGame.MiniGameResult.LOSE);
		}
		else{
			gameManager.EndGame (IMiniGame.MiniGameResult.WIN);
		}
	}
}