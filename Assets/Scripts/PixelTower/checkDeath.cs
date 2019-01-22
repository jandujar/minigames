using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo { 
    public class checkDeath : MonoBehaviour {
        bool check;
        [SerializeField] GameObject crane;
        // Start is called before the first frame update
        void Start() {
            check = false;
        }

        // Update is called once per frame
        void Update() {
        
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (!check) {
                check = true;
            }
            else {
                crane.GetComponent<laura_romo.moveCrane>().EndGame(false);
            }
        }
    }
}
