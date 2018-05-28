using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBallInit : IMiniGame {

    public PlayerMovementRB sphere;

	public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin!");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        sphere.init(gm);
    }
}
