using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class MarioMovement : MonoBehaviour {
        float actualMovement;
        float speed;
        bool up;
        bool right;
        bool left;
        bool goUp;
        bool jump;
        Rigidbody2D rb;
        BoxCollider2D boxCollider2D;
        float velocityJump;
        bool death;

        // Start is called before the first frame update
        void Start() {
            speed = 0.05f;
            up = false;
            goUp = false;
            jump = false;
            rb = GetComponent<Rigidbody2D>();
            velocityJump = 0;
            boxCollider2D = GetComponent<BoxCollider2D>();
            death = false;
        }

        // Update is called once per frame
        void FixedUpdate() {
            if (!death) {
                if (InputManager.Instance.GetAxisHorizontal() == 1) {
                    left = true;
                    right = false;
                }

                else if (InputManager.Instance.GetAxisHorizontal() == -1) {
                    left = false;
                    right = true;
                }

                else {
                    left = false;
                    right = false;
                }

                actualMovement = InputManager.Instance.GetAxisHorizontal();

                if (left && !goUp) {
                    transform.position = new Vector3(transform.position.x + speed,
                                                    transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetBool("walk", true);
                    transform.localScale = new Vector3(-5, 5, 5);
                }

                else if (right && !goUp) {
                    transform.position = new Vector3(transform.position.x - speed,
                                                    transform.position.y, transform.position.z);
                    GetComponent<Animator>().SetBool("walk", true);
                    transform.localScale = new Vector3(5, 5, 5);
                }

                else {
                    GetComponent<Animator>().SetBool("walk", false);
                }

                if (InputManager.Instance.GetAxisVertical() > 0 && up) {
                    goUp = true;
                    left = false;
                    right = false;
                    GetComponent<Animator>().SetBool("walk", false);
                    GetComponent<Animator>().SetBool("up", true);
                    transform.position = new Vector3(transform.position.x,
                                                    transform.position.y + speed, transform.position.z);
                    boxCollider2D.isTrigger = true;
                    rb.gravityScale = 0;
                }

                if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) {
                    Debug.Log("Saltando");
                    if (right || left && !up) {
                        rb.AddForce(new Vector2(0, 250));
                        jump = false;
                    }

                }
            }
            else {
                death = true;
                left = false;
                right = false;
                up = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.name == "ladder") {
                up = true;
            }
            if(collision.gameObject.name == "barril") {
                GetComponent<Animator>().SetTrigger("death");
                death = true;
                left = false;
                right = false;
                up = false;
                rb.gravityScale = 1;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.gameObject.name == "ladder") {
                up = false;
                goUp = false;
                rb.gravityScale = 1;
                boxCollider2D.isTrigger = false;
                GetComponent<Animator>().SetBool("up", false);
            }
        }
    }
}