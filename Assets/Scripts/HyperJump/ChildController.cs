using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour
{
    public bool isEnemy;

    [SerializeField] float rotationSpeed;

    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(x, y, z);    
    }
}
