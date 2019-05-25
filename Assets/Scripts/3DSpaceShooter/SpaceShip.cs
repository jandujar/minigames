using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;

namespace SpaceShooter
{
    public class SpaceShip : MonoBehaviour
    {
        const float ROTATION_MULTIPLY = 10F;

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
        public Vector3 forward;
        [SerializeField] protected Bullet.BulletType bulletType;
        [SerializeField] protected Vector3 bulletSpawnPoint;
        [SerializeField] protected float bulletSpeed;
        Vector3 rotation;
        [SerializeField] Vector2 cameraSpeed; 
        protected Rigidbody rb;
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
            forward = transform.forward;



            //rb.velocity = transform.forward * currentSpeed;

            transform.position = transform.position + transform.forward * currentSpeed * Time.deltaTime;
            
            transform.Rotate(currentPitchSpeed,-currentRollSpeed,0);

            transform.eulerAngles =  
                 new Vector3(Mathf.Clamp(RealRotationToEditorRotation(transform.eulerAngles.x), -60, 60), 
                 transform.eulerAngles.y, 
                     0);
            transform.GetChild(0).localEulerAngles = Vector3.forward * currentRollSpeed * ROTATION_MULTIPLY;
            /*rotation.y += cameraSpeed.x * Input.GetAxis("Mouse X");
            rotation.x -= cameraSpeed.y * Input.GetAxis("Mouse Y");*/

            //transform.eulerAngles = new Vector3(rotation.x, rotation.y, 0.0f);
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
            GameObject tempBullet = Instantiate(spaceManager.bulletPrefab, transform.position + transform.forward * 3.5f, transform.rotation);
            tempBullet.GetComponent<Bullet>().InitBullet(bulletType, characterType, bulletSpeed);   
        }
        protected virtual void Death()
        {

        }

        public void GetDamage()
        {

            Debug.Log(gameObject.name + ": PIMBA!");
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

        //Para convertir la rotacion que va de 0 a 360 a una rotacion de -180 a 180
        public static float RealRotationToEditorRotation(float rotation)
        {
            return rotation - 360 * System.Convert.ToSByte(rotation > 180);
        }

    }
}
