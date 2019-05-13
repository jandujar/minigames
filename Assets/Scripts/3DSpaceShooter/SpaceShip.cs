using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;

namespace SpaceShooter
{
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] SpaceShooterManager spaceManager = null;

        [Header("Ship Properties")]
        [SerializeField] protected Bullet.BulletOwner characterType;
        [SerializeField] protected float minSpeed = 0;
        [SerializeField] protected float maxSpeed = 0, acceleration = 0, deceleration = 0;

        protected float currentSpeed;
        protected Vector2 inputMovement;

        [Header("Bullet")]
        [SerializeField] protected Bullet.BulletType bulletType;
        [SerializeField] protected Vector3 bulletSpawnPoint;

        Rigidbody rb;

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
            currentSpeed -= Mathf.Max(deceleration * Time.deltaTime, 0);
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            ResetVariables();
            UpdateControlls();
        }

        protected void Shoot()
        {
            GameObject tempBullet = Instantiate(spaceManager.bulletPrefab, bulletSpawnPoint, transform.rotation);
            tempBullet.GetComponent<Bullet>().InitBullet(bulletType, characterType);
        }

        protected void Accelerate()
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        }

        protected virtual void UpdateControlls()
        {
            //Input
        }

        protected void OnDrawGizmos()
        {
            Gizmos.DrawSphere(bulletSpawnPoint, 0.25f);
        }
    }
}
