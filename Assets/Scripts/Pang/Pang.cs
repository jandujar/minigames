using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    public class Pang : IMiniGame
    {
        GameManager gm;
        public override void beginGame()
        {
            Debug.Log("BEGIN");
            //throw new System.NotImplementedException();
        }
        public override void initGame(MiniGameDificulty difficulty, GameManager _gm)
        {
            gm = _gm;
        }
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
