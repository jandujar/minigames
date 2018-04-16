using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacetaController : IMiniGame {
    [SerializeField]
    private GameManager gameManager;

    public GameObject Player;
    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        gameManager = gm;
        //throw new System.NotImplementedException();
    }

    public override void beginGame()
    {
       // throw new System.NotImplementedException();
    }
    // Use this for initialization
    void Start () {
        Player.GetComponent<Lanzador>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Player.GetComponent<Lanzador>().Failed == true)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        if (Player.GetComponent<Lanzador>().win == true)
        {
            //win
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }
}
