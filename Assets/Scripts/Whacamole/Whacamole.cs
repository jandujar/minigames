using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whacamole : IMiniGame
{

    public WhacamoleHammer hammer;



    public override void beginGame()
    {
        //Whacamole Begins
        Debug.Log(this.ToString() + " game Begin");
        hammer.enabled = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {

    }

    public override string ToString()
    {
        return "Whacamole by David Fernandez";
    }
}