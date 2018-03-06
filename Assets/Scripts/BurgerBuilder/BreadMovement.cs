using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadMovement : MonoBehaviour {


    [Header("Floats")]
    public float moveSpd = 100f;
    private float move;

    //Vectors
    private Vector3 tmpPosition;

    [Header("Transform")]
    public Transform rightLimit;
    public Transform leftLimit;

	
	// Update is called once per frame
	void Update () {
        move = InputManager.Instance.GetAxisHorizontal();

        transform.Translate(move * moveSpd * Time.deltaTime, 0, 0);

        if (transform.position.x > rightLimit.position.x)
        {
            tmpPosition = new Vector3(rightLimit.position.x, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
        if (transform.position.x < leftLimit.position.x)
        {
            tmpPosition = new Vector3(leftLimit.position.x, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
    }
}
