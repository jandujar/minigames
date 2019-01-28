using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerShip : MonoBehaviour
{

    private Vector3 mousePos;
    private float MouseX;
    private float MouseY;
    private Vector3 GameMousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        mousePos = Input.mousePosition;
        
        GameMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        GameMousePos.z = -45;
        transform.position = Vector2.Lerp(transform.position, GameMousePos, 0.6f);
    }
}
