using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace guillem_gracia
{
    public class Flag : Entity
    {
        Vector3 originalPos;
        public float offsetY;

        bool beginMove;

        bool moved;
        public float speed;

        // Start is called before the first frame update
        protected override void Start()
        {
            originalPos = transform.position;
            Init();
        }

        public override void Init()
        {
            beginMove = false;
            moved = false;
            transform.position = originalPos;
        }

        // Update is called once per frame
        protected override void Update()
        {
            if(!moved && beginMove)
            {
                MoveDown();
            }
        }

        void MoveDown()
        {
            if(transform.position.y > originalPos.y + offsetY)
            {
                transform.position += Vector3.down * (speed * Time.deltaTime);
            }
            else
            {
                moved = true;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject.Find("Game").GetComponent<Trollmario>().EndGame(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                beginMove = true;
            }
        }
    }
}
