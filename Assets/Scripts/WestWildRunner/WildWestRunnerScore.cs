using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WildWestRunnerScore : MonoBehaviour {

	private int score;
	private int gScore;
	private Vector3 startPos;
	private GameObject player;
	private int sumSpeed;
	private int goalSpeed;

	public Text acScore;
	public Text goalScore;

	// Use this for initialization
	void Start () {
		gScore = WildWestRunnerManager.instance.getGoalScore ();
		startPos = this.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		goalSpeed = gScore / 4;
		sumSpeed = goalSpeed;
		Debug.Log ("Goal Score: " + goalSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (WildWestRunnerManager.instance.getStartGame ()) {
			score = (int)(this.transform.position - startPos).magnitude;
			acScore.text = ("Score: " + score.ToString ());
			goalScore.text = ("Goal Score: " + gScore.ToString ());
		}

		if (score >= gScore) {
			WildWestRunnerManager.instance.endGame (IMiniGame.MiniGameResult.WIN);
		}

		if (score >= sumSpeed) {
			sumSpeed += goalSpeed;
			player.GetComponent<WildWestRunnerControllerPlayer> ().addSpeed (2);
		}
	}
}
