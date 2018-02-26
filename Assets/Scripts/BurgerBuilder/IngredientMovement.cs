using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMovement : MonoBehaviour {

    [Header("Floats")]
    public float moveSpd = 0.5f;

    [Header("Transforms")]
    public Transform leftLimit;
    public Transform rightLimit;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * moveSpd);
        if (transform.position.x == rightLimit.position.x || transform.position.x == leftLimit.position.x) {
            moveSpd = -moveSpd;
        }
	}
}
