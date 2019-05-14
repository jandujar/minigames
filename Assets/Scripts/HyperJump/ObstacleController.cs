using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperJump
{
    public class ObstacleController : MonoBehaviour
    {
        float timeCounter = 0;

        [SerializeField] float speed;

        Vector3 orbitPoint;

        public bool isEnemy;

        // Start is called before the first frame update
        void Start()
        {

            if (isEnemy == false) return;
            int rand0 = Random.Range(0, 2);
            if (rand0 == 0) isEnemy = false;
            else
            {
                isEnemy = true;
                GetComponent<MeshRenderer>().material.color = Color.red;
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
        }

        void Rotate()
        {
            transform.RotateAround(orbitPoint, Vector3.up, speed*Time.deltaTime);
        }
    }
}
