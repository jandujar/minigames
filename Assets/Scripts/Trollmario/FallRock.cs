using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guillem_gracia
{
    public class FallRock : Entity
    {
        Vector3 originalPos;

        public float timeAlive;

        public bool alive, fall;

        // Start is called before the first frame update
        protected override void Start()
        {
            originalPos = transform.GetChild(0).position;
            Init();
        }

        public override void Init()
        {
            timeAlive = 2f;
            transform.GetChild(0).position = originalPos;
            transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 0;
            fall = false;
            alive = true;
        }

        protected override void Update()
        {
            base.Update();
            if(alive && fall)
            {
                timeAlive -= Time.deltaTime;
                if (timeAlive <= 0)
                {
                    alive = false;
                    transform.GetChild(0).position = originalPos;
                    transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 0;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "Player") return;
            if (!fall && alive)
            {
                transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;
                transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
                fall = true;
                timeAlive = 1f;
            }
        }
    }
}
