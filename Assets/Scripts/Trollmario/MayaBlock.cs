using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayaBlock : MonoBehaviour
{
    public float waitTime;
    bool fall;
    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0, 0);
        fall = false;
    }

    private void Update()
    {
        if (!fall) return;

        waitTime -= Time.deltaTime;
        if(waitTime < 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fall = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        fall = true;
    }
}
