using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterLose : MonoBehaviour
{
    public bool EjeX;
    public float Dir;

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
                Dir+=0.25F;
                GameManager.xDir+=Dir;
                Camera.main.transform.Translate(new Vector3(Dir/8,-Dir/10,0));
            }else{
                GameManager.yDir-=0.25F;
                Debug.Log(Camera.main.transform.rotation.x);
                if(Camera.main.transform.rotation.x>-90)
                    Camera.main.transform.Rotate(new Vector3(-1,0,0));
            }
        }
    }
}
