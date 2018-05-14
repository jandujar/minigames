using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour {

    public PinDown p1;
    public PinDown p2;
    public PinDown p3;
    public PinDown p4;
    public PinDown p5;
    public PinDown p6;
    public PinDown p7;
    public PinDown p8;
    public PinDown p9;
    public PinDown p10;

    private bool finished = false;

    public GameManager g;
  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void CheckPlane () {
		if(p1.pin && p2.pin && p3.pin && p4.pin && p5.pin && p6.pin && p7.pin && p8.pin && p9.pin && p10.pin && !finished)
        {
            Debug.Log("Pleno");
            finished = true;
            g.EndGame(IMiniGame.MiniGameResult.WIN);

        }
	}

    public void Defeated()
    {

        if (finished) return;
        Debug.Log("lose");
        finished = true;
        g.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

   
}
