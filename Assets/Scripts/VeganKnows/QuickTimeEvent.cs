using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour {

    public GameObject DisplayBox;
    public GameObject CountDown;
    public VeganKnows vegan;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
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
                DisplayBox.GetComponent<Text>().text = "C";
            }
            if (QTEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "H";
            }
            StartCoroutine(LoseTime());
        }

        if (QTEGen == 1){
            if (Input.anyKeyDown){
                if (Input.GetButton("Carrot_B")){
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
                if (Input.GetButton("Hamburger_B")){
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
            yield return new WaitForSeconds(1.0f);
            //Condicion de victoria
            Debug.Log("WINNER");
            vegan.Win();
        }
        if (CorrectKey == 2)
        {
            yield return new WaitForSeconds(1.0f);
            //Condicion de derrota
            Debug.Log("LOSER");
            vegan.Lose();
        }
        if (CorrectKey == 3){
            yield return new WaitForSeconds(1.0f);
            //Condicion de victoria
            Debug.Log("WINNER");
            vegan.Win();
        }
        if (CorrectKey == 4)
        {
            yield return new WaitForSeconds(1.0f);
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
