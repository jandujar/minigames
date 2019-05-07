using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolos
{
    public class Bowling : IMiniGame
    {

        public GameObject Game;
        public GameObject UIBowling;
        public GameObject Bola;

        private GameManager gameManager;
        private float force;
        private Vector3 direction;
        private BolaController Bolascript;
        private UIPlayer UIPlayerScript;
        private enum GameState { Planning, Go, ending}
        private GameState ActualState;
        

        // Start is called before the first frame update
        public override void beginGame()
        {
            Cursor.visible = false;
            
            Game.SetActive(true);
            ActualState = GameState.Planning;

        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            this.gameManager = gm;
            Game.SetActive(false);
            Bolascript = Bola.GetComponent<BolaController>();
            UIPlayerScript = UIBowling.GetComponent<UIPlayer>();
        }



        

        // Update is called once per frame
        void Update()
        {
            if(ActualState == GameState.Planning)
            {
                if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
                {

                    force = UIPlayerScript.Stop();
                    direction = new Vector3(0, 0, 1);
                    ActualState = GameState.Go;
                }
                
            }
            if(ActualState == GameState.Go)
            {
                UIBowling.SetActive(false);
                Bolascript.LauchBall(force, direction);
                
            }
            if(ActualState == GameState.ending)
            {

            }
        }
    }
}


