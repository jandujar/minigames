using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseSpeed : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    private ThiefCar thief;
    private ThiefCar police;

    void Start()
    {
        thief = player.GetComponent<ThiefCar>();
        police = enemy.GetComponent<ThiefCar>();
    }
    
	void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject == player)
        {
            invertGoUp(thief);
        }
        if (col.gameObject == enemy)
        {
            invertGoUp(police);
        }
	}

    void invertGoUp(ThiefCar target)
    {
        if (target.getGoUp())
        {
            target.setGoUp(false);
        }
        else
        {
            target.setGoUp(true);
        }
        target.setVertical(true);
    }
}