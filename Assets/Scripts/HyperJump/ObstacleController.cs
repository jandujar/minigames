using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperJump
{
    public class ObstacleController : MonoBehaviour
    {

        [SerializeField] float speed;

        Vector3 orbitPoint;

        public bool isEnemy;

        public GameObject ball;

        public float impulseForce;

        

        // Start is called before the first frame update
        void Start()
        {

            if (isEnemy == false) return;
            int rand0 = Random.Range(0, 2);
            if (rand0 == 0) isEnemy = false;
            else
            {
                isEnemy = true;
                MeshRenderer meshRend;
                if ( meshRend = GetComponent<MeshRenderer>()) meshRend.material.color = Color.red;
                else
                {
                    for(int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }

            orbitPoint = transform.parent.position;
            orbitPoint.y = transform.position.y;

            speed = Random.Range(70, 150);
            int rand = Random.Range(0, 2);
            if (rand == 0) speed *= -1;

        }

        // Update is called once per frame
        void Update()
        {
            if(isEnemy)Rotate();
            if (ball.transform.position.y < transform.position.y) Shoot();
        }

        void Rotate()
        {
            transform.RotateAround(orbitPoint, Vector3.up, speed*Time.deltaTime);
        }

        public void Shoot()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform tf = transform.GetChild(i);
                Rigidbody rb = tf.gameObject.GetComponent<Rigidbody>();
                tf.gameObject.GetComponent<MeshCollider>().enabled = false;
                rb.isKinematic = false;
                rb.AddForce(tf.rotation.eulerAngles * impulseForce);
                tf.parent = null;
            }
        }
    }
}
