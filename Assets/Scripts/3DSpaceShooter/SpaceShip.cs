using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;

namespace SpaceShooter
{
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] protected SpaceShooterManager spaceManager = null;

        [Header("Ship Properties")]
        [SerializeField] protected Bullet.BulletOwner characterType;
        [SerializeField] protected float minSpeed = 0;
        [SerializeField] protected float maxSpeed = 0, acceleration = 0, deceleration = 0;
        [SerializeField] protected float maxRollSpeed = 0;
        [SerializeField] protected float maxPitchSpeed = 0;
        [SerializeField] protected float cameraRotationSpeed = 0;

        protected float currentSpeed;
        protected float currentRollSpeed;
        protected float currentPitchSpeed;
        protected Vector2 inputMovement, inputCameraRotation;

        [Header("Bullet")]
        [SerializeField] protected Bullet.BulletType bulletType;
        [SerializeField] protected Vector3 bulletSpawnPoint;
        [SerializeField] protected float bulletSpeed;

        protected Rigidbody rb;
        protected Vector2 cameraRotation;
        protected int health = 3;
        protected void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            inputMovement = Vector2.zero;
        }

        protected virtual void FixedUpdate()
        {
            rb.velocity = transform.forward * currentSpeed;

            cameraRotation += inputCameraRotation * cameraRotationSpeed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + currentPitchSpeed, transform.localEulerAngles.y, transform.localEulerAngles.z + currentRollSpeed);

            transform.GetChild(0).eulerAngles = new Vector3(cameraRotation.x, cameraRotation.y, 0.0f);
        }

        protected virtual void ResetVariables()
        {
            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0);
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            ResetVariables();
            UpdateControlls();
        }

        protected void Shoot()
        {
            GameObject tempBullet = Instantiate(spaceManager.bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
            tempBullet.GetComponent<Bullet>().InitBullet(bulletType, characterType, bulletSpeed);   
        }
        protected virtual void Death()
        {

        }

        public void GetDamage()
        {
            Debug.Log("PIMBA!");
            if (--health == 0) Death();
        }

        protected void Accelerate()
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        }

        protected virtual void UpdateControlls()
        {
            
        }

        protected void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position + bulletSpawnPoint, 0.25f);
        }
    }
}
