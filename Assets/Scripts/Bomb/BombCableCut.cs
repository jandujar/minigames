using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCableCut : MonoBehaviour {

    public GameObject[] arraycable;

    private int cableSelect = 0;
    private int preMove;
    public Color cableSelected;
    void Update()
    {
        float move = InputManager.Instance.GetAxisHorizontal();

        if (move < 0 && preMove == 0)
        {
            cableSelect--;
            if (cableSelect < 0)
            {
                cableSelect = 0;
            }
            preMove = -1;
        }
        if (move > 0 && preMove == 0)
        {
            cableSelect++;
            if (cableSelect > 2)
            {
                cableSelect = 2;
            }
            preMove = 1;
        }
        if (move == 0)
        {
            preMove = 0;
        }
        switch (cableSelect)
        {
            case 0:
                this.transform.GetChild(3).transform.position = new Vector3(-1.68f, -3.53f, 7.554f);
                cableSelected = Color.red;
                break;
            case 1:
                this.transform.GetChild(3).transform.position = new Vector3(-0.24f, -3.53f, 7.554f);
                cableSelected = Color.blue;
                break;
            case 2:
                this.transform.GetChild(3).transform.position = new Vector3(1.14f, -3.53f, 7.554f);
                cableSelected = Color.yellow;
                break;
        }

    }


}
