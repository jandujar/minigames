using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    private IngredientSpawn spawnObject;
    private bool detected = false;
    private GameObject ingredientBelow;
    public AudioClip splashClip;
    public AudioClip victoryClip;
    private AudioSource source;
    private Vector3 pos;

    private void Awake()
    {
        ingredientBelow = GetComponent<GameObject>();
        spawnObject = GameObject.Find("IngredientSpawn").GetComponent<IngredientSpawn>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (detected)
        {
            transform.position = new Vector3(ingredientBelow.transform.position.x, ingredientBelow.transform.position.y + gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2 + ingredientBelow.GetComponent<SpriteRenderer>().bounds.size.y / 2, ingredientBelow.transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!detected && coll.gameObject.tag != "Finish")
        {
            if (coll.transform.position.x + 20 > transform.position.x && coll.transform.position.x - 20 < transform.position.x)
            {
                transform.parent = coll.transform;
                pos = new Vector3(coll.transform.position.x, coll.transform.position.y + gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2 + coll.gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2, coll.transform.position.z);
                transform.position = pos;
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                ingredientBelow = coll.gameObject;
                detected = true;
                spawnObject.ingredientsCaught++;
                source.PlayOneShot(splashClip, 1f);
                if (gameObject.name == "UpBread(Clone)")
                {
                    if (spawnObject.ingredientsCaught == spawnObject.GetIngredientSize()) {
                        StartCoroutine(VictorySound());
                    }
                }
            }
            else
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    IEnumerator VictorySound()
    {
        source.PlayOneShot(victoryClip, 1f);
        yield return new WaitForSeconds(1);
        spawnObject.WinGame();
    }
}
