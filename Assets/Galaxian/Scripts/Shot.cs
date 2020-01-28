using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        ManejadorDeSonido.Instance.playShootSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "GalaxianPlayerShot")
        {
            transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, Time.deltaTime * -speed, 0));
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
