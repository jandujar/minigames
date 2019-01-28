using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez
{
    [System.Serializable]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        GameObject bullet;
        public void Shoot()
        {
            switch (gameObject.transform.parent.name)
            {
                case "ShootRight":
                    bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().direction = Vector2.right;
                    break;
                case "ShootLeft":
                    bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().direction = Vector2.left;
                    break;
                case "ShootUp":
                    bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().direction = Vector2.up;
                    break;
                case "ShootDown":
                    bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().direction = Vector2.down;
                    break;
            }
        }
    }
}
