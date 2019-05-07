using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HyperJump
{
    public class BaseController : MonoBehaviour
    {
        Vector3 rotation;
        [SerializeField] float rotationSpeed;
        float axis;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            axis = Input.GetAxis("Horizontal");
        }

        void FixedUpdate()
        {
            rotation = transform.rotation.eulerAngles;
            rotation += Vector3.up * axis * rotationSpeed;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
