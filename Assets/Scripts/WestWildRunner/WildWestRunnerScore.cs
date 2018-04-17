using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WildWestRunnerScore : MonoBehaviour {

	private int score;
	private int gScore;
	private Vector3 startPos;

	public Text acScore;
	public Text goalScore;

	// Use this for initialization
	void Start () {
		gScore = WildWestRunnerManager.instance.getGoalScore ();
		startPos = this.transform.position;
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
	}
}
