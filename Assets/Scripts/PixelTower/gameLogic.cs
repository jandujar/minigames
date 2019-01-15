using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogic : MonoBehaviour {
    public bool gameStart;
    private GameManager gameManager;

    public void init(GameManager gm) {
        gameManager = gm;
    }

    // Start is called before the first frame update
    void Start() {
        gameStart = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if (gameStart) {
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
        }

        else if (Input.GetButtonDown("Fire2")) {
            if (gameStart) {
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }
    }
}
