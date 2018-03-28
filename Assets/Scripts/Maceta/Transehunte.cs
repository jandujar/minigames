using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transehunte : MonoBehaviour {
    [SerializeField] private float min = -10f;
    [SerializeField] private float max = 10f;
    // Use this for initialization
    void Start()
    {
        min = transform.position.x+min;
        max = transform.position.x + max;
    }

    // Update is called once per frame
    void Update()   {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 3, max - min) + min, transform.position.y, transform.position.z);
    }
}
