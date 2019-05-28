using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Bullet : MonoBehaviour
    {
        const int MAX_PIERCING_HITS = 3;

        public enum BulletType { Normal, Piercing, Explosive, End}
        public enum BulletOwner { Player, Enemy};

        public BulletType bulletType;
        public BulletOwner bulletOwner;

        protected float speed = 5;
        protected float lifeTime = 5;
        protected bool exploded;
        protected int currentPiercingHits;

        [SerializeField] protected Collider explosionCollider;

        public void InitBullet(BulletType bt, BulletOwner bo, float speed)
        {
            bulletType = bt;
            bulletOwner = bo;
            this.speed = speed;
            exploded = false;
            if(bt == BulletType.Piercing)
            {
                currentPiercingHits = MAX_PIERCING_HITS;
            }
        }

        private void FixedUpdate()
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }

        // Update is called once per frame
        void Update()
        {
            if((lifeTime -= Time.deltaTime) <= 0) Destroy(gameObject);
        }

        protected void Explode()
        {
            exploded = true;
            switch(bulletType)
            {
                case BulletType.Normal:
                    Destroy(gameObject);
                    break;
                case BulletType.Piercing:
                    if(--currentPiercingHits == 0) {  Destroy(gameObject);  }
                    break;
                case BulletType.Explosive:
                    lifeTime = 0.5f;
                    explosionCollider.enabled = true;
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("TRIGGER");
            if(other.gameObject.tag == "Player" && bulletOwner == BulletOwner.Enemy ||
                other.gameObject.tag == "EnemyShip" && bulletOwner == BulletOwner.Player)
            {
                other.GetComponent<SpaceShip>().GetDamage();
            }
            if (exploded) return;
            Explode();
        }
    }
}
