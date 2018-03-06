using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawn : MonoBehaviour {

    [Header("Floats")]
    public float moveSpd = 0.5f;

    [Header("Transforms")]
    public Transform spawnPoint;
    public Transform leftLimit;
    public Transform rightLimit;

    [Header("Prefabs")]
    public GameObject burgerPrefab;
    public GameObject cheesePrefab;
    public GameObject baconPrefab;
    public GameObject ketchupPrefab;
    public GameObject upBreadPrefab;

    //GameManager
    private GameManager gameManager;

    //Array
    private static GameObject[] ingredients;

    //Int
    public int counter = 0;

    void Awake()
    {
        ingredients = new GameObject[5];
        ingredients.SetValue(burgerPrefab, 0);
        ingredients.SetValue(cheesePrefab, 1);
        ingredients.SetValue(baconPrefab, 2);
        ingredients.SetValue(ketchupPrefab, 3);
        ingredients.SetValue(upBreadPrefab, 4);
    }

    public void StartSpawn(GameManager gm)
    {
        gameManager = gm;
        StartCoroutine(SpawnIngredient());
    }



    IEnumerator SpawnIngredient()
    {
        float xPosition = Random.Range(leftLimit.position.x, rightLimit.position.x);
        GameObject actualIngredient = ingredients[counter];
        Instantiate(actualIngredient, new Vector3(xPosition, transform.position.y, transform.position.z), new Quaternion(0,0,0,0));
        yield return new WaitForSeconds(1);
        
        if (counter < ingredients.Length - 1)
        {
            counter++;
            StartCoroutine(SpawnIngredient());
        }
    }

    public void GameOver()
    {
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

    public void WinGame()
    {
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

}
