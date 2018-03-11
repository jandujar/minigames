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
        yield return new WaitForSeconds(2f);
        while (true)
        {
            int rando = Random.Range(0, 7);
            if (arrayExit[rando].GetComponent<Renderer>().material.color != Color.white)
            {
                this.transform.position = new Vector3(arrayExit[rando].transform.position.x, this.transform.position.y, this.transform.position.z);
                StopCoroutine(bombCorutine);
                yield return false;
            }            
            yield return true;
        }

    }

}
