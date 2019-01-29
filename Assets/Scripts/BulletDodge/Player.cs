using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez
{
    public class Player : MonoBehaviour
    {
        private GameManager gameManager;
        float xSpeed;
        float ySpeed;

        public void init(GameManager gm)
        {
            GetComponent<AudioSource>().Play();
            gameManager = gm;
        }

        void Update()
        {
            UpdateControls();

            transform.position = new Vector3(transform.position.x + xSpeed, transform.position.y + ySpeed, transform.position.z);
        }

        void UpdateControls()
        {
            xSpeed = InputManager.Instance.GetAxisHorizontal() / 75;
            ySpeed = InputManager.Instance.GetAxisVertical() / 75;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("BBBB");
            if (collision.gameObject.name.Contains("Bullet"))
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
                Debug.Log("AAAA");
            }
        }
    }
}
