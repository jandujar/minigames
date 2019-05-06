using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amuchalipsis : MonoBehaviour
{

    private GameManager gameManager;
    public bool CanLose;
    public bool CanWin;
    //---------------------

    [SerializeField] GameObject Player;

    bool CanMove;
    public float speed;
    public float MoveXSecond;
    float controlH;
    float controlV;
    float lastControlH;
    float lastControlV;
    Vector3 Move;



    public void init(GameManager gm)
    {
        gameManager = gm;
        Invoke("StartGame", 4);
    }

    //enpieza el juego
    private void StartGame()
    {
        StartCoroutine(StopMotion());
        Move = new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        controlH = InputManager.Instance.GetAxisHorizontal();
        controlV = InputManager.Instance.GetAxisVertical();

        if (controlV > 0.1 && controlV >= lastControlV && CanMove)
            Move.z += speed;
        if (controlV < -0.1 && controlV <= lastControlV && CanMove)
            Move.z -= speed;
        if (controlH > 0.1 && controlH >= lastControlH && CanMove)
            Move.x += speed;
        if (controlH < -0.1 && controlH <= lastControlH && CanMove)
            Move.x -= speed;

        CanMove = false;
        lastControlH = controlH;
        lastControlV = controlV;

    }

    public IEnumerator StopMotion()
    {
        while (true)
        {

            yield return new WaitForSecondsRealtime(1f / MoveXSecond);
            CanMove = true;
            Player.transform.position = Move;
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
