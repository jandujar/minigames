using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KauboiDueru : IMiniGame
{
    private GameManager gameManager;

    [Header("Game State")]
    private bool gameStarted = false;
    public bool playerCanShoot = false;
    public bool playerHasShoot = false;
    public bool enemyShoots = false;
    public float minShootTime;
    public float maxShootTime;
    public float enemyShootCounter;
    [Header("Game Components")]
    public RevolverGun playerGun;
    public RevolverGun enemyGun;
    public Animator flagAnimator;
    public GameObject gameSceneObject;

    [Header("Game Time")]
    public int gameTime = 10;
    private bool gameSpawnStop = false;
    public Text gameWinText;

    void Start()
    {
        gameStarted = false;
        gameSceneObject.SetActive(false);
    }
    public override void beginGame()
    {
        gameStarted = true;
        //KauboiDueru Begins
        Debug.Log(this.ToString() + " game Begin");
        gameSceneObject.SetActive(true);
        StartCoroutine(gameTimer());
        StartCoroutine(shootTime());
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "Kauboi Dueru by Saltimbanqi";
    }

    private void Update()
    {
        if(gameStarted)
        {
            if ( (Input.GetKeyDown(KeyCode.Space) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2) ) && playerCanShoot == true)
                StartCoroutine(playerGun.playerShoot());
            else if ( (Input.GetKeyDown(KeyCode.Space) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2) ) && playerCanShoot == false)
                StartCoroutine(enemyGun.enemyShoot());

            if (enemyShoots)
            {
                StartCoroutine(enemyGun.enemyShoot());
                enemyShoots = false;
            }
        }
    }

    public void setEndGame()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.LOSE);
    }
    
    void setEndGameWin()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.WIN);
    }
    
    public IEnumerator gameTimer()
    {
        for(int i=gameTime;i>-1;--i)
        {
            yield return new WaitForSeconds(1f);
            if(i==0)
                gameSpawnStop = true;
            
        }
    }

    public bool getEndTime()
    {
        return gameSpawnStop;
    }

    public void setEndTime(bool _value)
    {
        gameSpawnStop = _value;
    }
    public IEnumerator endGame()
    {
        gameWinText.enabled = true;
        yield return new WaitForSecondsRealtime(2f);
        setEndGameWin();
    }

    public IEnumerator shootTime()
    {
        for(int i=0;i<3;++i)
        {
            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(minShootTime,maxShootTime));
            Debug.Log(i + 1);
        }
        Debug.Log("Player shoots now!!");
        playerCanShoot = true;
        flagAnimator.SetBool("FlagDown", true);
        yield return new WaitForSecondsRealtime(0.0000001f);
        flagAnimator.SetBool("FlagDown", false);
        //Check if player has shoot, else:
        yield return new WaitForSecondsRealtime(enemyShootCounter);
        if(!playerHasShoot)
        {
            Debug.Log("Player loses!");
            playerCanShoot = false;
            enemyShoots = true;
            Debug.LogError("BANG!");
            //Debug.Break();
            //setEndGame();
        }
    }
}
