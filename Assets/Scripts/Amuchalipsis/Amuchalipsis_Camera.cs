using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amuchalipsis_Camera : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Vector3 StartPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x + (StartPos.x-1), 
            Player.transform.position.y + StartPos.y, 
            Player.transform.position.z + StartPos.z);
    }
}
