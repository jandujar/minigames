using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        public GameObject Points1;
        public GameObject Points2;
        public GameObject Points3;
        public GameObject Points4;
        public GameObject Points5;
        public GameObject Points6;
        public GameObject Points7;
        public GameObject Points8;
        public GameObject Points9;
        public GameObject Points10;
        public GameObject UIPoints;
        public GameObject Strike;

        private TextMeshProUGUI Points1text;
        private TextMeshProUGUI Points2text;
        private TextMeshProUGUI Points3text;
        private TextMeshProUGUI Points4text;
        private TextMeshProUGUI Points5text;
        private TextMeshProUGUI Points6text;
        private TextMeshProUGUI Points7text;
        private TextMeshProUGUI Points8text;
        private TextMeshProUGUI Points9text;
        private TextMeshProUGUI Points10text;
        

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
        private int BolosTirados;
        private int BolosTotales;


        // Start is called before the first frame update
        public override void beginGame()
        {
            Cursor.visible = false;
            
            Game.SetActive(true);
            ActualState = GameState.Planning;
            intentsos = 9;
            BolosTotales = 10;
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
            Points1text = Points1.GetComponent<TextMeshProUGUI>();
            Points2text = Points2.GetComponent<TextMeshProUGUI>();
            Points3text = Points3.GetComponent<TextMeshProUGUI>();
            Points4text = Points4.GetComponent<TextMeshProUGUI>();
            Points5text = Points5.GetComponent<TextMeshProUGUI>();
            Points6text = Points6.GetComponent<TextMeshProUGUI>();
            Points7text = Points7.GetComponent<TextMeshProUGUI>();
            Points8text = Points8.GetComponent<TextMeshProUGUI>();
            Points9text = Points9.GetComponent<TextMeshProUGUI>();
            Points10text = Points10.GetComponent<TextMeshProUGUI>();
        }



        

        // Update is called once per frame
        void Update()
        {
            
            if(ActualState == GameState.Planning)
            {
                UIPoints.SetActive(false);
                hor = InputManager.Instance.GetAxisHorizontal();
                Vector3 Direct = (flecha.transform.position - Bola.transform.position).normalized;
                

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
                UIPoints.SetActive(true);


                if (seconds == 2)
                {
                    if (billasSobrantes != BolosTotales)
                    {
                        BolosTirados = BolosTotales - billasSobrantes;
                        BolosTotales = billasSobrantes;
                        
                    }else
                    {
                        BolosTirados = 0;
                    }
                        if (billasSobrantes == 0)
                    {
                        
                        
                        if(intentsos == 9)
                        {
                            Points1text.text = "X";
                            Strike.SetActive(true);
                        }
                        else if(intentsos == 8)
                        {
                            Points2text.text = "-";
                        }
                        else if(intentsos == 7)
                        {
                            Points3text.text = BolosTirados.ToString();
                        }
                        else if(intentsos == 6)
                        {
                            Points4text.text = BolosTirados.ToString();
                        }
                        else if(intentsos == 5)
                        {
                            Points5text.text = BolosTirados.ToString();
                        }
                        else if(intentsos == 4)
                        {
                            Points6text.text = BolosTirados.ToString();
                        }
                        else if(intentsos == 3)
                        {
                            Points7text.text = BolosTirados.ToString();
                        }
                        else if(intentsos == 2)
                        {
                            Points8text.text = BolosTirados.ToString();
                        }
                        else if(intentsos == 1)
                        {
                            Points9text.text = BolosTirados.ToString();
                        }
                        else
                        {
                            Points10text.text = BolosTirados.ToString();
                        }
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
                            if(intentsos == 9)
                            {
                                Points1text.text = BolosTirados.ToString();
                            }
                            else if(intentsos == 8)
                            {
                                Points2text.text = BolosTirados.ToString();
                            }
                            else if(intentsos == 7)
                            {
                                Points3text.text = BolosTirados.ToString();
                            }
                            else if (intentsos == 6)
                            {
                                Points4text.text = BolosTirados.ToString();
                            }
                            else if (intentsos == 5)
                            {
                                Points5text.text = BolosTirados.ToString();
                            }
                            else if (intentsos == 4)
                            {
                                Points6text.text = BolosTirados.ToString();
                            }
                            else if (intentsos == 3)
                            {
                                Points7text.text = BolosTirados.ToString();
                            }
                            else if (intentsos == 2)
                            {
                                Points8text.text = BolosTirados.ToString();
                            }
                            else if (intentsos == 1)
                            {
                                Points9text.text = BolosTirados.ToString();
                            }
                            else
                            {
                                Points10text.text = BolosTirados.ToString();
                            }
                            
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


