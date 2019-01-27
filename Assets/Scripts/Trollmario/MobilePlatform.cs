using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guillem_gracia
{
    public class MobilePlatform : Entity
    {
        bool move;
        public enum Directions { Left, Right, Up, Down};

        public Directions direction;
        public float speed;
        public float distance;

        Vector3 originalPosition;
        Vector2 inputMovement;

        float elapsedTime;

        guillem_gracia.Character player;

        // Start is called before the first frame update
        protected override void Start()
        {
            originalPosition = transform.position;
        }

        public override void Init()
        {
            transform.position = originalPosition;
            elapsedTime = 0;
            move = false;
        }

        // Update is called once per frame
        protected override void Update()
        {
            if (!move) return;
            elapsedTime += Time.deltaTime;
            transform.position = originalPosition + (Vector3)inputMovement * speed * elapsedTime;
            if(player != null)
                player.transform.position += (Vector3)inputMovement * speed * Time.deltaTime;

            if(transform.position.x >= originalPosition.x + distance ||
                transform.position.y >= originalPosition.y + distance ||
                transform.position.x <= originalPosition.x - distance ||
                transform.position.y <= originalPosition.y - distance)
            {
                move = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player") return;

            player = collision.gameObject.GetComponent<guillem_gracia.Character>();
            player.inputMovement.y = 0;
            player.jumping = false;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player") return;

            guillem_gracia.Character player = collision.gameObject.GetComponent<guillem_gracia.Character>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "Player") return;
            move = true;
            switch (direction)
            {
                case Directions.Up:
                    inputMovement = Vector2.up;
                    break;
                case Directions.Down:
                    inputMovement = Vector2.down;
                    break;
                case Directions.Left:
                    inputMovement = Vector2.left;
                    break;
                case Directions.Right:
                    inputMovement = Vector2.right;
                    break;
            }
        }
    }
}
