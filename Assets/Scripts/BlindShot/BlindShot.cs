using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace joan_serrano
{
    public class BlindShot : IMiniGame
    {
        public GameManager gm;

        bool started = false;

        public override void beginGame()
        {
            started = true;
        }
        
        public override void initGame(MiniGameDificulty dificulty, GameManager gm)
        {

        }

        void Update()
        {
            if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4) && started)
            {
                gm.EndGame(MiniGameResult.WIN);
            }
        }
    }
}

