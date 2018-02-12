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
    [SerializeField]
    private GameObject PassBox;

    public enum QTState { Ready, Delay, Ongoing, Done };            //game status
    public QTState qtState = QTState.Ready;

    public enum QTResponse { Null, Success, Fail };                 //win/fail game
    public QTResponse qtResponse = QTResponse.Null;                 //win condition not defined for now

    public float CountTimer = 2f;                                   //duration of the event
    public float DelayTimer = 0f;                                   //delay before event starts


    public List<KeyCode> Buttons = new List<KeyCode>();
    public bool isRandom = false;
    private int ran = 0;

    public override void beginGame()
    {
        StartCoroutine(StateChange());
        //throw new NotImplementedException();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        //throw new NotImplementedException();
        gameManager = gm;
    }

    private IEnumerator StateChange()
    {
        qtState = QTState.Delay;
        // Wait for the Delay if any delay at all.
        yield return new WaitForSeconds(DelayTimer);
        // If we want a random button we use Random.Range, otherwise we set it to the first button in the list!
        if (isRandom)
        {
            ran = UnityEngine.Random.Range(0, Buttons.Count);
        }
        else
        {
            ran = 0;
        }
        // This line below is only for Debug Purposes
        print(Buttons[ran]);
        // This adds the selected button to the display GUI and makes it uppercase instead of lowercase.
        DisplayBox.GetComponent<Text>().text = Buttons[ran].ToString().ToUpper();
        qtState = QTState.Ongoing;
        yield return new WaitForSeconds(CountTimer);
        // If the timer is over and the event isn't over? Fix it! because most likely they failed.
        if (qtState == QTState.Ongoing)
        {
            qtResponse = QTResponse.Fail;
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            qtState = QTState.Done;
            // We ready the gui text for the next event/time.
            DisplayBox.GetComponent<Text>().text = string.Empty;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (qtState == QTState.Ongoing)
        {            
                if (Input.anyKeyDown)
                {
                    qtState = QTState.Done;
                    qtResponse = QTResponse.Success;
                    // We ready the gui text for the next event/time.
                    //ButtonDisplay.text = string.Empty;
                    DisplayBox.GetComponent<Text>().text = "WIN";
                    PassBox.GetComponent<Text>().text = "WIN";
                    StopCoroutine(StateChange());
                    gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
        }
    }
}
