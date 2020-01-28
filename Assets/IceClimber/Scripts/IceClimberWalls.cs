using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceClimberWalls : MonoBehaviour
{
    
    [SerializeField]
    private GameObject pieza;

    private IceClimberPlayer iceClimberPlayer;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        iceClimberPlayer = player.GetComponent<IceClimberPlayer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Martillo" && iceClimberPlayer.getCanPieza()){
            iceClimberPlayer.setCanPieza();
            GameObject gm = Instantiate(pieza);
            gm.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }

}
