using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    private float moveVer;
    private float moveHor;
    public float spd = 10;
    public float maxposy = 5.9f;
    public float maxposx = 10f;
    private Vector3 tmpPosition;
    public EndTheWorld gameEngine;
	
	// Update is called once per frame
	void Update () {

        moveVer = InputManager.Instance.GetAxisVertical();
        moveHor = InputManager.Instance.GetAxisHorizontal();

        transform.Translate(0, moveVer * spd * Time.deltaTime, 0);
        transform.Translate(moveHor * spd * Time.deltaTime, 0, 0);

        //Buscar script camera follow

        if (transform.position.y > maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x > maxposx)
        {
            tmpPosition = new Vector3(maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.y < -maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, -maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x < -maxposx)
        {
            tmpPosition = new Vector3(-maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
    }
}
