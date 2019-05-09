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
        public GameObject flecha;
        public GameObject Comprobador;

        private GameManager gameManager;
        private float force;
        private Vector3 direction;
        private BolaController Bolascript;
        private UIPlayer UIPlayerScript;
        private ComprobarBillas ComprobadorScript;
        private enum GameState { Planning, Go, ending}
        private GameState ActualState;
        private float hor;
        private int billasSobrantes;
        

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
            ComprobadorScript = Comprobador.GetComponent<ComprobarBillas>();
        }



        

        // Update is called once per frame
        void Update()
        {
            
            if(ActualState == GameState.Planning)
            {

                hor = InputManager.Instance.GetAxisHorizontal();
                Vector3 Direct = (flecha.transform.position - Bola.transform.position).normalized;
                Quaternion LookRotation = Quaternion.LookRotation(Direct); 

                if(hor > 0)
                {
                    flecha.transform.RotateAround(Bola.transform.position, Vector3.up, 1);
                }
                if (hor < 0)
                {
                    flecha.transform.RotateAround(Bola.transform.position, Vector3.up, -1);
                }

                if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
                {
                    
                    
                    force = UIPlayerScript.Stop();
                    direction = new Vector3(Direct.x, 0, Direct.z);
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
                Debug.Log("Ending");
                ComprobadorScript.activate();
                billasSobrantes = ComprobadorScript.BolosCant;
                if (billasSobrantes == 0)
                {
                    Debug.Log(ComprobadorScript.active);
                    Debug.Log("Strike!!!");
                }
                else
                {
                    Debug.Log(billasSobrantes);
                }
            }
        }

        public void Next()
        {
            ActualState = GameState.ending;
        }
    }
}


