using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo { 
    public class moveCrane : MonoBehaviour {
        private bool toLeft;
        private RectTransform rect;
        private float count;
        [SerializeField] float craneSpeed;

        // Start is called before the first frame update
        void Start() {
            toLeft = false;
            rect = this.GetComponent<RectTransform>();
            count = 0;
        }

        // Update is called once per frame
        void Update() {
            if (toLeft) {
                rect.position = new Vector3(rect.position.x - craneSpeed, rect.position.y, rect.position.z);
                if(rect.position.x < 32) {
                    toLeft = false;
                }
            }
            else {
                rect.position = new Vector3(rect.position.x + craneSpeed, rect.position.y, rect.position.z);
                if (rect.position.x > 1888) {
                    toLeft = true;
                }
            }
        }
    }
}
