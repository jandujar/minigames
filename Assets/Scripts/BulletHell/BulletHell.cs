using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XavierRibasDeTorres
{ 
    public class BulletHell : IMiniGame
    {

        public GameObject Game;

        private GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public override void beginGame()
        {
            Game.SetActive(true);
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            this.gameManager = gm;
            Game.SetActive(false);
        }
    }
}

