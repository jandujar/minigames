using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    public Tilemap tilemap;

    public Vector3 playerPosition;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

            playerPosition = GameObject.Find("Player").transform.position;

            Instantiate(bomb, playerPosition, Quaternion.identity);
        }
    }
}
