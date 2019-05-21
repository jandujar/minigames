using Eric_Sanchez_Verges;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eric_Sanchez_Verges
{
    public class ObstacleRotationController : ObstacleController
    {
        //He utilizado herencia porque me ha hecho especial ilusion no por nada

        Vector3 rotation;
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update() 
        {
            UpdateObject();
        }

        private void FixedUpdate()
        {
            rotation = transform.rotation.eulerAngles ;
            rotation += Vector3.forward * Time.deltaTime * speed * dir;
            transform.rotation = Quaternion.Euler(rotation);
            transform.position = new Vector3(x, y, z += forwardSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
    }
}