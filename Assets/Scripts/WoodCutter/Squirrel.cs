using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour {
    public Animator anim;
    Vector2 posButton1 = new Vector2(-10.21f, -3.52f);
    Vector2 posButton2 = new Vector2(-4.95f, -3.52f);
    bool isFlipped = false;

    void Update()
    {
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
        {
            if (isFlipped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                isFlipped = false;
            }


            Debug.Log("Pulsando Botton Derecho");
            this.gameObject.transform.position = posButton2;


            WoodCutter.instance.setIsCutting(true);
            anim.SetBool("isCutting", true);
            WoodCutter.instance.setCuttedCount(WoodCutter.instance.getCuttedCount() + 1);
        }
        else if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            if (!isFlipped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                isFlipped = true;
            }

            Debug.Log("Pulsando Botton Izquierdo");
            this.gameObject.transform.position = posButton1;


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

    public bool getIsFlipped()
    {
        return isFlipped;
    }
}
