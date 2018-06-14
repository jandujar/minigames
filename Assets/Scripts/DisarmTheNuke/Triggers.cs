using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour {

    public GameObject EnemySoldier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EnemySoldier.GetComponent<SoldierIA>().setTriggers(this.name);
        }
    }
}
