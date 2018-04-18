using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    [SerializeField]
    private float randomRadius = 4;

    void Start () {
        gameObject.transform.localPosition = Random.insideUnitSphere.normalized * randomRadius;
        gameObject.transform.localPosition = new Vector3(clampPoint(gameObject.transform.localPosition.x), clampPoint(gameObject.transform.localPosition.y),
                                                            clampPoint(gameObject.transform.localPosition.z));
    }

    private float clampPoint(float point)
    {
        if (point < -0.2f)
        {
            point = -0.2f;
        }
        else if (point > 0.3f)
        {
            point = 0.3f;
        }
        return point;
    }
}