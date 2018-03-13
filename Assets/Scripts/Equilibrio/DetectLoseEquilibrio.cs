using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLoseEquilibrio : MonoBehaviour {
    
    public GameObject ball;

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Equilibrio")
        {
            ball.GetComponent < BallEquilibrio >().LoseGame();
        }
    }
}
