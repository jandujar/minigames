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

        protected float currentSpeed;
        protected Vector2 inputMovement;

        [Header("Bullet")]
        [SerializeField] protected Bullet.BulletType bulletType;
        [SerializeField] protected Vector3 bulletSpawnPoint;
        [SerializeField] protected float bulletSpeed;

        protected Rigidbody rb;
        protected Vector2 rotation;
        protected Vector2 cameraSpeed = new Vector2(5, 5); 
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
            rotation.y += cameraSpeed.x * Input.GetAxis("Mouse X");
            rotation.x -= cameraSpeed.y * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(rotation.x, rotation.y, 0.0f);
        }

        protected void Shoot()
        {
            GameObject tempBullet = Instantiate(spaceManager.bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
            tempBullet.GetComponent<Bullet>().InitBullet(bulletType, characterType, bulletSpeed);   
        }
        protected void Death()
        {

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
