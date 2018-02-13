using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour {

    private GameManager gameManager;
    public GameObject DisplayBox;
    public GameObject PassBox;
    public GameObject CountDown;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int timeleft = 10;
    public int dificultLvl = 1;
    

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    private void Update()
    {
        if (WaitingForKey == 0)
        {
            QTEGen = Random.Range(1, 3);
            Debug.Log(QTEGen);


            if (QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[E]";
            }
            if (QTEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[R]";
            }
            StartCoroutine(LoseTime());
        }

        if (QTEGen == 1){
            if (Input.anyKeyDown){
                if (Input.GetButton("E_Key")){
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
                if (Input.GetButton("R_Key")){
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
            PassBox.GetComponent<Text>().text = "PASS1";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
        }
        if (CorrectKey == 2)
        {
            PassBox.GetComponent<Text>().text = "FAIL2";
            //Condicion de derrota
            Debug.Log("Loser");
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        if (CorrectKey == 3)
        {
            PassBox.GetComponent<Text>().text = "PASS3";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
        }
        if (CorrectKey == 4)
        {
            PassBox.GetComponent<Text>().text = "FAIL4";
            //Condicion de derrota
            Debug.Log("Loser");
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
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
        Debug.Log("Winner");
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }
}
