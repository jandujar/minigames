using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulledPrefab;

    public float bulledSpeed = 20f;

    private float timeToShoot = 2f;

    // Update is called once per frame
    void Update()
    {
        timeToShoot -= Time.deltaTime;
        if(timeToShoot <= 0){
            Shoot();
            timeToShoot = 2f;
        }
    }

    void Shoot()
    {
        GameObject Bulled = Instantiate(bulledPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bulled.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulledSpeed, ForceMode2D.Impulse);
    }
}
