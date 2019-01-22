using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XavierRibasDeTorres
{ 
    public class BulletHell : IMiniGame
    {

        public GameObject Game;

        private float VelocityBullet;

        private GameManager gameManager;
        private float TimeVelocity;

        // Start is called before the first frame update
        void Start()
        {
            VelocityBullet = 200;
            TimeVelocity = 1111;
        }

        // Update is called once per frame
        void Update()
        {
            if(GameObject.FindGameObjectWithTag("EnemyShip") == null)
            {
                gameManager.EndGame(MiniGameResult.WIN);
            }
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

        public void SetVelocityBullets(float velocity)
        {
            VelocityBullet = velocity;
        }

        public void Lose()
        {
            gameManager.EndGame(MiniGameResult.LOSE);
        }

        
        public float getVelocityBullets()
        {
            return VelocityBullet;
        }
    }
}

