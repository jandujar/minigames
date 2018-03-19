using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallRun : IMiniGame
{
    //PUBLIC VARIABLES
    public float time;


    //PRIVATE VARIABLES
    [SerializeField] private Text txt;
    private float remaining_time;




    public enum GameState
    {
        Countdown,
        Playing
    }
    public GameManager gm;



    void Start()
    {

    }
    void Update()
    {


    }

    IEnumerator CheckTimeout()
    {
        txt.text = (time).ToString();
        for (int i = 0; i < time; i++)
        {
            remaining_time = time - i;
            txt.text = remaining_time.ToString();

            yield return new WaitForSeconds(1f);

        }
        txt.text = remaining_time.ToString();


        StartCoroutine(EndLose());
    }
    IEnumerator CheckEnd()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator EndWin()
    {
        yield return new WaitForSeconds(2f);
        gm.EndGame(IMiniGame.MiniGameResult.WIN);
    }
    IEnumerator EndLose()
    {
        yield return new WaitForSeconds(0.2f);
        gm.EndGame(MiniGameResult.LOSE);
    }
    IEnumerator EndLoseLong()
    {
        yield return new WaitForSeconds(1f);
        gm.EndGame(MiniGameResult.LOSE);
    }



    public override void beginGame()
    {
        StartCoroutine(CheckTimeout());
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {

    }

    public override string ToString()
    {
        return "BallRun by Marc Alfonso";
    }
}
