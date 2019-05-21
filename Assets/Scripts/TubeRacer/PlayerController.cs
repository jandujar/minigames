using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eric_Sanchez_Verges
{
    public class PlayerController : IMiniGame
    {
        [SerializeField]float speed;
        [SerializeField] GameManager gameManager;
        float x, y, z = 0f;
        float angularSpeed = 0f;

        Vector3 rotation;
        private void Start()
        {
            transform.position = Vector3.right;
        }
        // Update is called once per frame
        void Update()
        {
            transform.RotateAround(Vector3.zero,Vector3.forward, angularSpeed);

        }

        private void FixedUpdate()
        {
            //x = Mathf.Cos(angularSpeed);
            //y = Mathf.Sin(angularSpeed);
            //transform.position = new Vector3(x, y, z);
            //rotation = transform.rotation.eulerAngles;
            //rotation += Vector3.forward * Input.GetAxisRaw("Horizontal") * 5.73f;
            //transform.rotation = Quaternion.Euler(rotation);
            if (angularSpeed <= 20 && InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) angularSpeed = Time.deltaTime * speed;
            else if (angularSpeed >= -20 && InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)) angularSpeed = Time.deltaTime * speed * -1;
            else angularSpeed = 0;

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "WinWall") EndGame(true);
            else EndGame(false);
        }

    }
}
