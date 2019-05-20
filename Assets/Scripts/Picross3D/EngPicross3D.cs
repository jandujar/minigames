using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngPicross3D : IMiniGame
{


    [SerializeField] GameManager gameManagerInstance;

    [SerializeField] int maxlifes;
    [SerializeField] GameObject fatherLife;

    [SerializeField] GameObject CenterPointRotator;
    [SerializeField] GameObject Canvas;

    private int lifes;
    private int badCubes;
    private int badCubesNum;


    //Timer
    float timer;
    bool enterOnce = false;


    public bool startofGame = false;

    public override void beginGame()
    {
        startofGame = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {

        gm = gameManagerInstance;

    }

    // Start is called before the first frame update
    void Start() {
        if (maxlifes <= 0) maxlifes = 3;
        lifes = maxlifes;
        badCubes = GameObject.FindGameObjectsWithTag("Walls").Length;
        //badCubesNum = GameObject.FindGameObjectsWithTag("Walls").Length;
        badCubesNum = 2;
    }

    // Update is called once per frame
    void Update() {
        if (badCubesNum <= 0)
        {
            FinalTimerBeforeResult(MiniGameResult.WIN);
        }
        else if (lifes <= 0)
        {
            FinalTimerBeforeResult(MiniGameResult.LOSE);
        }
    }

    public void SetTotalCubes() {
        badCubesNum--;
        Debug.Log("Total bad cubes: " + badCubesNum + " / " + badCubes);
     
    }

    public void SetLife() {
        lifes--;
        fatherLife.transform.GetChild(lifes).GetComponent<Animator>().SetBool("delete", true);
      
    }


    private void FinalTimerBeforeResult(MiniGameResult result)
    { 

        if (!enterOnce) {

            //deactivate things
            enterOnce = true;
            startofGame = false;
            Canvas.transform.GetChild(0).gameObject.SetActive(false);

            if (result == MiniGameResult.WIN)
            {
                timer = 10;
                CenterPointRotator.transform.rotation = Quaternion.Euler(CenterPointRotator.GetComponent<CameraOrbitation>().EulerInitRotation);
            }
            else if (result == MiniGameResult.LOSE)
            {
                timer = 2;
            }
        }

        if (result == MiniGameResult.WIN)
            CenterPointRotator.transform.Rotate(0, 20 * Time.deltaTime, 0);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            gameManagerInstance.EndGame(result);
        }
        

    }
}
