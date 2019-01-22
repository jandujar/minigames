using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterLose : MonoBehaviour
{
    public bool EjeX;
    public int Dir;

    public ivan_alvarez_enri.Drunkey_Sc GameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entro");
        if(GameManager.StartInputs)
            GameManager.lose=true;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(GameManager.StartInputs){
            if(EjeX){
                GameManager.xDir+=Dir*0.25F;
            }else{
                GameManager.yDir-=0.25F;
            }
        }
    }
}
