using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcePantalla : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;

    private bool move = false;
    private float [] listaPosCam = new float[]{-1, 2, 5, 8, 11, 20, 24, 27, 29, 32, 34};
    private int counPos = 0;

    [SerializeField]
    private Text txt;
    private float timer = 40;
    void Update()
    {
        if(move){
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(cam.transform.position.x, listaPosCam[counPos], cam.transform.position.z), 0.3f);
            if(cam.transform.position.y == listaPosCam[counPos]){
                counPos++;
                move = false;
            }
        }
        if(counPos >= 6){
            timer -= Time.deltaTime;
            txt.text = string.Format("{0:00.0}",timer);
        }
        
        this.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y-8f, cam.transform.position.z);

        

    }

    public void doMove(){
        move = true;
    }

    public float getTimer(){
        return timer;
    }
}
