using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whacamoleHoleControl : MonoBehaviour {

    public GameObject[] holeControl;

    public whacamoleMove moleMoveControl;

    private int randomHole;
    private int randomMole;

    private void Awake()
    {
        for (int i = 0; i < 6; ++i)
        {
           holeControl[i].transform.GetChild(0).gameObject.SetActive(false);
           holeControl[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(MyUpdate());
    }

    private IEnumerator MyUpdate()
    {
        while (true)
        {
            randomHole = Random.Range(0, 1);
            switch (randomHole)
            {
                case 0:
                    randomMole = Random.Range(0, 1);
                    if (randomMole == 0)
                    {
                        Debug.Log("entra");
                        holeControl[0].transform.GetChild(0).gameObject.SetActive(true);
                        holeControl[0].transform.GetChild(0).gameObject.GetComponent<whacamoleMove>().StartCoroutine(holeControl[0].transform.GetChild(0).gameObject.GetComponent<whacamoleMove>().moveCorutine);
                    }
                    else
                    {
                        holeControl[0].transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
                case 1:
                    randomMole = Random.Range(0, 2);
                    if (randomMole == 0)
                    {
                        holeControl[1].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        holeControl[1].transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
                case 2:
                    randomMole = Random.Range(0, 2);
                    if (randomMole == 0)
                    {
                        holeControl[2].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        holeControl[2].transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
                case 3:
                    randomMole = Random.Range(0, 2);
                    if (randomMole == 0)
                    {
                        holeControl[3].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        holeControl[3].transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
                case 4:
                    randomMole = Random.Range(0, 2);
                    if (randomMole == 0)
                    {
                        holeControl[4].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        holeControl[4].transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
                case 5:
                    randomMole = Random.Range(0, 2);
                    if (randomMole == 0)
                    {
                        holeControl[5].transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        holeControl[5].transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
            }
            yield return new WaitForSeconds(3);
        }
    }









}
