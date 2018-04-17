using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour {
    private float move;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposy = 5.9f;
	// Update is called once per frame
	void Update () {
        move = InputManager.Instance.GetAxisVertical();

        transform.Translate(0, move * vely * Time.deltaTime, 0);

        if(transform.position.y > maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.y < -maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, -maxposy, transform.position.z);
            transform.position = tmpPosition;
        }
    }
}
