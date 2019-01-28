using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ivan_alvarez_enri
{
    public class Drunkey_Sc : IMiniGame
    {
        public GameManager gameManager;
        public Animator buttons;
        public GameObject Player;
        //private GameObject Camera;
        public bool StartInputs = false;
        public bool Begin = false;
        public bool lose=false;
        public bool win=false;
        public float xDir= 1;
        public float yDir= 1;
        public Text DecorativeText;
        public Transform mySprite;

        public AudioSource Audio;
        Buttons CorrectBtn;

        IEnumerator currentCoroutineX, currentCoroutineY;
         public float Color=0;
        public float dirColor=1;
        private enum Buttons
        {
            A,
            B
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            
            this.gameManager = gm;
            Player = GameObject.FindGameObjectWithTag("Player");
            Audio=GetComponent<AudioSource>();
            
            //Camera=GameObject.FindGameObjectWithTag("MainCamera");
            //throw new System.NotImplementedException();
        }

        public override void beginGame()
        {
            Audio.Play();
            Begin = true;
            currentCoroutineX = changeX(2);
            StartCoroutine(currentCoroutineX);
            currentCoroutineY = changeY(1);
            StartCoroutine(currentCoroutineY);
            //throw new System.NotImplementedException();
        }
        private void Update()
        {
            if(!lose&&!win){
                if (Begin) { 
                    if (!StartInputs)
                    {
                        InitAnimation();
                    }
                    else
                    {
                        if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)){
                            CorrectBtn=Buttons.B;
                            buttons.SetBool("ButtonA",false);
                            buttons.SetBool("ButtonB",true);
                            Player.transform.Translate(new Vector3(0,1, 0));
                            Begin=false;
                        }else if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)){
                            CorrectBtn=Buttons.A;
                            buttons.SetBool("ButtonA",true);
                            buttons.SetBool("ButtonB",false);
                            Player.transform.Translate(new Vector3(0,1, 0));
                            Begin=false;
                        }
                    }
                        
                    }
                else{
                        if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)&&CorrectBtn==Buttons.A){
                            CorrectBtn=Buttons.B;
                            buttons.SetBool("ButtonA",false);
                            buttons.SetBool("ButtonB",true);
                            Player.transform.Translate(new Vector3(0,1, 0));
                            
                        }else if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)&&CorrectBtn==Buttons.A){
                            Player.transform.Translate(4,0,0);
                        }else if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)&&CorrectBtn==Buttons.B){
                            CorrectBtn=Buttons.A;
                            buttons.SetBool("ButtonA",true);
                            buttons.SetBool("ButtonB",false);
                            Player.transform.Translate(new Vector3(0,1, 0));
                            
                        }else if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)&&CorrectBtn==Buttons.B){
                            Player.transform.Translate(-4,0,0);
                        }
                    }
                    if(Color<=0){
                        dirColor=1;
                    }else if(Color>=0.5){
                        dirColor=-1;
                    }
                    Color+=dirColor/100;
                    DecorativeText.color=new Color(255,Color,0);
            }else if(lose){
                StopCoroutine(currentCoroutineX);
                StopCoroutine(currentCoroutineY);


            }else if(win){
                StopCoroutine(currentCoroutineX);
                StopCoroutine(currentCoroutineY);


            }
            if(!win)
                Player.transform.Translate(new Vector3(0.02F*xDir,0.02F*yDir, 0));
                mySprite.Rotate(0,0,-xDir/10);
                    //Camera.transform.Translate(new Vector3(0.02F*xDir/10,0, 0));
        }
        public void InitAnimation() { 
           
            if (Player.transform.position.y<-20F){
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
            currentCoroutineX = changeX(6);
            StartCoroutine(currentCoroutineX);
        }
        IEnumerator changeY(float time)
        {
            yield return new WaitForSeconds(time);
            yDir *= -1;
            if(Begin){
                currentCoroutineY = changeY(3);
                StartCoroutine(currentCoroutineY);
            }
            else{
                yDir=-1;
            }
        }


    }
}
