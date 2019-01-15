using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ivan_alvarez_enri
{
    public class Drunkey_Sc : IMiniGame
    {
        private GameManager gameManager;
        public Animator buttons;
        public GameObject Player;
        private bool StartInputs = false;
        private bool Begin = false;
        private float xDir= 1;
        private float yDir= 1;

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            
            this.gameManager = gm;
            Player = GameObject.FindGameObjectWithTag("Player");
            //throw new System.NotImplementedException();
        }

        public override void beginGame()
        {
            Begin = true;
            StartCoroutine(changeX(2));
            StartCoroutine(changeY(1));
            //throw new System.NotImplementedException();
        }
        private void Update()
        {
        if (Begin) { 
            if (!StartInputs)
            {
                InitAnimation();
            }
            else
            {

            }
                Player.transform.Translate(new Vector3(0.02F*xDir,0.02F*yDir, 0));
            }
        }
        public void InitAnimation() { 
           
            if (Player.transform.position.y<-27F){
                Player.transform.Translate(new Vector3(0, 0.2F, 0));
            }
            else
            {
                StartInputs = true;
            }
        }
        IEnumerator changeX(float time)
        {
            yield return new WaitForSeconds(time);
            xDir *= -1;
            StartCoroutine(changeX(6));
        }
        IEnumerator changeY(float time)
        {
            yield return new WaitForSeconds(time);
            yDir *= -1;
            StartCoroutine(changeY(3));
        }


    }
}
