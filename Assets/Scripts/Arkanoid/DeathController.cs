using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{

    private Vector3 intiPositionBall;

    // Start is called before the first frame update
    void Start()
    {
        intiPositionBall = GameObject.Find("Ball").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Ball")
        {
            GameObject.Find("Ball").GetComponent<Transform>().position = new Vector3(intiPositionBall.x, intiPositionBall.y, intiPositionBall.z);
            GameObject.Find("Palete").GetComponent<PaleteController>().followPale = true;
            GameObject.Find("Palete").GetComponent<PaleteController>().activateBall = true;
            GameObject.Find("GameController").GetComponent<GameContoller>().lives -= 1;
            GameObject.Find("GameController").GetComponent<GameContoller>().txtLives.text = "Lives: " + GameObject.Find("GameController").GetComponent<GameContoller>().lives.ToString();
        }

      
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PowerUp1(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}
