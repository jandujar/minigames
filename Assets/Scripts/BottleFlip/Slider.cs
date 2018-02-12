using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliderc : MonoBehaviour {
    public float power = 50f;
    public Rigidbody rb;
    private bool isWin;
    private Vector3 startPos;
    private GameManager gm;
    private Slider sl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform.position = startPos;

    }

    void Update()
    {
        AddImpulse();
        //CheckWin();
    }



    public void AddImpulse()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, power, 0);
            transform.Rotate(0,0,0);
        }
    }
    public void CheckWin()
    {
        if (isWin)
        {
            this.transform.position = startPos;
            gm.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }
}
