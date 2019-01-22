using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guillem_gracia
{
    public class FallRock : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("HEY");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "Player") return;
            transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;
            transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        }
    }
}
