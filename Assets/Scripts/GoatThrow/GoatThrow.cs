using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatThrow : IMiniGame
{
    private GameManager gameManager;
    public CabraController cabra;
    public override void beginGame()
    {
        
        Debug.Log(this.ToString() + " game Begin");
        cabra.enabled = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        cabra.init(gm);
    }

    public override string ToString()
    {
        return "GoatThrow by Roger";
    }
}
