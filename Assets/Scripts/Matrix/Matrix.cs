using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : IMiniGame {

    public bool started = true;
    public SPlayer Player;

	// Use this for initialization
	void Start () {
        started = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void beginGame()
    {
        throw new System.NotImplementedException();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        Player.gamemanager = gm;
    }

    public override string ToString()
    {
        return "Matrix by Luka";
    }
}
