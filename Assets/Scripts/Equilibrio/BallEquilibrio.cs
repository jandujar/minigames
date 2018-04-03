using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEquilibrio : MonoBehaviour {

    public bool enableBall = false;
    private GameManager gameManager;

    private float move = 0.0f;
   // private float currentSpeed;

    private Vector3 angles;
    public GameObject cube;
    public GameObject winSprite;
    public GameObject loseSprite;
    public GameObject zoneWinLose;
   
    private bool canMoveBall;
    private bool lose;

    public void init(GameManager gm)
    {
        gameManager = gm;   
    }

    // Use this for initialization
    void Start () {
        canMoveBall = false;
        lose = false;
    }

    public void StartGame()
    {
        canMoveBall = true;

        StartCoroutine(detectWin());

    }

    IEnumerator detectWin()
    {
        yield return StartCoroutine(winCountDown());
    }

    // Update is called once per frame
    void Update () {
        if (canMoveBall)
        {
            angles = transform.rotation.eulerAngles; //equalising the rotations of ball and cube to avoid bugs when the cube is inclined
            angles.z = cube.transform.eulerAngles.z;
            transform.rotation = Quaternion.Euler(angles);

            move = Input.GetAxis("Horizontal");
            //currentSpeed = (move* Time.deltaTime) / 2;
            transform.Translate(move / 6, 0, 0);
        }


    }

    public void LoseGame()
    {
        lose = true;
        loseSprite.SetActive(true);
        StartCoroutine(LoseCorutine());        
    }

    public IEnumerator winCountDown()
    {
        yield return new WaitForSeconds(4f);
        canMoveBall = true;
        yield return new WaitForSeconds(5f);

        if (!lose)
        {
            zoneWinLose.SetActive(false);
            winSprite.SetActive(true);
            yield return new WaitForSeconds(3f);
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }

    public IEnumerator LoseCorutine()
    {
        yield return new WaitForSeconds(3f);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
}
