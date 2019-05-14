using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amuchalipsis : MonoBehaviour
{

    private GameManager gameManager;
    public bool CanLose;
    public bool CanWin;
    //---------------------
    

    public void init(GameManager gm)
    {
        gameManager = gm;
        Invoke("StartGame", 4);
    }

    //enpieza el juego
    private void StartGame()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        controlH = InputManager.Instance.GetAxisHorizontal();
        controlV = InputManager.Instance.GetAxisVertical();

        if (controlV > 0.1 && controlV >= lastControlV)// && CanMove)
            Move.z += speed/3;
        if (controlV < -0.1 && controlV <= lastControlV)// && CanMove)
            Move.z -= speed/3;
        if (controlH > 0.1 && controlH >= lastControlH)// && CanMove)
            Move.x += speed/3;
        if (controlH < -0.1 && controlH <= lastControlH)// && CanMove)
            Move.x -= speed/3;

        //CanMove = false;
        lastControlH = controlH;
        lastControlV = controlV;
        //
        Player.transform.position = Move;

        //Rot
        if (Move.z > LastMove.z){
            Player.transform.GetChild(0).Rotate(Vector3.right, speedRot * 180 * Time.deltaTime);
        }
        if (Move.z < LastMove.z)
        {
            Player.transform.GetChild(0).Rotate(Vector3.right, -speedRot * 180 * Time.deltaTime);
        }
        if (Move.x > LastMove.x)
        {
            Player.transform.GetChild(0).Rotate(Vector3.forward, speedRot * 180 * Time.deltaTime);
        }
        if (Move.x < LastMove.x)
        {
            Player.transform.GetChild(0).Rotate(Vector3.forward, -speedRot * 180 * Time.deltaTime);
        }

        LastMove = Move;
        */

    }

    public IEnumerator StopMotion()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);

        }
    }


    public void Lose()
    {
        if (CanLose)
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
    public void Win()
    {
        if (CanWin)
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

    /*
     // "control!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            Lose();

        //"alt!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            Win();
     */
}
