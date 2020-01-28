using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceClimberPieza : MonoBehaviour
{   
    
    Rigidbody2D rgb;
    [SerializeField]
    private float fuerza;

    private IceClimberPlayer iceClimberPlayer;

    private GameObject player;

    private float dirX;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        iceClimberPlayer = player.GetComponent<IceClimberPlayer>();

        if(iceClimberPlayer.getHorizontal() < 0) dirX = -1; else dirX = 1;


        rgb.AddForce(new Vector2(dirX*3,6)*fuerza, ForceMode2D.Impulse);
    }
}
