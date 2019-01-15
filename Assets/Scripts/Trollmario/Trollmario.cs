using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guillem_gracia {

    public class Trollmario : IMiniGame
    {
        GameManager gameManager;
        

        public override void beginGame()
        {
            Debug.Log("BeginGame");
            init = true;
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
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

        // Update is called once per frame
        void Update()
        {
            if (!init) return;
            UpdateControlls();
            
        }

        void UpdateControlls()
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                EndGame(true);
            }
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                EndGame(false);
            }
        }

        public override string ToString()
        {
            return "Trollmario by ggracia";
        }
    }
}
