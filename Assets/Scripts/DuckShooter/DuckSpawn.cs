using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawn : MonoBehaviour {

    //References
    public GameObject duckPrefab;
    public Transform leftSpawn;
    public Transform rightSpawn;
    

    //Quaternion
    private Quaternion leftDuck = new Quaternion(0, 0, 0, 0);
    private Quaternion rightDuck = new Quaternion(0, -1, 0, 0);

    public void init() {
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
