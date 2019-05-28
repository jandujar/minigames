using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CameraShooter : MonoBehaviour
    {
        public Transform target;
        public bool lookAt = false;
        public float smoothSpeed = 0.125f;
        public Vector3 offset;

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
            transform.position = smoothedPosition;

            if (lookAt) transform.LookAt(target);
        }
    }

}
