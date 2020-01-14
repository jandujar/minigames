using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField]
    private SnakeKike snakeKike;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Body" || other.tag == "Wall"){
            //snakeKike.EndGame(false);

        }

    }
}
