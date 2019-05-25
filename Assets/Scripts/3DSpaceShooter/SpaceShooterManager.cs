using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceShooter
{
    public class SpaceShooterManager : IMiniGame
    {
        GameManager gameManager = null;
        public int score = 0;
        public int health = 0;
        [SerializeField] MonoBehaviour[] allGameObjectsWithScript = null;
        [SerializeField] TextMeshProUGUI healthText;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] GameObject hudCanvas;
        public GameObject bulletPrefab = null;

        public override void beginGame()
        {
            Debug.Log("Begin Game");
            score = 0;
            hudCanvas.SetActive(true);
            foreach (MonoBehaviour mb in allGameObjectsWithScript)
            {
                mb.enabled = true;
            }
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            Debug.Log("Init Game");
            gameManager = gm;
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
        void Update(){
            healthText.text = "Health: " + health;
            scoreText.text = "Score: " + score.ToString("00000");
            if(score >= 3000)
                EndGame(true);
        }
        public void EndGame(bool win) {
            if(win)
                gameManager.EndGame(MiniGameResult.WIN);
                
            else gameManager.EndGame(MiniGameResult.LOSE);
        }

        // Update is called once per frame
        /*void Update()
        {

        }*/
    }
}
