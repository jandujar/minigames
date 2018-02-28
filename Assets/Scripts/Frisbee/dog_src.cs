using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_src : MonoBehaviour {



    //Private
    private GameManager gameManager;
    private float startTime;
    private float distanceTototalDistanceToDestination;
    private bool isJumping;
    private Vector3 initPos;
    private float distance;
    float x;
    float y;
    int directionEndPos;

    //Public
    public GameObject endPosition;



    public void init(GameManager gm)
    {
        gameManager = gm;
    }


    void Start () {
        initPos = transform.position;
        isJumping = false;
        startTime = Time.time;
        distanceTototalDistanceToDestination = Vector3.Distance(transform.position, endPosition.transform.position);
        distance = Vector3.Distance(endPosition.transform.position, initPos);
        x = endPosition.transform.position.x - initPos.x;
        y = endPosition.transform.position.y - initPos.y;
        directionEndPos = -1;
    }

	void Update () {
        //InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)

        if (Input.GetKeyDown(KeyCode.Space)) //el perro salta
        {
            isJumping = true;
        }

        if (isJumping)
        {
            float currentDuration = (Time.time - startTime);
            float journeyFraction = currentDuration / distanceTototalDistanceToDestination;
            transform.position = Vector3.Lerp(transform.position, endPosition.transform.position, journeyFraction);
            if(Vector3.Distance(transform.position, endPosition.transform.position) <= 3)
            {
                isJumping = false;
                endPosition.transform.Translate(x * directionEndPos, y * directionEndPos, 0);
                //endPosition.transform.eulerAngles = new Vector3(0, 0, -90);
                //int dir = endPosition.GetComponent<endPointRotation>().getDirection();
                //endPosition.GetComponent<endPointRotation>().setDirection(dir * -1);
                switchDir();
            }
        }

        /*if(win)
           {
               Debug.Log("WIN");
               gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
           }
           else
           {
               gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
           }*/

    }

    void switchDir()
    {
        if (directionEndPos == 1)
        {
            directionEndPos = -1;
        }
        else if (directionEndPos == -1)
        {
            directionEndPos = 1;
        }
    }

}
