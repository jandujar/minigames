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

        protected Vector2 cameraRotation;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
		    Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            cameraRotation += inputCameraRotation * cameraRotationSpeed * Time.deltaTime;
            transform.GetChild(0).localRotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0.0f);
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        protected override void UpdateControlls() 
        {
            if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)){
                Shoot();
            }
            if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4)){
                Accelerate();
            }

            currentPitchSpeed = maxPitchSpeed * InputManager.Instance.GetAxisVertical();
            currentRollSpeed = maxRollSpeed * -InputManager.Instance.GetAxisHorizontal();

            inputCameraRotation.y = Input.GetAxis("Mouse X") * mouseSensitivty;
            inputCameraRotation.x = -Input.GetAxis("Mouse Y") * mouseSensitivty;

        }
        void OnTriggerEnter(Collider other){
            if(other.name.ToLower().Contains("ring")){
                Debug.Log("HIT");
                health--;
                if(health <= 0)
                    spaceManager.EndGame(false);
            }
            else if(other.name.ToLower().Contains("innerzone")){
                Debug.Log("SCORE");
                spaceManager.score++;
            }
            else if(other.name.ToLower().Contains("bullet")){
                if(health <= 0)
                    spaceManager.EndGame(false);
            }
        }
    }
}
