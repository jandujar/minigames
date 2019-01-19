using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class PixelTower : IMiniGame  {
        // Start is called before the first frame update
        [SerializeField] GameObject gameLogic;
        [SerializeField] GameObject crane;
       
        public override void beginGame() {
            gameLogic.GetComponent<gameLogic>().gameStart = true;
            crane.GetComponent<moveCrane>().craneSpeed = 20;
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm) {
            gameLogic.GetComponent<gameLogic>().init(gm);
        }
    }
}
