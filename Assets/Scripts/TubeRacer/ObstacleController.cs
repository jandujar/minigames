using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eric_Sanchez_Verges
{
    public class ObstacleController : MonoBehaviour
    {

        [SerializeField] protected float speed;
        [SerializeField] protected float forwardSpeed;

        protected float x, y, z;
        protected float angularSpeed = 0f;

        protected MeshRenderer render;
        [SerializeField] protected int dir; //-1 = clockwise / 1 = laltre
                                            // Start is called before the first frame update
        protected virtual void Start()
        {
            render = GetComponent<MeshRenderer>();
            Initialize();
        }

        // Update is called once per frame
        protected virtual void FixedUpdate()
        {
            x = Mathf.Cos(dir * angularSpeed);
            y = Mathf.Sin(dir * angularSpeed);
            transform.position = new Vector3(x, y, z += forwardSpeed * Time.deltaTime);
        }

        protected virtual void Update()
        {
            angularSpeed += Time.deltaTime * speed;
            UpdateObject();
        }

        protected virtual void PickDirection()
        {
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    dir = -1;
                    break;
                case 1:
                    dir = 1;
                    break;
            }
        }

        protected virtual void Initialize()
        {
            transform.position = Vector3.forward * 25f;
            z = transform.position.z;
            PickDirection();
            render.enabled = true;
        }

        protected virtual void UpdateObject()
        {
            if(transform.position.z < -1f)render.enabled = false;
            if (transform.position.z < -5) Initialize();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player") Debug.Log("You lost");
        }

    }
}
