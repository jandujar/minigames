using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace joaquim_tolosa
{
    public class DoodleJump : IMiniGame
    {
        public GameManager gm;
        bool begin = false;

        // Start is called before the first frame update
        public override void beginGame()
        {
            begin = true;
        }

        // Update is called once per frame
        public override void initGame(MiniGameDificulty difficulty, GameManager gm2)
        {
            gm = gm2;
        }

        void Update()
        {
            //victoria
            if (ScoreSr.scoreValue >= 600)
            {
                gm.EndGame(IMiniGame.MiniGameResult.WIN);
            }
            if (begin)
            {
                if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4))
                {
                    //gm.EndGame(IMiniGame.MiniGameResult.WIN);
                }
                if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
                {
                    //gm.EndGame(IMiniGame.MiniGameResult.LOSE);
                }
                
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //aqui pongo la derrota
            gm.EndGame(IMiniGame.MiniGameResult.LOSE);
            //Debug.Log("hola");

        }
    }
}
