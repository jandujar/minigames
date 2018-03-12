using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExitpath : MonoBehaviour {


    //PUBLIC
    public BombCableCut cableCut;
    public GameObject[] arrayExit;
    public Color colorOfBomb;
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
        this.transform.GetChild(1).gameObject.SetActive(true);
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
            //WIN
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
            //LOSE
        }
    }

}
