using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    [Header("Bullet Instance Params")]
    public int m_TotalBullets=3;
    public float m_BulletForce;
    public Transform m_Origin;
    public Transform m_Parent;
    public GameObject m_Bullet;

    [Header("Particles")]
    public ParticleSystem m_ParticleSystem;

    [Header("Cooldown")]
    public Slider m_Slider;
    public float m_Cooldown = 2.5f;
    public float m_CountCooldown = 1.5f;
    public bool m_CanShoot = true;

    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!m_CanShoot)
            m_CountCooldown -= (Time.deltaTime * m_Cooldown);
        
        if (m_CountCooldown <= 0)
        {
            m_CanShoot = true;
            m_CountCooldown = 1.5f;
        }

        m_Slider.value = m_CountCooldown;

		if(Input.GetKeyDown(KeyCode.Space) && m_CanShoot)
        {
            m_CanShoot = false;

            m_ParticleSystem.Play();
            StartCoroutine(gunShoot());      
        }
	}

    public IEnumerator gunShoot()
    {
        for(int i=0;i<m_TotalBullets;++i)
        {
            GameObject l_TempBullet;
            l_TempBullet = Instantiate(m_Bullet, m_Origin.position, m_Origin.rotation, m_Parent) as GameObject;
            l_TempBullet.gameObject.name = "Bullet";
            l_TempBullet.transform.Rotate(Vector3.back * 90);
            //l_TempBullet.transform.Rotate(Vector3.up * 90);
            l_TempBullet.transform.Rotate(Vector3.left * 90);
            Rigidbody l_TempRB;
            l_TempRB = l_TempBullet.GetComponent<Rigidbody>();
            l_TempRB.AddForce(m_Origin.forward * m_BulletForce);
            DestroyObject(l_TempBullet, 5f);

            yield return new WaitForSecondsRealtime(0.05f);
            //Debug.Break();
        }
    }
}
