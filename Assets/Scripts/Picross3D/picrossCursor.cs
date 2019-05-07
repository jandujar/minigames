using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picrossCursor : MonoBehaviour {

    public Texture2D cursorImage;
    bool left;
    bool right;
    bool tope;
    // Start is called before the first frame update
    void Start() {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
        bool right = false;
        bool left = false;
        bool tope = false;
    }

    // Update is called once per frame
    void Update() {
        if (InputManager.Instance.GetAxisHorizontal() > 0.1f) {
            if (InputManager.Instance.GetAxisHorizontal() == 1) {
                left = true;
                tope = true;
            }
            if (!tope || tope && left) {
                Debug.Log("Move cursor left");
            }
        }

        else if (InputManager.Instance.GetAxisHorizontal() < -0.1f) {
            if (InputManager.Instance.GetAxisHorizontal() == -1) {
                right = true;
                tope = true;
            }
            if (!tope || tope && right) {
                Debug.Log("Move cursor right");
            }
        }
    }
}
