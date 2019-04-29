using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class DonkeyKong : IMiniGame {
        
        void Awake() {
            //Init DonkeyKong
           
        }

        public override void beginGame() {
            //Pong Begins
            Debug.Log(this.ToString() + " game Begin");
            //ball.enableBall = true;
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm) {
            //ball.init(gm); 
        }

        public override string ToString() {
            return "DonkeyKong by Laura Romo";
        }
    }
}
