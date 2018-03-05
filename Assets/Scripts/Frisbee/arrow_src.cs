using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_src : MonoBehaviour {

    private int direction;
    private float angle;
    private bool hasThrow;

    public GameObject dog;
    public GameObject endpoint;
    public GameObject fresbee;

    // Use this for initialization
    void Start () {
        direction = 1;
        hasThrow = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, Time.deltaTime * 100 * direction, Space.Self);
        if (transform.rotation.z >= 0.35 && transform.rotation.z <= 0.38)
        {
            direction = -1;

        }
        else if (transform.rotation.z <= 0.05)
        {
            direction = 1;
        }

        //InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)

        if (Input.GetKeyDown(KeyCode.Space) && !hasThrow) //el perro salta
        {
            Debug.Log(hasThrow);
            dog.GetComponent<dog_src>().StartRun();
            dog.GetComponent<dog_src>().PlayStart();
            endpoint.GetComponent<endPointRotation>().startRun();
            fresbee.GetComponent<frisbee_src>().setShoot(true);
            angle = transform.eulerAngles.z;
            fresbee.GetComponent<frisbee_src>().setAngle(angle);
            hasThrow = true;
            
        }
    }
}
