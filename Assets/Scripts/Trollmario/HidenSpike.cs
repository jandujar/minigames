using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guillem_gracia
{
    public class HidenSpike : Entity
    {
        public MobilePlatform.Directions direction;

        // Start is called before the first frame update
        protected override void Start()
        {
            switch(direction)
            {
                case MobilePlatform.Directions.Up:
                    transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case MobilePlatform.Directions.Down:
                    transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case MobilePlatform.Directions.Right:
                    transform.GetChild(0).rotation = Quaternion.Euler(0, 0, -90);
                    break;
                case MobilePlatform.Directions.Left:
                    transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 90);
                    break;
            }
        }

        public override void Init()
        {
            transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "Player") return;
            transform.GetChild(0).localScale = new Vector3(1, 2, 1);
            GetComponent<AudioSource>().Play();
        }
    }
}
