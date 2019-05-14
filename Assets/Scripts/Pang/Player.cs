using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    public class Player : MonoBehaviour
    {
        enum State{Shooting, Walking, Idle};
        State currentState;
        float speed;
        [SerializeField] GameObject shotPrefab;
        [SerializeField] Sprite[] playerSprites;
        GameManager gm;
        public int shots;
        public Ball[] balls;
        float animUpdateTime = 0.25f;
        float shootTimer;
        public bool gameStart = false;
        public void InitPlayer(GameManager _gm)
        {
            gm = _gm;
            currentState = State.Idle;
            shootTimer = 0;
            
        }
        // Update is called once per frame
        void Update()
        {
            UpdateControls();
            UpdateAnimation();
            if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) && shots == 0 && shootTimer <= 0 && gameStart){
                Instantiate(shotPrefab, transform.position + Vector3.up, shotPrefab.transform.rotation);
                shots ++;
                currentState = State.Shooting;
                GetComponent<SpriteRenderer>().sprite = playerSprites[1];
                shootTimer = 0.5f;
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            }
            if(InputManager.Instance.GetAxisHorizontal() == 0 && currentState != State.Shooting){
                currentState = State.Idle;
                GetComponent<SpriteRenderer>().sprite = playerSprites[0];
            }
            if(InputManager.Instance.GetAxisHorizontal() != 0 && currentState != State.Shooting && currentState != State.Walking){
                GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                currentState = State.Walking;
            }
            if(shootTimer > 0){
                currentState = State.Shooting;
                shootTimer -= Time.deltaTime;
                if(shootTimer <= 0){
                    currentState = State.Idle;
                }
            }
        }
        void FixedUpdate(){
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        void UpdateControls()
        {
            if(currentState != State.Shooting){
                speed = InputManager.Instance.GetAxisHorizontal() / 5;
            }
            else{
                speed = 0;
            }
        }
        void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.name.ToLower().Contains("ball")){
                gm.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }
        void UpdateAnimation(){
            if(speed < 0){
                GetComponent<SpriteRenderer>().flipX = true;
            } 
            else if(speed > 0){
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if(animUpdateTime > 0){
                animUpdateTime -= Time.deltaTime;
                if(animUpdateTime <= 0){
                    switch(currentState){
                        case State.Walking:
                            if(GetComponent<SpriteRenderer>().sprite == playerSprites[2])
                                GetComponent<SpriteRenderer>().sprite = playerSprites[3];
                            else if(GetComponent<SpriteRenderer>().sprite == playerSprites[3])
                                GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                            break;
                        case State.Idle:
                            GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                            break;
                        case State.Shooting:
                            GetComponent<SpriteRenderer>().sprite = playerSprites[1];
                            break;
                    }
                    animUpdateTime = 0.25f;
                }
            }
        }
    }
}
