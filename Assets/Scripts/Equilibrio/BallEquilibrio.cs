using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEquilibrio : MonoBehaviour {

    //public Vector2 movement;
    public bool enableBall = false;
    private GameManager gameManager;
    private float maxVel = 0.5f;

    private float move = 0.0f;
    private float currentSpeed = 0.0f;

    private Vector3 angles;

    public GameObject cube;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }
    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        angles = transform.rotation.eulerAngles;
        angles.z = cube.transform.eulerAngles.z;
        transform.rotation = Quaternion.Euler(angles);

        move = Input.GetAxis("Horizontal");
        currentSpeed = (move* Time.deltaTime) / 2;
        transform.Translate(move / 6, 0, 0);

    }
}
