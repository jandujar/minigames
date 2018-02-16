using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : IMiniGame {
    public enum GameState
    {
        Countdown,
        Playing
    }

    public GameState state = GameState.Countdown;
    public float maxPower = 300f;
    public float minPower = 200f;
    public float power = 0f;
    [SerializeField]
    private GameObject canvasSlider;
    [SerializeField]
    private GameManager gm;
    public bool isLaunched = false;
    [SerializeField] private Text txt;
    [SerializeField]
    private Rigidbody bottle;

    [SerializeField]
    private float time;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator CheckEnd()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            if (isLaunched == true)
            {  //si s'ha tirat l'ampolla 
               //Debug.Log("velocity: " + bottle.velocity.magnitude);
               //Debug.Log("rotation: " + bottle.rotation.eulerAngles.z);
                if (bottle.position.y < 0f && bottle.velocity.magnitude <= Vector3.kEpsilon)//Si ha parat de moure's
                {
                    if (Mathf.Abs(bottle.rotation.eulerAngles.z) <= 15f)
                    {
                        StartCoroutine(EndWin());
                    }
                    else
                    {
                        StartCoroutine(EndLose());
                    }
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator EndWin()
    {
        yield return new WaitForSeconds(1f);
        gm.EndGame(IMiniGame.MiniGameResult.WIN);
    }
    IEnumerator EndLose()
    {
        yield return new WaitForSeconds(1f);
        gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }


    public void Launch()
    {
        if (!isLaunched)
        {
            //Debug.Log("Power: " + power);
            power = Mathf.Max(minPower, power);
            bottle.AddForce(Vector3.up * power);
            bottle.AddRelativeTorque(Vector3.forward * power);
            power = 0f;
            isLaunched = true;
            StartCoroutine(CheckEnd());
        }
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        state = Game.GameState.Countdown;
        canvasSlider.SetActive(false);

    }

    public override void beginGame()
    {
        state = Game.GameState.Playing;
        canvasSlider.SetActive(true);
        isLaunched = false;
        StartCoroutine(CheckTimeout());
    }

    IEnumerator CheckTimeout()
    {
        txt.text = (time).ToString();
        for (int i = 0; i < time; i++)
        {
            txt.text = (time - i).ToString();
            yield return new WaitForSeconds(1f);
        }
        txt.text = (0).ToString();

        if (!isLaunched && power <= 0)
        {
            gm.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }
    public override string ToString()
    {
        return "BottleFlip by Marc";
    }
}
