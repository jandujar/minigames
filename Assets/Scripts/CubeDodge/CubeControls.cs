using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControls : MonoBehaviour {

    [Header("Player Variables")]
    public float Velocity = 100f;
    public Transform MaxMovementL;
    public Transform MaxMovementR;

    private float move;
    private Vector3 Position;
    private Vector3 Rotation;
    private int CubeState;
    enum Form { Cube, Triangle, Picasso};
    private Form form;


    // Use this for initialization
    void Start () {
        form = Form.Cube;
    }
	
	// Update is called once per frame
	void Update () {

        move = InputManager.Instance.GetAxisHorizontal();
        transform.Translate(move * Velocity * Time.deltaTime, 0, 0, Space.World);

        if (transform.position.x > MaxMovementR.position.x)
        {
            Position = new Vector3(MaxMovementR.position.x, 
                    transform.position.y, transform.position.z);
            transform.position = Position;       
        }
        if (transform.position.x < MaxMovementL.position.x)
        {
            Position = new Vector3(MaxMovementL.position.x, 
                    transform.position.y, transform.position.z);
            transform.position = Position;
        }

        if (Input.anyKeyDown)  
            if (Input.GetButton("Fire2"))
            {
                if (form == Form.Cube) {
                    Rotation = new Vector3(0, 0, 90);
                    transform.Rotate(Rotation);
                    if (CubeState % 2 == 0)
                    {
                        Position = new Vector3(transform.position.x,
                         -3.65f, transform.position.z);
                        transform.position = Position;
                    }
                    if (CubeState % 2 != 0)
                    {
                        Position = new Vector3(transform.position.x,
                         -3.9f, transform.position.z);
                        transform.position = Position;
                    }
                    CubeState++;
                }
                if (form == Form.Triangle)
                {
                    /*Rotation = new Vector3(0, 0, 90);
                    transform.Rotate(Rotation);
                    if (CubeState % 2 == 0)
                    {
                        Position = new Vector3(transform.position.x,
                         -3.65f, transform.position.z);
                        transform.position = Position;
                    }
                    if (CubeState % 2 != 0)
                    {
                        Position = new Vector3(transform.position.x,
                         -3.9f, transform.position.z);
                        transform.position = Position;
                    }
                    CubeState++;*/
                }
            }
    }
}
