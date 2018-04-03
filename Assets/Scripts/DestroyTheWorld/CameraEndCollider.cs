using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEndCollider : MonoBehaviour {

    public float minFov = 15.0f;
    public float maxFov = 90.0f;
    public float sensitivity = 10.0f;

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Camera")
        {
            other.transform.parent = this.transform;
            other.transform.position = this.transform.position;
            Camera camera = other.gameObject.GetComponent<Camera>();
            camera.gameObject.GetComponent<CameraFollow>().enabled = false;
            float fov = camera.fieldOfView;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            camera.fieldOfView = fov;
        }
        
    }
}
