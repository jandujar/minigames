using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallRun : IMiniGame
{
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



    /*IEnumerator CheckTimeout()
    {

    }*/
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

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {

    }

    public override string ToString()
    {
        return "BallRun by Marc Alfonso";
    }
}
