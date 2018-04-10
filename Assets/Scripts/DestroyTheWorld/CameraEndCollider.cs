using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEndCollider : MonoBehaviour {

    public float minFov = 15.0f;
    public float maxFov = 90.0f;
    public float sensitivity = 10.0f;
    public DestroyTheWorld gameEnginge;
    public Transform cameraParent;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            other.transform.parent = cameraParent;
            other.transform.position = cameraParent.position;
            Camera camera = other.gameObject.GetComponent<Camera>();
            camera.gameObject.GetComponent<MissileCameraFollow>().enabled = false;
            camera.gameObject.GetComponent<CameraCollision>().enabled = false;
            camera.transform.rotation = new Quaternion(0,0,0,0);
            float fov = camera.fieldOfView;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            camera.fieldOfView = fov;
            StartCoroutine(SetExplosion());
        }
        
    }

    IEnumerator SetExplosion()
    {
        yield return new WaitForSeconds(3);
        gameEnginge.BigExplosion();
    }
}
