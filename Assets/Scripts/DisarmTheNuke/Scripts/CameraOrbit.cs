using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {
	
public Transform target;
public float distance = 10.0f;
public float xSpeed = 25.0f;
public float ySpeed = 25.0f;
public int yMinLimit = -80;
public int yMaxLimit = 80;
public int distanceMin = 3;
public int distanceMax = 15;
public CursorLockMode CursorMode;

private float x = 0.0f;
private float y = 0.0f;

// Use this for initialization
	void Start () {	
	 Vector3 angles = transform.eulerAngles;
     x = angles.y;
     y = angles.x;
	Cursor.lockState = CursorMode;
	Cursor.visible = (CursorLockMode.Locked != CursorMode);
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
     if (target) {
         x += Input.GetAxis("Mouse X") * xSpeed * distance* 0.02f;
         y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
  
          y = ClampAngle(y, yMinLimit, yMaxLimit);
  
         Quaternion rotation = Quaternion.Euler(y, x, 0);
  
         distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
  
         RaycastHit hit;
         if (Physics.Linecast (target.position, transform.position, out hit)) {
                 distance -=  hit.distance;
         }
  
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
  
         transform.rotation = rotation;
         transform.position = position;
  
     }
  
 }
static float ClampAngle (float angle, float min, float max) {
     if (angle < -360)
         angle += 360;
     if (angle > 360)
         angle -= 360;
     return Mathf.Clamp (angle, min, max);
 }

}
