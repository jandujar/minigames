using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechanicsManager : MonoBehaviour {

    [Header("Animations")]
    //public Animator animation_name;
   

    [Header("CanvasText")]
    //public GameObject text_name;
  
    [Header("Classes")]
    //public VeganKnows Class_name;

    [Header("Variables")]
    private int m_GameState;
    public int timeleft = 10;



    private void Update()
    {
        if (m_GameState == 0)
        {
        }
            while (timeleft > -1)
            {

            }
            Debug.Log("LOSER");
        }
    }
