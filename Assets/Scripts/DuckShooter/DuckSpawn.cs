using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawn : MonoBehaviour {

    //References
    private GameManager gameManager;
    private GameObject duckPrefab;
    private Transform leftSpawn;
    private Transform rightSpawn;
    

    //Quaternion
    private Quaternion leftDuck = new Quaternion(0, 0, 0, 0);
    private Quaternion rightDuck = new Quaternion(0, -1, 0, 0);


    // Use this for initialization
    void Awake () {
        leftSpawn = transform.Find("LeftSpawn");
        rightSpawn = transform.Find("RightSpawn");
        duckPrefab = Resources.Load<GameObject>("Prefabs/DuckShooter/Duck");
	}

    public void init(GameManager gm) {
        gameManager = gm;
        Spawn();
    }

    IEnumerator SecondsToSpawn()
    {
        yield return new WaitForSeconds(1);
        Spawn();
    }

    
    private void Spawn()
    {
        float num = Random.Range(0f, 2f);
        float positionY = Random.Range(-6f, 6f);
        if (num >= 1)
        {
            Instantiate(duckPrefab, rightSpawn.position + new Vector3(0, positionY, 0), rightDuck, rightSpawn);
        }
        else if(num < 1)
        {
            Instantiate(duckPrefab, leftSpawn.position + new Vector3(0, positionY, 0), leftDuck, leftSpawn);
        }
        
        StartCoroutine(SecondsToSpawn());
    }
}
