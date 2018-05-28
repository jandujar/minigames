using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WhacamoleScore : MonoBehaviour {

    public int points = 0;
    public Text playerScoreText;

    // Use this for initialization
    void Start () {
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
	}

    void UpdateScore()
    {
        playerScoreText.text = points.ToString();
    }
}
