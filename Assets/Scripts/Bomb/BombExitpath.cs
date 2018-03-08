using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExitpath : MonoBehaviour {

    public GameObject[] arrayExit;
    private IEnumerator bombCorutine;

    void Start()
    {
        bombCorutine = myUpdate();
        StartCoroutine(bombCorutine);
    }


    IEnumerator myUpdate()
    {
        while (true)
        {
            for (int i = 0; i < 8; i++)
            {
                if (arrayExit[i].GetComponent<Renderer>().material.color == Color.red)
                {
                    this.transform.position = new Vector3(arrayExit[i].transform.position.x, this.transform.position.y, this.transform.position.z);
                    StopCoroutine(bombCorutine);
                    yield return false;
                }
            }
            yield return true;
        }

    }

}
