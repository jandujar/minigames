using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Eric_Sanchez_Verges
{
    public class GameHandler : IMiniGame
    {
        public GameObject cupPrefab, ball;
        GameObject[] cups = new GameObject[3];
        public Vector3[] cupsInitPosition = new Vector3[3];
        public Vector3[] ballInitPosition = new Vector3[3];
        int step;
       

        public override void beginGame()
        {
            throw new System.NotImplementedException();
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {
           
            for (int i = 0; i < cups.Length; i++)
            {
                cups[i] = Instantiate(cupPrefab);
                cups[i].transform.position = cupsInitPosition[i];
                cups[i].GetComponent<cupController>().currentPosition = i;

            }
            ball.transform.position = ballInitPosition[UnityEngine.Random.Range(0, 2)];
           
        }

      

        // Update is called once per frame
        void Update()
        {
            if(cups[0].GetComponent<cupController>().endPath && cups[1].GetComponent<cupController>().endPath && cups[2].GetComponent<cupController>().endPath)
            {
                
                step++;
            }

           
                for (int i = 0; i < cups.Length; i++)
                {
                    if(i == 1)cups[i].GetComponent<cupController>().moveRight();
                    else cups[i].GetComponent<cupController>().moveLeft();
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
    }
}
