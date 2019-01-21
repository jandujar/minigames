using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guillem_gracia {
    public class Character : MonoBehaviour {

        Rigidbody2D rb;

        Vector2 inputMovement;
        bool inputJump;
        bool jumping;
        [SerializeField] float speed;
        [SerializeField] float jumpSpeed;

        Animator anim;

        Transform cameraTrans, backgroundTrans;

        public int collisioningX;

        float timeJumping;
        

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            cameraTrans = GameObject.Find("Camera").transform;
            backgroundTrans = GameObject.Find("BackGround").transform;
            anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (inputJump && !jumping)
            {
                timeJumping = 0;
                jumping = true;
            }
            if(jumping)
            {
                timeJumping += Time.deltaTime;
                inputMovement.y = jumpSpeed + Physics2D.gravity.y * timeJumping;
                rb.velocity = new Vector2(inputMovement.x * speed, inputMovement.y);
            }
            else 
                rb.velocity = new Vector2(inputMovement.x * speed, rb.velocity.y);
        }

        private void Update()
        {
            UpdateControlls();
            cameraTrans.position = new Vector3(transform.position.x, cameraTrans.position.y, cameraTrans.position.z);
            backgroundTrans.position = new Vector3(transform.position.x, backgroundTrans.position.y, backgroundTrans.position.z);
        }

        void UpdateControlls()
        {
            inputMovement = new Vector2(InputManager.Instance.GetAxisHorizontal(), 0);
            if(collisioningX != 0 && Mathf.Sign(inputMovement.x) == Mathf.Sign(collisioningX))
            {
                inputMovement.x = 0;
            }
            inputJump = InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1);
            SetAnimation();
        }

        void SetAnimation()
        {
            if (jumping)
            {
                anim.SetBool("Jumping", true);
                anim.SetBool("Running", false);
            }
            else if (inputMovement.Equals(Vector2.zero))
            {
                anim.SetBool("Running", false);
            }
            else
            {
                anim.SetBool("Running", true);
            }
            

            if (inputMovement.x < 0 && !jumping) transform.localScale = new Vector3(-1, 1, 1);
            else if (inputMovement.x > 0 && !jumping) transform.localScale = new Vector3(1, 1, 1);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name == "Collision" && jumping)
            {
                for(int i = 0; i < collision.contacts.Length; i++) { 
                    if (collision.contacts[i].normal.y >= 0.99f)
                    {
                        jumping = false;
                        inputMovement.y = 0;
                        rb.velocity = new Vector2(rb.velocity.x, 0);
                        anim.SetBool("Jumping", false);
                    }
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Collision")
            {
                collisioningX = 0;
                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    if (rb.velocity.y < 0 && jumping && collision.contacts[i].normal.y >= 0.99f)
                    {
                        jumping = false;
                        inputMovement.y = 0;
                        rb.velocity = new Vector2(rb.velocity.x, 0);
                        anim.SetBool("Jumping", false);
                    }
                    if(collision.contacts[i].normal.x >= 0.99f || collision.contacts[i].normal.x <= -0.99f)
                    {
                        inputMovement.x = 0;
                        collisioningX = (int)-Mathf.Sign(collision.contacts[i].normal.x);
                    }
                }
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Collision")
            {
                collisioningX = 0;

            }
        }
    }
}