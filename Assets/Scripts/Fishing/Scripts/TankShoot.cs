using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulledPrefab;

    public float bulledSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            Shoot();
            //Debug.Log("PIUM");
        }
    }

    void Shoot()
    {
        GameObject Bulled = Instantiate(bulledPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bulled.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulledSpeed, ForceMode2D.Impulse);
    }
}
