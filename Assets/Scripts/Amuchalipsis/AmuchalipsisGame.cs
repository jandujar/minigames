using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuchalipsisGame : IMiniGame
{
    public Amuchalipsis AmuchalipsisManager;

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
        AmuchalipsisManager.init(gm);
    }

    public override string ToString()
    {
        return "Amuchalipsis by  Ivan / Mario";
    }
}
