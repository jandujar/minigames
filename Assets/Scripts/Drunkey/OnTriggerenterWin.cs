using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterWin : MonoBehaviour
{
    public ivan_alvarez_enri.Drunkey_Sc GameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.win=true;
        Debug.Log("Has Ganao");
    }
}
