using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Eric_Sanchez_Verges
{
    public class GameHandler : IMiniGame
    {
        GameManager gameManager;
        public Camera cam;
        public GameObject cupPrefab, ball;
        GameObject[] cups = new GameObject[3];
        public Vector3[] cupsInitPosition = new Vector3[3];
        public Vector3[] ballInitPosition = new Vector3[3];
        int step;
        public float showVel = 5f;
        public Vector2[] movements = new Vector2[10];
        int movementsIterator = 0;
        bool startMovements = false;
        bool test = false;
        bool init;


        public override void beginGame()
        {
            Debug.Log("BeginGame");
            init = true;
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            Debug.Log("InitGame");
            gameManager = gm;
        }

        void UpdateControlls()
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                EndGame(true);
            }
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                EndGame(false);
            }
        }

        public void EndGame(bool win)
        {
            if (win)
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
            else
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            startMovements = false;


            for (int i = 0; i < cups.Length; i++)
            {
                cups[i] = Instantiate(cupPrefab);
                cups[i].transform.position = cupsInitPosition[i];
                cups[i].GetComponent<cupController>().currentPosition = i;
            }
            int rand = UnityEngine.Random.Range(0, 2);
            cups[rand].GetComponent<cupController>().hasBall = true;
            ball.transform.position = ballInitPosition[rand];
           
        }

      

        // Update is called once per frame
        void Update()
        {
            if(!startMovements)StartCoroutine(showBall());
            if(!startMovements)StartCoroutine(StartMovements());
            if (startMovements && !test)
            {
                ball.SetActive(false);
                switch (step)
                {
                    case 0:
                        test = shufle(0, 1);
                        break;

                    case 1:
                        test = shufle(1, 2);
                        break;

                    case 2:
                        test = shufle(0, 1);
                        break;

                    case 3:
                        test = shufle(1, 2);
                        break;

                    case 4:
                        test = shufle(0, 1);
                        break;
                }
                
            }
             
            if (test)
            {
                test = false;
                step++;
            }

            if (Input.GetMouseButton(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    for (int i = 0; i < cups.Length; i++)
                    {
                        if (hit.collider.gameObject == cups[i])
                        {
                            if (cups[i].GetComponent<cupController>().hasBall)
                            {
                                EndGame(true);
                            }
                            else
                            {
                                EndGame(false);
                            }
                            Debug.Log("Hit on" + hit.collider.gameObject.name);
                        }
                    }

                }
            }
            
        }

        private void OnDrawGizmos()
        {
           
            for (int i = 0; i < cupsInitPosition.Length;i++)
            {
                Gizmos.color = new Color(1, 0, 0, 0.5f);
                Gizmos.DrawCube(cupsInitPosition[i], new Vector3(1,1,1));
                Gizmos.color = new Color(0, 1, 0, 0.5f);
                Gizmos.DrawSphere(ballInitPosition[i], 0.25f);
            }
        }

        IEnumerator showBall()
        {
            yield return new WaitForSeconds(5);
            for(int i = 0; i < cups.Length; i++)
            {
                cups[i].transform.position = Vector3.MoveTowards(cups[i].transform.position, new Vector3(cups[i].transform.position.x, 0.04f, cups[i].transform.position.y), showVel * Time.deltaTime);  
            }
        }

        bool shufle(int firstC, int secondC)
        {
                cups[firstC].GetComponent<cupController>().moveRight();
                return cups[secondC].GetComponent<cupController>().moveLeft();
        }
        
        IEnumerator StartMovements()
        {
            
            yield return new WaitForSeconds(6);
            startMovements = true;

           

        }
        void makeMovements()
        {
            int x = Mathf.RoundToInt(movements[movementsIterator].x);
            int y = Mathf.RoundToInt(movements[movementsIterator].y);
            bool pass = shufle(x, y);
            Debug.Log("True");
            if (pass && movementsIterator < movements.Length)
            {
                movementsIterator++;
                Debug.Log("True");
            }
        }

       

       
    }
}
