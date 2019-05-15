using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfIntroController : MonoBehaviour
{

    [SerializeField] GolfController controller;
    [SerializeField] GameObject arrow;

    public void BeginAnimation()
    {
        controller.enabled = false;
        arrow.SetActive(false);
        
    }

    public void EndAnimation()
    {
        GetComponent<Animator>().enabled = false;
        arrow.SetActive(true);  
        controller.enabled = true;
        
    }
}
