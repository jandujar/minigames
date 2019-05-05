using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    public class Player : MonoBehaviour
    {
        float speed;
        [SerializeField] GameObject shotPrefab;
        GameManager gm;
        public int shots;
        public Ball[] balls;
        public void InitPlayer(GameManager _gm)
        {
            gm = _gm;
        }
        // Update is called once per frame
        void Update()
        {
            UpdateControls();
            if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) && shots == 0){
                GameObject temp = Instantiate(shotPrefab, transform.position + Vector3.up, shotPrefab.transform.rotation);
                shots ++;
            }
        }
        void FixedUpdate(){
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        void UpdateControls()
        {
            speed = InputManager.Instance.GetAxisHorizontal() / 5;
        }
        void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.name.ToLower().Contains("ball")){
                gm.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }
    }
}
