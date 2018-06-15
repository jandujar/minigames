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
    private int TriangleState;
    enum Form { Cube, Triangle, Picasso};
    private Form form;


    // Use this for initialization
    void Start () {
        form = Form.Cube;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            Debug.Log("Acabar");
        }
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
            if (Input.GetButton("Fire1"))
            {
                if (form == Form.Cube){
                    Debug.Log("Now im a TRIANGLE");
                    form = Form.Triangle;
                }else if (form == Form.Triangle){
                    Debug.Log("Now im a CUBE");
                    form = Form.Cube;
                }      
            }
                if (Input.anyKeyDown)
            if (Input.GetButton("Fire2"))
            {
                if (form == Form.Cube) {
                    Rotation = new Vector3(0, 0, 90);
                    transform.Rotate(Rotation);
                    if (CubeState % 2 == 0)
                    {
                        Debug.Log("0");
                        Position = new Vector3(transform.position.x,
                         -3.65f, transform.position.z);
                        transform.position = Position;
                    }
                    if (CubeState % 2 != 0)
                    {
                        Debug.Log("1");
                        Position = new Vector3(transform.position.x,
                         -3.9f, transform.position.z);
                        transform.position = Position;
                    }
                    CubeState++;
                }
                if (form == Form.Triangle)
                {
                    if (TriangleState % 3 == 1)
                    {
                        Debug.Log("1");
                        Rotation = new Vector3(150, 0, 0);
                        transform.Rotate(Rotation);
                        Position = new Vector3(transform.position.x,
                         -4.4f, transform.position.z);
                        transform.position = Position;
                    }
                    if (TriangleState % 3 == 2)
                    {
                        Debug.Log("2");
                        Position = new Vector3(transform.position.x,
                         -3.9f, transform.position.z);
                        transform.position = Position;
                    }
                    if (TriangleState % 3 == 0)
                    {
                        Debug.Log("0");
                        Rotation = new Vector3(151.34f, 0, 0);
                        transform.Rotate(Rotation);
                        Position = new Vector3(transform.position.x,
                         -3.4f, transform.position.z);
                        transform.position = Position;
                    }
                    TriangleState++;
                }
            }
    }
}
