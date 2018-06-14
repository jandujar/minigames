using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbaStart : IMiniGame {
    public ZumbaGameplay zumbaObject;


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
        zumbaObject.init(gm);
    }
}
