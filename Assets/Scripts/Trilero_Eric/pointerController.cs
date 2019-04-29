using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eric_Sanchez_Verges
{
    
    public class pointerController : IMiniGame
    {
        public float speed;
        public override void beginGame()
        {
            throw new System.NotImplementedException();
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            throw new System.NotImplementedException();
        }




        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float inputX = InputManager.Instance.GetAxisHorizontal();
            if (inputX != 0) transform.position = new Vector3(transform.position.x + (inputX * Time.deltaTime * speed), transform.position.y, transform.position.z);
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                Debug.Log("Button1 pressed");
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
                {
                    Debug.Log("Shooting ray");
                    if(hit.collider.name == "Cup(Clone)")
                    {
                        Debug.Log("Colision with cup");
                        bool hasBall = hit.collider.gameObject.GetComponent<cupController>().hasBall;  
                        GameObject.Find("Game").GetComponent<GameHandler>().EndGame(hasBall);
                    }
                }
            }
        }
    }
}
