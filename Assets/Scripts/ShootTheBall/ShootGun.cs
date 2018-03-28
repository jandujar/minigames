using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour {

    public Transform m_Origin;
    public Transform m_Parent;
    public GameObject m_Bullet;

    public float m_BulletForce;
	
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject l_TempBullet;
            l_TempBullet = Instantiate(m_Bullet, m_Origin.position, m_Origin.rotation, m_Parent) as GameObject;
            l_TempBullet.gameObject.name = "Bullet";
            l_TempBullet.transform.Rotate(Vector3.back * 90);
            Rigidbody l_TempRB;
            l_TempRB = l_TempBullet.GetComponent<Rigidbody>();
            l_TempRB.AddForce(m_Origin.forward * m_BulletForce);
            DestroyObject(l_TempBullet, 5f);
        }
	}
}
