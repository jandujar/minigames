using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

    private GameManager gameManager;
    public GameObject nail;
    private int direction;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }


    // Use this for initialization
    void Start () {
        direction = 1;
    }
	
	// Update is called once per frame
	void Update () {

        nail.transform.Rotate(0, 0, Time.deltaTime * 10 * direction, Space.World);

        if (nail.transform.rotation.z >= 120 && nail.transform.rotation.z <= 130)
        {
            direction = -1;
            Debug.Log("menos");

        }else if(nail.transform.rotation.z <= -115 && nail.transform.rotation.z >= -125)
        {
            direction = 1;
            Debug.Log("mas");
        }

        

    }
}
