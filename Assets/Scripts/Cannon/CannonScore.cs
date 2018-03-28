using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonScore : MonoBehaviour {

	public int score;
	public Text scoreText; 

	void Update(){
		scoreText.text = score + "/20";
		if (score > 20) {
			score = 20;
		
		}
		if (score < 0) {
			score = 0;
		}
	}
}
