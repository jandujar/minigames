using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour {

    [Header("Animations")]
    public Animator animatorC;
    public Animator animatorH;

    [Header("CanvasText")]
    public GameObject DisplayBox;
    public GameObject CountDown;

    [Header("Classes")]
    public VeganKnows vegan;

    [Header("Variables")]
    private int QTEGen;
    private int WaitingForKey;
    private int CorrectKey;
    public string butt1;
    public string butt2;
    public int timeleft = 10;
    public int dificultLvl = 1;
    
    private void Update()
    {
        if (WaitingForKey == 0)
        {
            QTEGen = Random.Range(1, 3);

            if (QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = butt1;
            }
            if (QTEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = butt2;
            }
            StartCoroutine(LoseTime());
        }

        if (QTEGen == 1){
            if (Input.anyKeyDown){
                if (Input.GetButton("Fire1")){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing ());
                }else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 2){
            if (Input.anyKeyDown){
                if (Input.GetButton("Fire2")){
                    CorrectKey = 3;
                    StartCoroutine(KeyPressing());
                }else{
                    CorrectKey = 4;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }


    IEnumerator KeyPressing(){
        QTEGen = 3;
        if (CorrectKey == 1){
            animatorC.SetTrigger("throwCG");
            yield return new WaitForSeconds(1.5f);
            //Condicion de victoria
            Debug.Log("WINNER");
            vegan.Win();
        }
        if (CorrectKey == 2)
        {
            animatorC.SetTrigger("throwCB");
            yield return new WaitForSeconds(1.5f);
            //Condicion de derrota
            Debug.Log("LOSER");
            vegan.Lose();
        }
        if (CorrectKey == 3){
            animatorH.SetTrigger("throwHG");
            yield return new WaitForSeconds(1.5f);
            //Condicion de victoria
            Debug.Log("WINNER");
            vegan.Win();
        }
        if (CorrectKey == 4)
        {
            animatorH.SetTrigger("throwHB");
            yield return new WaitForSeconds(1.5f);
            //Condicion de derrota
            Debug.Log("LOSER");
            vegan.Lose();
        }
    }
    IEnumerator LoseTime()
    {
        while (timeleft > -1)
        {
                CountDown.GetComponent<Text>().text = timeleft.ToString();
                timeleft = timeleft - 1 * dificultLvl;
                yield return new WaitForSeconds(1); 
        }
        Debug.Log("LOSER");
        vegan.Lose();
    }
}
