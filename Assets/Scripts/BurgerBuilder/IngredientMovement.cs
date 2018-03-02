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

    //Array
    private static ArrayList ingredients;

    //Int
    private int counter = 0;

    void Awake()
    {
        ingredients = new ArrayList();
        ingredients.Add(burgerPrefab);
        ingredients.Add(cheesePrefab);
        ingredients.Add(baconPrefab);
        ingredients.Add(ketchupPrefab);
        ingredients.Add(upBreadPrefab);
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnIngredient());
    }

    IEnumerator SpawnIngredient()
    {
        float xPosition = Random.Range(leftLimit.position.x, rightLimit.position.x);
        GameObject actualIngredient = (GameObject)ingredients[counter];
        Instantiate(actualIngredient, new Vector3(xPosition, transform.position.y, transform.position.z), new Quaternion(0,0,0,0));
        yield return new WaitForSeconds(1);
        if (counter < ingredients.Count - 1)
        {
            StartCoroutine(SpawnIngredient());
            counter++;
        }        
    }
}
