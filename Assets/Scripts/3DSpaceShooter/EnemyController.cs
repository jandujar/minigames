using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyController : SpaceShip
    {

        PlayerController player;
        [Header("Enemy Controller")]
        [SerializeField] float coolDownShoot;
        float currentCoolDownShoot;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            player = GameObject.FindObjectOfType<SpaceShooter.PlayerController>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        protected override void UpdateControlls()
        {
            if (!GetComponent<Renderer>().isVisible) return;

            base.UpdateControlls();
            //inputRotation = 
            transform.LookAt(player.transform.position);

            if((currentCoolDownShoot += Time.deltaTime) >= coolDownShoot)
            {
                currentCoolDownShoot = 0;
                Shoot();
            }

        }

        protected override void Death()
        {
            base.Death();
            Destroy(gameObject);
        }
    }

}
