using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class SpaceShooterManager : IMiniGame
    {
        GameManager gameManager = null;
        int score = 0;
        MonoBehaviour[] allGameObjectsWithScript = null;

        public GameObject bulletPrefab = null;

        public override void beginGame()
        {
            score = 0;
            foreach (MonoBehaviour mb in allGameObjectsWithScript)
            {
                mb.enabled = true;
            }
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            gm = gameManager;
        }

        // Start is called before the first frame update
        void Start()
        {
            foreach (MonoBehaviour mb in allGameObjectsWithScript)
            {
                mb.enabled = false;
            }
            score = 0;
        }

        // Update is called once per frame
        /*void Update()
        {

        }*/
    }
}
