using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechanicsManager : MonoBehaviour
{

    [Header("Animations")]
    //public Animator animation_name;

    [Header("CanvasText")]
    //public GameObject text_name;

    [Header("Slider")]
    public Slider m_slider;

    [Header("Classes")]
    private RopeScript m_ropeclass;

    [Header("Variables")]
    public GameObject m_sprite;
    private int m_GameState;
    private Vector3 m_position;
    public int timeleft = 10;

    private void Start()
    {
        m_position = gameObject.transform.position;
    }

    private void Update()
    {
            if (Input.anyKeyDown)
            {
                if (Input.GetButton("Fire1"))
                {
                    m_slider.value += 0.04f;
                    m_position.x = m_position.x - 1;


            }
            }
            else
            {
                m_slider.value -= 0.0045f;
            }
        //Debug.Log("WIN");
        //m_ropeclass.Win();
        if (m_slider.value == 0) { Debug.Log("LOSE"); m_ropeclass.Lose(); }
        if (m_slider.value == 1) { Debug.Log("WIN"); m_ropeclass.Win(); }
    }
    
}
