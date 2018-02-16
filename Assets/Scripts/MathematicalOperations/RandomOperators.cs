using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOperators : MonoBehaviour {

    public GameObject[] aOperators = new GameObject[2];
    private GameManager gameManager;
    int rand = 0;
    char op = ' ';

    public void init(GameManager gm)
    {
        gameManager = gm;
        rand = (int)Random.Range(0f, 2f);
        if (rand == 0)
        {
            op = '-';
        }
        else
        {
            op = '+';
        }

        aOperators[rand].gameObject.SetActive(true);

        MathematicalOperations.instance.setOperatorInList(op);
    }

  /*  void Start()
    {
        //Init Game    

        rand = (int)Random.Range(0f, 2f);
        if(rand == 0)
        {
            op = '-';
        }else
        {
            op = '+';
        }

        aOperators[rand].gameObject.SetActive(true);

        MathematicalOperations.instance.setOperatorInList(op);
    }*/
}
