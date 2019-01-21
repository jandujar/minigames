using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guillem_gracia {

    public class Trollmario : IMiniGame
    {
        GameManager gameManager;
        [SerializeField] GameObject[] allGameObjectsWithScript;

        public override void beginGame()
        {
            Debug.Log("BeginGame");
            init = true;
            foreach (GameObject go in allGameObjectsWithScript)
            {
                go.SetActive(true);
            }
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            foreach (GameObject go in allGameObjectsWithScript)
            {
                go.SetActive(false);
            }
            Debug.Log("InitGame");
            gameManager = gm;
        }

        public void EndGame(bool win)
        {
            if(win)
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
            else
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }

        bool init;

        /*void UpdateControlls()
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                EndGame(true);
            }
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                EndGame(false);
            }
        }*/

        public override string ToString()
        {
            return "Trollmario by ggracia";
        }
    }
}
