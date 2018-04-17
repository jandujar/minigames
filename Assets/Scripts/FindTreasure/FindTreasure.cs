using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTreasure : IMiniGame
{
    //private GameManager gameManager;
    [SerializeField]
    private GameObject canvasObject;

    [SerializeField]
    private TreasureFinder finder;

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        canvasObject.SetActive(true);
        finder.enableFinder();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        //this.gameManager = gm;
        finder.init(gm);
    }

    public override string ToString()
    {
        return "Treasure Find by Adrian";
    }
}
