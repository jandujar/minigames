using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez
{
    public class BulletDodge : IMiniGame
    {
        GameManager gm;
        public Player player;
        public EnemyShootManager esm;
        public override void beginGame()
        {
            Debug.Log("BEGIN");
            player.init(gm);
            //throw new System.NotImplementedException();
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager _gm)
        {
            Debug.Log("BEGIN");
            esm.init(_gm);
            gm = _gm;
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
