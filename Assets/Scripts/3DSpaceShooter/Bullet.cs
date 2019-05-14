using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Bullet : MonoBehaviour
    {
        public enum BulletType { Normal, Piercing, Explosive, End}
        public enum BulletOwner { Player, Enemy};

        public BulletType bulletType;
        public BulletOwner bulletOwner;

        protected float speed = 5;
        protected float lifeTime = 5;

        public void InitBullet(BulletType bt, BulletOwner bo, float speed)
        {
            bulletType = bt;
            bulletOwner = bo;
            this.speed = speed;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += speed * transform.forward * Time.deltaTime;
            if((lifeTime -= Time.deltaTime) <= 0) Destroy(gameObject);
        }
    }
}
