using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour {
    public bool moving;
    private int direction;
    private int fallingTimes;

    // Start is called before the first frame update
    void Start() {
        moving = true;
        direction = 1;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (moving) {
            InvokeRepeating("go", 0f, 0.01f);
            moving = false;
        }
    }

    void go() {
        transform.position = new Vector3(transform.position.x + (0.05f * direction),
                                         transform.position.y, transform.position.z);
    }

    void falling() {
        if(fallingTimes < 11) {
            transform.position = new Vector3(transform.position.x,
                                         transform.position.y - 0.170545f,
                                         transform.position.z);
            fallingTimes++;
        }
        else {
            fallingTimes = 0;
            CancelInvoke("falling");
            direction *= -1;
            moving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Finish") {
            moving = false;
            CancelInvoke("go");
            InvokeRepeating("falling", 0f, 0.02f);
        }
    }
}
