using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform missile;
    public float distanceDamp = 0.1f;
    public Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    private Vector3 velocity = Vector3.one;
    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - missile.position;
    }

	void LateUpdate ()
    {
        SmoothFollow();
    }

    void SmoothFollow() {
        
        Vector3 toPos = missile.position + (missile.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, distanceDamp);
        transform.position = curPos;

        transform.LookAt(missile);
    }
}
