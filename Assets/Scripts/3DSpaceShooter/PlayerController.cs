using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {
    public class PlayerController : SpaceShip
    {
        private Vector2 axisRotation;
        private Transform cameraTransform;
        private Quaternion cameraRot;
        private Transform playerTransform;
        private Quaternion playerRot;
        [SerializeField] bool smooth;
        [SerializeField] float smoothTime;
        [SerializeField] bool limitCamerRot;
        [SerializeField] float minAngle = -60;
        [SerializeField] float maxAngle = 60;
	    [SerializeField] float mouseSensitivty = 3.0f;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            Debug.Log("adogodg");
            cameraTransform = Camera.main.transform;
            cameraRot = cameraTransform.localRotation;

            playerTransform = transform;
            playerRot = playerTransform.localRotation;
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            cameraRot *= Quaternion.Euler(-axisRotation.y, axisRotation.x, 0);  
            //cameraRot = Quaternion.Euler(cameraRot.x, cameraRot.y, 0);
            //playerRot *= Quaternion.Euler(0, axisRotation.x, 0);

            if(limitCamerRot) cameraRot = ClampRotationAroundXAxis(cameraRot);

            if(smooth)
            {
                cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, cameraRot, Time.deltaTime * smoothTime);
                //playerTransform.localRotation = Quaternion.Slerp(playerTransform.localRotation, playerRot, Time.deltaTime * smoothTime);
            }
            else
            {
                cameraTransform.localRotation = cameraRot;
                Debug.Log(cameraRot);
                //playerTransform.localRotation = playerRot;
            }
        }

        protected override void UpdateControlls() 
        {
            if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)){
                Shoot();
            }
            if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4)){
                Accelerate();
            }
            Vector2 mouseAxis = Vector2.zero;
            mouseAxis.x = Input.GetAxis("Mouse X") * mouseSensitivty;
            mouseAxis.y = Input.GetAxis("Mouse Y") * mouseSensitivty;
            //Debug.Log("Mouse X = " + mouseAxis.x + " Y = " + mouseAxis.y);
            SetRotation(mouseAxis);
        }
        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, minAngle, maxAngle);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
        void SetRotation(Vector2 mouseAxis)
        {
            axisRotation = mouseAxis;
        }
    }
}
