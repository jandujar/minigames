using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStateManager : MonoBehaviour {
    private GameManager gameManager;

    public GameObject Player;
    public GameObject Enemy;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.GetComponent<PlayerController>().health <= 0)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        else if (Player.GetComponent<PlayerController>().isDisarmed)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
	}
}
