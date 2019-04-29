using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHexagon : IMiniGame
{

    public TheHexagon theHexagon;

    void Awake()
    {
        ////Init BlckJack
        ////Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        ////Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        GetComponent<AudioSource>().Play();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        theHexagon.init(gm);
    }

    public override string ToString()
    {
        return "SuperHexagon by Mario_Her/Fer";
    }
}
