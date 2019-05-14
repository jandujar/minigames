using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picrossCursor : MonoBehaviour {

    float speed;
    float horizontal;
    float vertical;
    bool moving;
    // Start is called before the first frame update
    void Start() {
        speed = 0.01f;
        moving = false;
    }

    // Update is called once per frame
    void Update() {
        if (!moving) {
            horizontal = speed * InputManager.Instance.GetAxisHorizontal();
            vertical = speed * InputManager.Instance.GetAxisVertical();

            transform.position = new Vector3(transform.position.x + horizontal, transform.position.y + vertical, transform.position.z);
        }
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)) {
            moving = true;
        }
        else if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON3)) {
            moving = false;
        }
    }
}
