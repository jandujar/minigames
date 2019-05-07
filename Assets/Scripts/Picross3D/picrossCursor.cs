using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picrossCursor : MonoBehaviour {

    bool left;
    bool right;
    bool up;
    bool down;
    bool tope;
    // Start is called before the first frame update
    void Start() {
        bool right = false;
        bool left = false;
        bool tope = false;
    }

    // Update is called once per frame
    void Update() {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit " + hit.collider.gameObject);
        }
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        if (InputManager.Instance.GetAxisHorizontal() > 0) {
            if (InputManager.Instance.GetAxisHorizontal() == 1) {
                left = true;
                tope = true;
            }
            if (!tope || tope && left) {
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
            }
        }

        else if (InputManager.Instance.GetAxisHorizontal() < 0) {
            if (InputManager.Instance.GetAxisHorizontal() == -1) {
                right = true;
                tope = true;
            }
            if (!tope || tope && right) {
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
                Debug.Log("Move cursor right");
            }
        }

        if (InputManager.Instance.GetAxisVertical() > 0) {
            if (InputManager.Instance.GetAxisVertical() == 1) {
                up = true;
                tope = true;
            }
            if (!tope || tope && up) {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            }
        }

        else if (InputManager.Instance.GetAxisVertical() < 0) {
            if (InputManager.Instance.GetAxisVertical() == -1) {
                down = true;
                tope = true;
            }
            if (!tope || tope && down) {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
                Debug.Log("Move cursor right");
            }
        }

        if (InputManager.Instance.GetAxisHorizontal() < 1 && left) {
            left = false;
        }

        if (InputManager.Instance.GetAxisHorizontal() > -1 && right) {
            right = false;
        }

        if (InputManager.Instance.GetAxisVertical() < 1 && up) {
            up = false;
        }

        if (InputManager.Instance.GetAxisVertical() > -1 && down) {
            down = false;
        }
    }
}
