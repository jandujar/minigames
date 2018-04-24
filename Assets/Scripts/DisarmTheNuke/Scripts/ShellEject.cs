using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellEject : MonoBehaviour {
	
public Rigidbody bulletCasing;
public int ejectSpeed = 20;
public float fireRate = 0.1f;
private float nextFire = 0.0f;


	// Update is called once per frame
void Update () {
 
if (Input.GetMouseButton(0) && Time.time > nextFire) {
nextFire =  Time.time + fireRate;

Rigidbody clone;
 
clone = Instantiate(bulletCasing, transform.position, transform.rotation);
clone.velocity = transform.TransformDirection(Vector3.left * ejectSpeed);
transform.Rotate(Random.Range (0, 120),0,0);
}
}
}
