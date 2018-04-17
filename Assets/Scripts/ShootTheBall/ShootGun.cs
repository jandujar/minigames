using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    [Header("Bullet Instance Params")]
    public int totalBullets=3;
    public float m_BulletForce;
    public Transform origin;
    public Transform parent;
    public GameObject bullet;

    [Header("Complements")]
    public ParticleSystem particleSystem;
    public AudioSource shootSFX;

    [Header("Cooldown")]
    public Slider slider;
    public float cooldown = 2.5f;
    public float countCooldown = 1.5f;
    public bool canShoot = true;

    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!canShoot)
            countCooldown -= (Time.deltaTime * cooldown);
        
        if (countCooldown <= 0)
        {
            canShoot = true;
            countCooldown = 1.5f;
        }

        slider.value = countCooldown;

		if( (Input.GetKeyDown(KeyCode.Space) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) )&& canShoot)
        {
            canShoot = false;

            shootSFX.Play();
            particleSystem.Play();
            StartCoroutine(gunShoot());      
        }
	}

    public IEnumerator gunShoot()
    {
        for(int i=0;i<totalBullets;++i)
        {
            GameObject l_TempBullet;
            l_TempBullet = Instantiate(bullet, origin.position, origin.rotation, parent) as GameObject;
            l_TempBullet.gameObject.name = "Bullet";
            l_TempBullet.transform.Rotate(Vector3.back * 90);
            //l_TempBullet.transform.Rotate(Vector3.up * 90);
            l_TempBullet.transform.Rotate(Vector3.left * 90);
            Rigidbody l_TempRB;
            l_TempRB = l_TempBullet.GetComponent<Rigidbody>();
            l_TempRB.AddForce(origin.forward * m_BulletForce);
            DestroyObject(l_TempBullet, 5f);

            yield return new WaitForSecondsRealtime(0.05f);
            //Debug.Break();
        }
    }
}
