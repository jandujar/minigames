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

        // Start is called before the first frame update
        void Start()
        {

        }

        public void InitBullet(BulletType bt, BulletOwner bo)
        {
            bulletType = bt;
            bulletOwner = bo;

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += speed * Vector3.forward * Time.deltaTime;
            if((lifeTime -= Time.deltaTime) <= 0) Destroy(gameObject);
        }
    }
}
