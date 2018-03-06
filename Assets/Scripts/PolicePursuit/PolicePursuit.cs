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
	public GameManager gameManager;
	private int knucklesPos = 0;
	private float h;

	private int randomPos;
	private float lastRandomPos;
    
    [SerializeField]private AudioSource backgroundMusic;

    [SerializeField]private GameObject trafficLightsRedParent;
    [SerializeField]private GameObject trafficLightsGreenParent;
    private GameObject[] trafficLightsRed;
    private GameObject[] trafficLightsGreen;
    private GameObject[] trafficLightsFinal = new GameObject[5];

    //*************************************************************************************************Start game
    public override void beginGame()
	{
		Debug.Log(this.ToString() + " game Begin");
        knucklesPos = 0;
        thief.transform.position = new Vector3(roads[0].transform.position.x, thief.transform.position.y, thief.transform.position.z);
        police.transform.position = new Vector3(roads[0].transform.position.x, police.transform.position.y, police.transform.position.z);
        initMovement();
        backgroundMusic.Play();
        //aSource.clip = start;
        //aSource.Play ();
    }

    private void initTrafficLights()
    {
        for (int i = 0; i < trafficLightsRed.Length; i++)
        {
            trafficLightsRed[i].SetActive(false);
        }
        for (int i = 0; i < trafficLightsGreen.Length; i++)
        {
            trafficLightsGreen[i].SetActive(false);
        }
        int redLength = Random.Range(2, 3);
        int greenLength = 0;
        if (redLength == 2)
        {
            greenLength = 3;
        }
        else
        {
            greenLength = 2;
        }
        int randomTrafficLightRed = 0;
        for (int i = 0; i < redLength; i++)
        {
            randomTrafficLightRed = Random.Range(0, (trafficLightsRed.Length - 1));
            if (!containsTrafficLight(randomTrafficLightRed, trafficLightsRed))
            {
                trafficLightsFinal[i] = trafficLightsRed[randomTrafficLightRed];
                trafficLightsFinal[i].SetActive(true);
            }
            else
            {
                i--;
            }
        }
        int randomTrafficLightGreen = 0;
        for (int i = redLength; i < 5; i++)
        {
            randomTrafficLightGreen = Random.Range(0, (trafficLightsGreen.Length - 1));
            if (!containsTrafficLight(randomTrafficLightGreen, trafficLightsGreen))
            {
                trafficLightsFinal[i] = trafficLightsGreen[randomTrafficLightGreen];
                trafficLightsFinal[i].SetActive(true);
            }
            else
            {
                i--;
            }
        }
    }

    private bool containsTrafficLight(int index, GameObject[] trafficLights)
    {
        for (int i = 0; i < 5; i++)
        {
            if (trafficLightsFinal[i] != null)
            {
                if (trafficLightsFinal[i] == trafficLights[index])
                {
                    return true;
                }
            }
        }
        return false;
    }

	//*************************************************************************************************Start Loading
	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
        roads = new Transform[roadsParent.transform.childCount];
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i] = roadsParent.transform.GetChild(i);
        }
        trafficLightsRed = new GameObject[trafficLightsRedParent.transform.childCount];
        for (int i = 0; i < trafficLightsRed.Length; i++)
        {
            trafficLightsRed[i] = trafficLightsRedParent.transform.GetChild(i).gameObject;
        }
        trafficLightsGreen = new GameObject[trafficLightsGreenParent.transform.childCount];
        for (int i = 0; i < trafficLightsGreen.Length; i++)
        {
            trafficLightsGreen[i] = trafficLightsGreenParent.transform.GetChild(i).gameObject;
        }
        initTrafficLights();
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
		thief.GetComponent<ThiefCar> ().StartMoving (this,knucklesPos);
        police.GetComponent<ThiefCar>().StartMoving(this, knucklesPos);
        //aSource.clip = clicking;
		//aSource.Play ();
	}

	public void MovementFinished(bool gameResult){
		if (!gameResult) {
			gameManager.EndGame (IMiniGame.MiniGameResult.LOSE);
		}
		else{
			gameManager.EndGame (IMiniGame.MiniGameResult.WIN);
		}
	}
}