using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDetection : MonoBehaviour {

    public IngredientSpawn spawnObject;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            spawnObject.GameOver();
        }
    }
}
