using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilLado: MonoBehaviour {
    [SerializeField] private float min = -10f;
    [SerializeField] private float max = 10f;
    // Use this for initialization
    void Start()
    {
        min = transform.position.z+min;
        max = transform.position.z + max;
    }

    // Update is called once per frame
    void Update()   {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 3, max - min) + min);
    }
}
