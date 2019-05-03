using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class MarioMovement : MonoBehaviour {
        float speed;
        bool up;
        bool right;
        bool left;
        bool goUp;
        bool goDown;
        bool matado;
        bool walking;
        Rigidbody2D rb;
        BoxCollider2D boxCollider2D;
        bool death;
        bool tope;
        public bool start;
        private GameManager gameManager;
        

        public void init(GameManager gm) {
            gameManager = gm;
        }

        // Start is called before the first frame update
        void Start() {
            speed = 0.05f;
            start = false;
            up = false;
            goUp = false;
            tope = false;
            rb = GetComponent<Rigidbody2D>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            death = false;
            matado = false;
            
        }

        // Update is called once per frame
        void FixedUpdate() {
            
            if (start && !death) {
                if(InputManager.Instance.GetAxisHorizontal() < 1 && left) {
                    left = false;
                }

                if (InputManager.Instance.GetAxisHorizontal() > -1 && right) {
                    right = false;
                    GetComponent<Animator>().SetBool("walk", false);
                }

                if(InputManager.Instance.GetAxisHorizontal() == 0) {
                    tope = false;
                    GetComponent<Animator>().SetBool("walk", false);
                }

                if(InputManager.Instance.GetAxisVertical() == 0) {
                    GetComponent<Animator>().SetBool("stop", true);
                }

                if (InputManager.Instance.GetAxisHorizontal() > 0.1f && !goUp && !goDown) {
                    if(InputManager.Instance.GetAxisHorizontal() == 1) {
                        left = true;
                        tope = true;
                    }
                    if(!tope || tope && left) {
                        transform.position = new Vector3(transform.position.x + speed,
                                                   transform.position.y, transform.position.z);
                        GetComponent<Animator>().SetBool("walk", true);
                        transform.localScale = new Vector3(-5, 5, 5);
                    }
                }

                else if (InputManager.Instance.GetAxisHorizontal() < -0.1f && !goUp && !goDown) {
                    if (InputManager.Instance.GetAxisHorizontal() == -1) {
                        right = true;
                        tope = true;
                    }
                    if (!tope || tope && right) {
                        transform.position = new Vector3(transform.position.x - speed,
                                                    transform.position.y, transform.position.z);
                        GetComponent<Animator>().SetBool("walk", true);
                        transform.localScale = new Vector3(5, 5, 5);
                    }
                }

                

                if (InputManager.Instance.GetAxisVertical() > 0.1f && up) {
                    goUp = true;
                    left = false;
                    right = false;
                    GetComponent<Animator>().SetBool("walk", false);
                    GetComponent<Animator>().SetBool("up", true);
                    GetComponent<Animator>().SetBool("stop", false);
                    transform.position = new Vector3(transform.position.x,
                                                    transform.position.y + speed, transform.position.z);
                    boxCollider2D.isTrigger = true;
                    rb.gravityScale = 0;
                }
                if (InputManager.Instance.GetAxisVertical() < -0.1f && up) {
                    //goUp = false;
                    goDown = true;
                    left = false;
                    right = false;
                    GetComponent<Animator>().SetBool("walk", false);
                    GetComponent<Animator>().SetBool("up", true);
                    GetComponent<Animator>().SetBool("stop", false);
                    transform.position = new Vector3(transform.position.x,
                                                    transform.position.y - speed, transform.position.z);
                    boxCollider2D.isTrigger = true;
                    rb.gravityScale = 0;
                }

                if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) {
                    Debug.Log("Saltando");
                    //if (right || left) {
                        rb.AddForce(new Vector2(0, 250));
                    //}

                }
            }
            else if(matado) {
                death = true;
                left = false;
                right = false;
                up = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            Debug.Log("GameObject: " + collision.name);
            if(collision.gameObject.name == "delete") {
                Lose();
            }

            if(collision.gameObject.name == "goal") {
                Win();
            }

            if (collision.gameObject.name == "ladder") {
                up = true;
            }
            if(collision.gameObject.name == "barril" || collision.gameObject.name == "barril(Clone)") {
                GetComponent<Animator>().SetTrigger("death");
                death = true;
                matado = true;
                left = false;
                right = false;
                up = false;
                GetComponent<Animator>().SetBool("up", false);
                GetComponent<Animator>().SetBool("walk", false);
                GetComponent<Animator>().SetTrigger("death");
                Invoke("Lose", 2f);
                rb.gravityScale = 1;
            }
            if(collision.gameObject.name == "ladderCollision") {
                if (collision.gameObject.name == "ladderCollision" && goDown) {
                    goDown = false;
                    up = false;
                    goUp = false; 
                    GetComponent<Animator>().SetBool("up", false);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.gameObject.name == "ladder") {
                up = false;
                goUp = false;
                goDown = false;
                rb.gravityScale = 1;
                boxCollider2D.isTrigger = false;
                GetComponent<Animator>().SetBool("up", false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if(collision.gameObject.name == "floor" && goDown) {
                goDown = false;
                GetComponent<Animator>().SetBool("up", false);
            }
        }

        void Win() {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }

        void Lose() {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }
}