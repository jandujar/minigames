using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez
{
    public class BulletDodge : IMiniGame
    {
        public Player player;
        public EnemyShootManager esm;
        public override void beginGame()
        {
            Debug.Log("BEGIN");
            //throw new System.NotImplementedException();
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            Debug.Log("BEGIN");
            player.init(gm);
            esm.init(gm);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
