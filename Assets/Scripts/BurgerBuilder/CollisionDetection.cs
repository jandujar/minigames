using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public IngredientSpawn spawnObject;
    private bool detected = false;
    private GameObject ingredientBelow;
    private Vector3 pos;

    private void Awake()
    {
        ingredientBelow = GetComponent<GameObject>();
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
        if (!detected)
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
            }
            else
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        if (coll.gameObject.tag == "Finish")
        {
            spawnObject.GameOver();
        }
    }
}
