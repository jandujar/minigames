using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    public class Pang : IMiniGame
    {
        GameManager gm;
        bool gameStart;
        public override void beginGame()
        {
            Debug.Log("BEGIN");
            for(int i = 0; i < GameObject.Find("Player").GetComponent<Player>().balls.Length; i++){
                GameObject.Find("Player").GetComponent<Player>().balls[i].gameObject.SetActive(true);
            }            
            gameStart = true;
        }
        public override void initGame(MiniGameDificulty difficulty, GameManager _gm)
        {
            gm = _gm;
            GameObject.Find("Player").GetComponent<Player>().InitPlayer(_gm);
        }
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(GameObject.FindObjectsOfType<Ball>().Length == 0 && gameStart){
                gm.EndGame(IMiniGame.MiniGameResult.WIN);
            }
        }
    }
}
