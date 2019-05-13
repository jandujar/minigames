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
        public GameObject BolaFuera;
        public GameObject flecha;
        public GameObject Comprobador;

        private GameManager gameManager;
        private float force;
        private Vector3 direction;
        private BolaController Bolascript;
        private UIPlayer UIPlayerScript;
        private ComprobarBillas ComprobadorScript;
        private BolaFuera BolaFueraScript;
        private enum GameState { Planning, Go, ending}
        private GameState ActualState;
        private float hor;
        private int billasSobrantes;
        private float time;
        private float seconds;
        private int intentsos;
        private Vector3 startpos;


        // Start is called before the first frame update
        public override void beginGame()
        {
            Cursor.visible = false;
            
            Game.SetActive(true);
            ActualState = GameState.Planning;
            intentsos = 1;
            startpos = Bola.transform.position;

        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            this.gameManager = gm;
            Game.SetActive(false);
            Bolascript = Bola.GetComponent<BolaController>();
            UIPlayerScript = UIBowling.GetComponent<UIPlayer>();
            ComprobadorScript = Comprobador.GetComponent<ComprobarBillas>();
            BolaFueraScript = BolaFuera.GetComponent<BolaFuera>();
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
                
                ComprobadorScript.activate();
                billasSobrantes = ComprobadorScript.BolosCant;
                time += Time.deltaTime;
                seconds = (int)time % 60;
                if (seconds == 2)
                {
                    if (billasSobrantes == 0)
                    {
                        
                        Debug.Log("Strike!!!");
                        win();
                    }
                    else
                    {
                        
                        if(intentsos == 0)
                        {
                            lose();
                        }
                        else
                        {
                            Debug.Log(billasSobrantes);
                            secondintent();

                        }
                    }
                }
            }
        }

        private void secondintent()
        {
            ComprobadorScript.restart();
            BolaFueraScript.restart();
            Bola.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Bola.transform.position = startpos;
            ActualState = GameState.Planning;
            UIBowling.SetActive(true);
            time = 0;
            seconds = 0;
            intentsos -= 1;

        }

        private void win()
        {
            gameManager.EndGame(MiniGameResult.WIN);
        }

        private void lose()
        {
            gameManager.EndGame(MiniGameResult.LOSE);
        }

        public void Next()
        {
            ActualState = GameState.ending;
        }
    }
}


