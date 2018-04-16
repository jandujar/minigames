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

    private bool playerPass = false;
    private bool enemyPass = false;

    void Start()
    {
        thief = player.GetComponent<ThiefCar>();
        police = enemy.GetComponent<ThiefCar>();
    }
    
	void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject == player && !playerPass)
        {
            invertGoUp(thief);
            playerPass = true;
        }
        if (col.gameObject == enemy && !enemyPass)
        {
            invertGoUp(police);
            enemyPass = true;
        }
	}

    void invertGoUp(ThiefCar target)
    {
        if (target.getGoUp())
        {
            target.setGoUp(false);
            rotateInverse(target.gameObject.transform.GetChild(0).gameObject, 180);
        }
        else
        {
            target.setGoUp(true);
            rotateInverse(target.gameObject.transform.GetChild(0).gameObject, 0);
        }
        target.setVertical(true);
    }

    void rotateInverse(GameObject target, float rotation)
    {
        target.transform.eulerAngles = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.y, rotation);
    }
}