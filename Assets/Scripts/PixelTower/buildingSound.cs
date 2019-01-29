using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo { 
    public class buildingSound : MonoBehaviour {

        private bool played;
        private AudioSource buildingAudio;

        // Start is called before the first frame update
        void Start() {
            played = false;
            buildingAudio = this.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update() {
            
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (!played) {
                buildingAudio.Play();
                played = true;
            }
        }
    }
}
