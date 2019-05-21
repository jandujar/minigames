using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HyperJump
{
    public class CameraController : MonoBehaviour
    {

        public Transform target;
        public bool lookAt = false;
        public float smoothSpeed = 0.125f;
        public Vector3 offset;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            if(lookAt)transform.LookAt(target);
        }
    }
}