using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExitpath : MonoBehaviour {


    //PUBLIC
    public BombCableCut cableCut;
    public GameObject[] arrayExit;
    public Color colorOfBomb;
    public GameManager gameManager;
    //PRIVATE
    private IEnumerator bombCorutine;
    private bool Cut = false;
    private SpriteRenderer[] renderOfAllCables;
    public string nameOfBomb;

    void Start()
    {
        bombCorutine = myUpdate();
        StartCoroutine(bombCorutine);
        StartCoroutine(StartCountdown());
    }

    IEnumerator myUpdate()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            int rando = Random.Range(0, 7);
            if (arrayExit[rando].GetComponent<Renderer>().material.color != Color.white)
            {
                colorOfBomb = arrayExit[rando].GetComponent<Renderer>().material.color;
                this.transform.position = new Vector3(arrayExit[rando].transform.position.x, this.transform.position.y, this.transform.position.z);
                StopCoroutine(bombCorutine);
                yield return false;
            }            
            yield return true;
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(4);
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(0).transform.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(11.5f);
        StartCoroutine(CallEnd("LOSE"));
    }

    IEnumerator CallEnd(string end)
    {
        yield return new WaitForSeconds(0.4f);
        this.transform.GetChild(0).transform.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(1);
        if (end == "WIN")
        {
            GameObject.Find("bombWin").transform.position = Vector3.zero;
            yield return new WaitForSeconds(1);
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            yield return true;
        }
        if (end == "LOSE")
        {
            GameObject.Find("bombLose").transform.position = Vector3.zero;
            yield return new WaitForSeconds(1);
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            yield return true;
        }
    }

    void Update()
    {
        if (colorOfBomb == Color.red)
        {
            nameOfBomb = "red";
        }
        else if (colorOfBomb == Color.blue)
        {
            nameOfBomb = "blue";
        }
        else if (colorOfBomb == Color.yellow)
        {
            nameOfBomb = "yellow";
        }
        Cut = InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1);
        renderOfAllCables = FindObjectsOfType<SpriteRenderer>();
        if (colorOfBomb == cableCut.cableSelected && Cut)
        {
            for (int i = 0; i < renderOfAllCables.Length; i++)
            {
                if (renderOfAllCables[i].name == nameOfBomb)
                {
                    renderOfAllCables[i].color = colorOfBomb;
                }
            }
            this.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
            this.transform.GetChild(0).transform.GetComponent<AudioSource>().Stop();
            StartCoroutine(CallEnd("WIN"));
        }
        else if (colorOfBomb != cableCut.cableSelected && Cut)
        {
            for (int i = 0; i < renderOfAllCables.Length; i++)
            {
                if (renderOfAllCables[i].name == nameOfBomb)
                {
                    renderOfAllCables[i].color = colorOfBomb;
                }
            }
            this.transform.GetChild(0).gameObject.GetComponent<Animator>().speed = 20;
            this.transform.GetChild(0).transform.GetComponent<AudioSource>().pitch = 20;
            StartCoroutine(CallEnd("LOSE"));
        }
    }

}
