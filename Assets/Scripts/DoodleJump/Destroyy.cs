using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyy : MonoBehaviour
{
    public int Puntaje = 20;

    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    private GameObject myPlat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Random.Range(1, 6) > 1)
        {

            myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (10 + Random.Range(0.5f, 1f))), Quaternion.identity);

        } else
        {

            myPlat = (GameObject)Instantiate(springPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (10 + Random.Range(0.5f, 1f))), Quaternion.identity);

        }

        ScoreSr.scoreValue += Puntaje;

        Destroy(collision.gameObject);

    }

}
