using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolfManager : IMiniGame
{
    GameManager gameManager;
    [SerializeField] GameObject[] allGameObjectsWithScript;

    int strokes;

    [SerializeField] Text txt;

    bool finished;

    public AudioSource audioWin, audioLose, audioBSO;

    bool gameInit;

    // Start is called before the first frame update
    void Start()
    {
        strokes = 3;
    }

    public override void beginGame()
    {
        foreach (GameObject go in allGameObjectsWithScript)
        {
            go.SetActive(true);
        }

        audioBSO.Play();

        Debug.Log("BeginGame");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        foreach (GameObject go in allGameObjectsWithScript)
        {
            go.SetActive(false);
        }
        gameManager = gm;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(bool win)
    {
        if (finished) return;
        audioBSO.Stop();


        finished = true;
        StartCoroutine(ChangeScene(win));
    }

    IEnumerator ChangeScene(bool win)
    {
        if (win)
        {
            audioWin.Play();
            allGameObjectsWithScript[0].GetComponent<Rigidbody2D>().gravityScale = 0;
            yield return new WaitForSecondsRealtime(audioWin.clip.length);
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
        else
        {
            yield return new WaitForSecondsRealtime(audioLose.clip.length);
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }

    public override string ToString()
    {
        return "Trollmario by ggracia";
    }
}
