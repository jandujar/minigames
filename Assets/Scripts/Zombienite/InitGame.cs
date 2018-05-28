using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour {

    public GameObject character;
    public GameObject enemies;

    public void init() {
        StartCoroutine(waitInstanceCharacter(5f));
        StartCoroutine(waitInstanceEnemies(6f));
    }

    public void endGame()
    {
        enemies.SetActive(false);
    }

    IEnumerator waitInstanceCharacter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        character.SetActive(true);

    }

    IEnumerator waitInstanceEnemies(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        enemies.SetActive(true);
    }
}
