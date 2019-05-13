using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picrossCursor : MonoBehaviour {

    bool left;
    bool right;
    bool up;
    bool down;
    bool tope;
    bool shoot;
    float speed;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start() {
        right = false;
        left = false;
        tope = false;
        shoot = false;
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update() {
        horizontal = speed * InputManager.Instance.GetAxisHorizontal();
        vertical = speed * InputManager.Instance.GetAxisVertical();

        transform.position = new Vector3(transform.position.x + horizontal, transform.position.y + vertical, transform.position.z);
    }
}
