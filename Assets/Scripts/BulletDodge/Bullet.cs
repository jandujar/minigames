using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez
{
    public class Bullet : MonoBehaviour
    {
        int force;
        public Vector2 direction;
        
        // Start is called before the first frame update
        void Start()
        {
            force = 22;
            GetComponent<Rigidbody2D>().AddForce(direction * force);
            if (direction == Vector2.down)
                transform.rotation =  Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
            if (direction == Vector2.left)
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
            if (direction == Vector2.up)
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
        }
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
