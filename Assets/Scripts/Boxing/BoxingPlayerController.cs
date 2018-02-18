using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingPlayerController : MonoBehaviour {

    public BoxingEnemyController boxingEnemy;
    private float move;
    private float posX;
    private float posY;
    private bool charguePunch;
    public int chargueKo = 0;
    public bool aviableKo;
    public bool releaseKo;


	// Use this for initialization
	void Start () {       
        posX = transform.position.x;
        posY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		move = InputManager.Instance.GetAxisHorizontal();


        if (move > 0)
        {
            transform.position = new Vector2(posX + 3,posY);
        }
        else if (move < 0)
        {
            transform.position = new Vector2(posX - 3, posY);
        }
        else
        {
            transform.position = new Vector2(posX, posY);
        }

        charguePunch = InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1);

        if (charguePunch)
        {
            chargueKo = chargueKo + 30;
        }
        else
        {
            chargueKo--;
            if (chargueKo < 0)
            {
                chargueKo = 0;
            }
            
        }

        releaseKo = InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2);

        if (chargueKo > 500 && chargueKo < 800)
        {
            aviableKo = true;
        }
        else
        {
            aviableKo = false;
        }

        if (aviableKo && releaseKo)
        {
            chargueKo = 0;

            if (boxingEnemy.transform.position.x == transform.position.x)
            {
                GameObject.Find("Enemy").SetActive(false);
            }
        }
	}
}
