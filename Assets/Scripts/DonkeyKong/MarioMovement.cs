using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo {
    public class MarioMovement : MonoBehaviour {
        float actualMovement;
        float finalMovement;
        int direction;
        float speed;
        bool up;
        bool right;
        bool left;

        // Start is called before the first frame update
        void Start() {
            direction = -1;
            speed = 0.05f;
            up = false;
        }

        // Update is called once per frame
        void Update() {

            if(InputManager.Instance.GetAxisHorizontal() == 1) {
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

            if (left) {
                transform.position = new Vector3(transform.position.x + speed,
                                                transform.position.y, transform.position.z);
                GetComponent<Animator>().SetBool("walk", true);
                transform.localScale = new Vector3(-5, 5, 5);
            }

            else if (right) {
                transform.position = new Vector3(transform.position.x - speed,
                                                transform.position.y, transform.position.z);
                GetComponent<Animator>().SetBool("walk", true);
                transform.localScale = new Vector3(5, 5, 5);
            }

            else {
                GetComponent<Animator>().SetBool("walk", false);
            }

            if (InputManager.Instance.GetAxisVertical() > 0 && up) {
                left = false;
                right = false;
                GetComponent<Animator>().SetBool("walk", false);
                GetComponent<Animator>().SetBool("up", true);
                transform.position = new Vector3(transform.position.x,
                                                transform.position.y + speed, transform.position.z);
            }

            
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.name == "ladder") {
                up = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.gameObject.name == "ladder") {
                up = false;
                GetComponent<Animator>().SetBool("up", false);
            }
        }
    }
}