using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour {
    public Animator anim; 


    void Update()
    {
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3))
        {
            Debug.Log("Pulsando");
            WoodCutter.instance.setIsCutting(true);
            anim.SetBool("isCutting", true);
            WoodCutter.instance.setCuttedCount(WoodCutter.instance.getCuttedCount() + 1);
        }
        else
        {
            Debug.Log("Sin Pulsar");
            WoodCutter.instance.setIsCutting(false);
            anim.SetBool("isCutting", false);
        }
    }
}
