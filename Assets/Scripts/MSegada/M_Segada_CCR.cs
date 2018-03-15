using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class M_Segada_CCR : IMiniGame
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject NEWcanvas;
    [SerializeField]
    private GameObject DisplayBox;
   // [SerializeField]
   // private GameObject PassBox;
    [SerializeField]
    private GameObject EnemyIMG;

    [SerializeField]
    private AudioSource soundAudio;
    [SerializeField]
    public AudioClip alarm;

    public enum QTState { Ready, Delay, Ongoing, Done };            //game status
    public QTState qtState = QTState.Ready;

    public enum QTResponse { Null, Success, Fail };                 //win/fail game
    public QTResponse qtResponse = QTResponse.Null;                 //win condition not defined for now

    [SerializeField]
    private float CountTimer = 0.3f;                                //duration of the event
    
    private float DelayTimer = 0f;                                  //delay before event starts

    public bool isRandom = false;
    private int ran = 0;


    
    public Animator anim;
    





    public override void beginGame()
    {
        EnemyIMG.SetActive(false);
        NEWcanvas.SetActive(true);                                  //our game shows 
        StartCoroutine(StateChange());                              //win/loose condition starts
        soundAudio = GetComponent<AudioSource>();
        
        //throw new NotImplementedException();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        //throw new NotImplementedException();
        gameManager = gm;
    }

   
    // Use this for initialization
    void Start () {
        DelayTimer = UnityEngine.Random.Range(1.5f, 5);                //random time of waiting to the start of the event
        NEWcanvas.SetActive(false);
    }
	 private IEnumerator StateChange()
    {
        qtState = QTState.Delay;        
        yield return new WaitForSeconds(DelayTimer);                // Wait for the Delay        
        DisplayBox.GetComponent<Text>().text = "QUICK! PRESS A BUTTON!";      //shows text to JUMP
        soundAudio.clip = alarm;
        soundAudio.Play();
        EnemyIMG.SetActive(true);
        qtState = QTState.Ongoing;
        yield return new WaitForSeconds(CountTimer);
       
        if (qtState == QTState.Ongoing)                             //count.timer gets to 0
        {
            qtResponse = QTResponse.Fail;
            //PassBox.GetComponent<Text>().text = "FAIL";
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            qtState = QTState.Done;           
            DisplayBox.GetComponent<Text>().text = string.Empty;
        }
    }
    


    // Update is called once per frame
    void Update () {
        if (qtState == QTState.Ongoing)
        {
            if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))                                 //we press ANY key during the OnGoing state
            {
                anim.SetTrigger("jumptrigger");
                
                    
                DisplayBox.GetComponent<Text>().text = "WIN";
                //PassBox.GetComponent<Text>().text = "WIN";
                qtState = QTState.Done;
                qtResponse = QTResponse.Success;
                StopCoroutine(StateChange());
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
        }
    }
}
