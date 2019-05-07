using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eric_Sanchez_Verges
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]float speed;

        float x, y, z = 0f;
        float angularSpeed = 0f;

        Vector3 rotation;

        // Update is called once per frame
        void Update()
        {
            angularSpeed += Input.GetAxisRaw("Horizontal")*Time.deltaTime*speed;
            
        }

        private void FixedUpdate()
        {
            x = Mathf.Cos(angularSpeed);
            y = Mathf.Sin(angularSpeed);
            transform.position = new Vector3(x, y, z);
            rotation = transform.rotation.eulerAngles;
            rotation += Vector3.forward * Input.GetAxisRaw("Horizontal") * 5.73f;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
