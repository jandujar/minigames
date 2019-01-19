using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class PixelTower : IMiniGame  {
        // Start is called before the first frame update
        [SerializeField] GameObject crane;
       
        public override void beginGame() {
            crane.GetComponent<moveCrane>().gameStart = true;
            crane.GetComponent<moveCrane>().craneSpeed = 10;
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm) {
            crane.GetComponent<moveCrane>().init(gm);
            crane.GetComponent<moveCrane>().winGame = false;
        }
    }
}
