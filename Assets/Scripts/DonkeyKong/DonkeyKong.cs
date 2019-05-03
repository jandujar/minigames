using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class DonkeyKong : IMiniGame {

        [SerializeField] GameObject Kong;
        [SerializeField] MarioMovement MarioMovement;
        
        void Awake() {
            //Init DonkeyKong
           
        }

        public override void beginGame() {
            //DonkeyKong Begins
            Debug.Log(this.ToString() + " game Begin");
            Kong.GetComponent<Animator>().SetBool("start", true);
            MarioMovement.start = true;
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm) {
            MarioMovement.init(gm);
        }

        public override string ToString() {
            return "DonkeyKong by Laura Romo";
        }
    }
}
