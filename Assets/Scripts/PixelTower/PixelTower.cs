using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class PixelTower : IMiniGame  {
        // Start is called before the first frame update
        [SerializeField] GameObject gameLogic;
                
        public override void beginGame() {
            gameLogic.GetComponent<gameLogic>().gameStart = true;
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm) {
            gameLogic.GetComponent<gameLogic>().init(gm);
        }
    }
}
