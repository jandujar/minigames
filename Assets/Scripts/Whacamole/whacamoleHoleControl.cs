using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleHoleControl : MonoBehaviour {

    public GameObject[] holeControl;
    public WhacamoleMove[] moleMoveControl;
    public WhacamoleMove[] helmetMoveControl;
    public GameManager gameManager;
    public AudioSource vicotryAudio;
    public AudioSource moleTable;

    private int randomHole;
    private int randomMole;
    private int lastRandom = -1;


    private void Start()
    {
        StartCoroutine(MyUpdate());
    }

    private IEnumerator MyUpdate()
    {
        while (true)
        {
            randomHole = Random.Range(0, 6);
            while (randomHole == lastRandom)
            {
                randomHole = Random.Range(0, 6);
            }
            lastRandom = randomHole;
            switch (randomHole)
            {
                case 0:
                    randomMole = Random.Range(0, 3);
                    if (randomMole != 0)
                    {
                        moleMoveControl[0].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        moleMoveControl[0].StartAnimation(false);
                        moleMoveControl[0].anim.speed = 1;
                    }
                    else
                    {
                        helmetMoveControl[0].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        helmetMoveControl[0].StartAnimation(false);
                    }
                    break;
                case 1:
                    randomMole = Random.Range(0, 4);
                    if (randomMole != 0)
                    {
                        moleMoveControl[1].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        moleMoveControl[1].StartAnimation(false);
                        moleMoveControl[1].anim.speed = 1;
                    }
                    else
                    {
                        helmetMoveControl[1].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        helmetMoveControl[1].StartAnimation(false);
                    }
                    break;
                case 2:
                    randomMole = Random.Range(0, 5);
                    if (randomMole != 0)
                    {
                        moleMoveControl[2].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        moleMoveControl[2].StartAnimation(false);
                        moleMoveControl[2].anim.speed = 1;
                    }
                    else
                    {
                        helmetMoveControl[2].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        helmetMoveControl[2].StartAnimation(false);
                    }
                    break;
                case 3:
                    randomMole = Random.Range(0, 3);
                    if (randomMole != 0)
                    {
                        moleMoveControl[3].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        moleMoveControl[3].StartAnimation(false);
                        moleMoveControl[3].anim.speed = 1;
                    }
                    else
                    {
                        helmetMoveControl[3].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        helmetMoveControl[3].StartAnimation(false);
                    }
                    break;
                case 4:
                    randomMole = Random.Range(0, 2);
                    if (randomMole != 0)
                    {
                        moleMoveControl[4].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        moleMoveControl[4].StartAnimation(false);
                        moleMoveControl[4].anim.speed = 1;
                    }
                    else
                    {
                        helmetMoveControl[4].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        helmetMoveControl[4].StartAnimation(false);
                    }
                    break;
                case 5:
                    randomMole = Random.Range(0, 5);
                    if (randomMole != 0)
                    {
                        moleMoveControl[5].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        moleMoveControl[5].StartAnimation(false);
                        moleMoveControl[5].anim.speed = 1;
                    }
                    else
                    {
                        helmetMoveControl[5].StartAnimation(true);
                        yield return new WaitForSeconds(1.3f);
                        helmetMoveControl[5].StartAnimation(false);
                    }
                    break;
            }
        }
    }

   public IEnumerator FinishGame(string result)
    {
        if (result == "WIN")
        {
            moleTable.Stop();
            vicotryAudio.Play();
            yield return new WaitForSeconds(2);
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);

        }
        if (result == "LOSE")
        {
            moleTable.Stop();
            for (int i = 0; i < 6; i++)
            {
                moleMoveControl[i].gameObject.SetActive(false);
            }
            for (int x = 0; x < 6; x++)
            {
               if (helmetMoveControl[x].hit == false)
                {
                    helmetMoveControl[x].gameObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(2);
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }
}
