using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbaStart : IMiniGame {
    private GameManager gameManager;

	// Use this for initialization
	void Awake () {
        Debug.Log("Maded by Fabio Scarcella");
	}

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game begins");
    }

    public override void initGame(MiniGameDificulty dificulty, GameManager gm)
    {
        this.gameManager = gm;
        //call functions to start the game
    }

    // Update is called once per frame
    void Update () {
		
	}
}
