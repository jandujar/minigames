using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngPicross3D : MonoBehaviour
{

    [SerializeField] float maxlifes;

    private float lifes;

    private float badCubesNum;





    // Start is called before the first frame update
    void Start()
    {
        if (maxlifes <= 0) maxlifes = 3;
        lifes = maxlifes;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
