using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingEnemyController : MonoBehaviour {


    //  PUBLIC 
    public GameManager gameManager;
    public BoxingPlayerController boxingPlayer;
    public Coroutine enemyCorutine = null;
    // PRIVATE
    private float speed = 3;
    private int lastMove;
    public AudioSource boxingBell;
    private int move;


    public void init(GameManager gm)
    {
        gameManager = gm;
    }
    // Use this for initialization
    void Start()
    {
        enemyCorutine = StartCoroutine(MiUpdate());
        boxingBell = GetComponent<AudioSource>();
    }

    IEnumerator LoseMatch()
    {
        boxingBell.Play();
        GameObject.Find("PlayerKo").transform.position = new Vector3(0, 0, 0);
        StopCoroutine(enemyCorutine);
        yield return new WaitForSeconds(2);
        GameObject.Find("PlayerKo").transform.position = new Vector3(0, 0, 25);
        Instantiate(GameObject.Find("Lose"), new Vector3(-0.2f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(2);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

    IEnumerator MiUpdate()
    {
        yield return new WaitForSeconds(3.5f);
        boxingBell.Play();
        yield return new WaitForSeconds(2);
        while (true)
        {
            if (!GameObject.Find("KO"))
            {
                GenerateRandom();
                yield return new WaitForSeconds(1);
                transform.GetChild(0).gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            if (boxingPlayer.transform.position.x == transform.position.x)
            {
                GameObject.Find("Player").SetActive(false);
                StartCoroutine(LoseMatch());
            }
            yield return new WaitForSeconds(1);
            transform.GetChild(1).gameObject.SetActive(false);
            

        }    
    }

    void GenerateRandom()
    {
        move = Random.Range(1, 3);
            
        
        if (lastMove == 1)
        {
            move = 2;
        }
        if (lastMove == -1)
        {
            move = 1;
        }
       
        switch (move)
        {
            case 1:
                transform.Translate(Vector3.right * speed);
                lastMove++;
                break;

            case 2:
                transform.Translate(Vector3.left * speed);
                lastMove--;
                break;
        }
    }
}
