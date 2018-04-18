using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildWestRunnerSceneManager : MonoBehaviour {

	public GameObject[] groundStraight;

	public GameObject[] groundStart;

	public GameObject[] powerUps;

	private enum typeArray{Start, Straight, Curve, Bifurc};

	private Transform playerPos;
	private float spawnPoint = 0.0f;
	private float lenghtGroundStraight = 14.5f;
	private int safeZone = 15;
	private int groundInVision = 7;

	private List<GameObject> groundActive;

	// Use this for initialization
	void Start () {
		groundActive = new List<GameObject>();
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < groundInVision; i++) {
			if (i + 1 == groundInVision) {
				InstantiateGround (1, typeArray.Start);
			} else {
				InstantiateGround (0, typeArray.Start);
			}
		}
	}

	private void InstantiateGround(int indexGround, typeArray state){
		GameObject newGround;
		switch (state) {
		case typeArray.Start:
			newGround = Instantiate (groundStart [indexGround]) as GameObject;
			newGround.transform.SetParent (this.transform);
			newGround.transform.position = Vector3.forward * spawnPoint;
			if (Random.Range (0, 10) > 8) {
				Transform[] child = newGround.GetComponentsInChildren<Transform> ();
				for (int i = 0; i <= newGround.transform.childCount; i++) {
					if (child [i].tag == "PowerUp") {
						GameObject newPowerUp = Instantiate (powerUps [Random.Range (0, 2)]) as GameObject;
						newPowerUp.transform.SetParent (newGround.transform);
						newPowerUp.transform.position = child [i].transform.position;
						Debug.Log ("Power Instantiate");
						break;
					}
				}
			}
			spawnPoint = spawnPoint + lenghtGroundStraight;
			groundActive.Add (newGround);
			break;
		case typeArray.Straight:
			newGround = Instantiate (groundStraight [indexGround]) as GameObject;
			newGround.transform.SetParent (this.transform);
			newGround.transform.position = Vector3.forward * spawnPoint;
			if (Random.Range (0, 10) > 8) {
				Transform[] child = newGround.GetComponentsInChildren<Transform> ();
				for (int i = 0; i <= newGround.transform.childCount; i++) {
					if (child [i].tag == "PowerUp") {
						GameObject newPowerUp = Instantiate (powerUps [Random.Range (0, 1)]) as GameObject;
						newPowerUp.transform.SetParent (newGround.transform);
						newPowerUp.transform.position = child [i].transform.position;
						Debug.Log ("Power Instantiate");
						break;
					}
				}
			}
			spawnPoint = spawnPoint + lenghtGroundStraight;
			groundActive.Add (newGround);
			break;
		default:
			break;
		}
		//DeleteGround ();
	}

	private void DeleteGround(){
		Destroy (groundActive [0]);
		groundActive.RemoveAt (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerPos.position.z - safeZone > (spawnPoint - groundInVision * lenghtGroundStraight)) {
			InstantiateGround (Random.Range(0, groundStraight.Length), typeArray.Straight);
			DeleteGround ();
		}
	}
}
