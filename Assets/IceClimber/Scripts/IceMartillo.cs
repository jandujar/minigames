using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMartillo : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+0.6f, player.transform.position.z);
    }
}
