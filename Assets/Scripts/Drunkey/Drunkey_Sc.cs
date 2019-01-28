using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ivan_alvarez_enri
{
    public class Drunkey_Sc : IMiniGame
    {
        private GameManager gameManager;
        // Start is called before the first frame update
        public override void beginGame()
        {
            //throw new System.NotImplementedException();
        }
        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            this.gameManager = gm;
            //throw new System.NotImplementedException();
        }

    }
}
