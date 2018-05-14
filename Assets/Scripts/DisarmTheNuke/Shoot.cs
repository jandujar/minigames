using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.marc.escobar{
    
public class Shoot : MonoBehaviour {

    private int damage;
    private float range;

    public Camera MainCamera;
    public GameObject shootPoint;

    CursorLockMode lockMode;

    void Awake()
    {
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
    }


    // Use this for initialization
    void Start () {
        damage = 10;
        range = 100f;
    }

    public void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.up, out hit, range * 2000)){
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("hit the enemy");
                hit.transform.GetComponent<SoldierIA>().SetHealth(damage);
            }
        }
    }
}

}
