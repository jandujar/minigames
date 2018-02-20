using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLoseEquilibrio : MonoBehaviour {

    private GameManager gameManager;
    public GameObject ball;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }
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
