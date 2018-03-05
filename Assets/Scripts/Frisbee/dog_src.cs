using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_src : MonoBehaviour {

    //Private
    private bool isRunning;
    private bool isJumping;
    private int maxDistanceToRun;
    private float startTime;
    private float distanceTototalDistanceToDestination;
    private GameManager gameManager;

    //public
    public float runingSpeed;
    public GameObject endPosition;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }


    void Start () {
        isRunning = false;
        isJumping = false;
        startTime = Time.time;
        distanceTototalDistanceToDestination = Vector3.Distance(transform.position, endPosition.transform.position);
    }

	void Update () {
        //InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)

        if (isRunning && !isJumping)
        {
            transform.Translate(runingSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A)) //el perro salta
        {
            isJumping = true;
            isRunning = false;
            endPosition.GetComponent<endPointRotation>().stopRun();
        }

        if (isJumping && !isRunning)
        {
            float currentDuration = (Time.time - startTime);
            float journeyFraction = currentDuration / distanceTototalDistanceToDestination;
            transform.position = Vector3.Lerp(transform.position, endPosition.transform.position, journeyFraction);
            if(Vector3.Distance(transform.position, endPosition.transform.position) <= 3)
            {
                isJumping = false;
            }
        }
       if(transform.position.x > maxDistanceToRun)
        {
            Debug.Log("lose");
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        

    }

    public void StartRun()
    {
        isRunning = true;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "frisbee")
        {
            Debug.Log("WIN");
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }
}
