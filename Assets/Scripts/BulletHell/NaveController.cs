using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    private float direction;
    private float rotat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = InputManager.Instance.GetAxisVertical();
        rotat = InputManager.Instance.GetAxisHorizontal();


        transform.Translate(0, direction, 0);
            
        if(rotat > 0)
        {
            transform.Rotate(0, 0, 1);
        }
        else if(rotat < 0)
        {
            transform.Rotate(0, 0, -1);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("collision");
    }
}
