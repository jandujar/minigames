using HyperJump;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HyperJump
{
    public class BallController : IMiniGame
    {
        public float breakVelocity;
        RaycastHit hit;
        Ray ray;
        public float jumpForce;
        Rigidbody rb;
        AudioSource aScr;
        GameManager gameManager;


        private void Start()
        {
            aScr = GetComponent<AudioSource>();
            breakVelocity = -9.5f;
            rb = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            ray = new Ray(transform.position, Vector3.down);
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            if (hit.distance <= 0.30f)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce);
                aScr.Play();

            }
        }


        //void OnCollisionEnter(Collision collision)
        //{
        //    try
        //    {
        //        if (collision.gameObject.GetComponentInParent<ObstacleController>().isEnemy)
        //        {

        //            if (rb.velocity.y > breakVelocity)
        //            {
        //                collision.gameObject.GetComponentInParent<ObstacleController>().Shoot();
        //                collision.gameObject.transform.parent.GetComponentInChildren<Collider>().enabled = false;
        //                Debug.Log("I tried");
        //            }
        //            else
        //            {
        //                Debug.Log("GameOver");
        //            }
        //        }
        //    }
        //    catch { }

        //}

        private void OnTriggerEnter(Collider other)
        {
            try
            {
                if (other.gameObject.GetComponentInParent<ObstacleController>().isEnemy)
                {
                    // Debug.Log("I tried" + rb.velocity.y);
                    if (rb.velocity.y < breakVelocity)
                    {
                        other.gameObject.GetComponentInParent<ObstacleController>().isShooting = true;
                        other.gameObject.transform.parent.GetComponentInChildren<MeshCollider>().enabled = false;

                        rb.velocity = Vector3.zero;
                        rb.AddForce(Vector3.up * jumpForce);
                        other.gameObject.GetComponentInParent<ObstacleController>().isEnemy = false;
                        aScr.Play();
                    }
                    else
                    {
                        Debug.Log("GameOver");
                        EndGame(false);
                    }
                }
            }
            catch { }
        }

        public override void beginGame()
        {
            Debug.Log("BeginGame");
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            Debug.Log("InitGame");
            gameManager = gm;
        }

        void UpdateControlls()
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                EndGame(true);
            }
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                EndGame(false);
            }
        }

        public void EndGame(bool win)
        {
            if (win)
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
            else
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "GlassTube") EndGame(true);
        }

    }
}