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


       
        

        public override void beginGame()
        {
            Cursor.visible = false;
            Game.SetActive(true);
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            this.gameManager = gm;
            Game.SetActive(false);
        }

        

        public void Lose()
        {
            gameManager.EndGame(MiniGameResult.LOSE);
        }
        public void Win()
        {
            gameManager.EndGame(MiniGameResult.WIN);
        }

        
        

        public override string ToString()
        {
            return "BulletHell from Xavier Ribas De Torres";
        }
    }
}

