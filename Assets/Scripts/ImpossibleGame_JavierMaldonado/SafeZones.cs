using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZones : MonoBehaviour
{
    public bool IsEndGame;
    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }




    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            pos.z = collision.gameObject.transform.position.z;
            GameObject.Find("Game").GetComponent<ImpGameEng>().lastSafePlace = pos;
            if (IsEndGame)
            {
                Debug.Log("END");
                GameObject.Find("Game").GetComponent<ImpGameEng>().WIN = true;
            }
        }


        //here we safe the listofcoins to the previous state
    }

}
