using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace guillem_gracia {

    public class Trollmario : IMiniGame
    {
        GameManager gameManager;
        [SerializeField] GameObject[] allGameObjectsWithScript;

        int health;

        [SerializeField] Text txt;

        public override void beginGame()
        {
            Debug.Log("BeginGame");
            init = true;
            health = 3;
            txt.text = health + " LIVES";
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
            GameObject.Find("Collision").GetComponent<Renderer>().enabled = false;
            GameObject.Find("DieCollisions").GetComponent<Renderer>().enabled = false;
            gameManager = gm;
        }

        public void RestartGame()
        {
            if(--health <= 0)
            {
                txt.text = health + " LIVES";
                EndGame(false);
                return;
            }
            txt.text = health + " LIVES";
            for (int i = 0; i < allGameObjectsWithScript.Length; i++)
            {
                allGameObjectsWithScript[i].GetComponent<Entity>().Init();
            }

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
