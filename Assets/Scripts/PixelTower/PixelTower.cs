using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class PixelTower : IMiniGame  {
        // Start is called before the first frame update
        [SerializeField] GameObject crane;
       
        public override void beginGame() {
            crane.GetComponent<laura_romo.moveCrane>().gameStart = true;
            crane.GetComponent<laura_romo.moveCrane>().craneSpeed = 5;
            crane.GetComponent<AudioSource>().Play();
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm) {
            crane.GetComponent<laura_romo.moveCrane>().init(gm);
            crane.GetComponent<laura_romo.moveCrane>().winGame = false;
        }
    }
}
