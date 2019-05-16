using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.name == "Ball")
        {
            gameObject.SetActive(false);
        }
    }
}

