using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : IMiniGame {
    public enum GameState
    {
        Countdown,
        Playing
    }

    public GameState state = GameState.Countdown;
    public float maxPower = 300f;
    public float power = 0f;
    private Vector3 initialPos, inercia, currentPos;
    [SerializeField]
    private GameObject canvasSlider;
    [SerializeField]
    private GameManager gm;
    private Quaternion initialRot, currentRot, rotationZ;
    private GameObject botella;
    private bool isLaunched;


    [SerializeField]
    private Rigidbody bottle;

    [SerializeField]
    private bool isFlip = false;

	// Use this for initialization
	void Start () {
        /*initialPos = botella.transform.position;
        initialRot = Quaternion.Euler(0, 0, 0); //rot inicial
        currentPos = botella.transform.position; 
        currentRot = botella.transform.rotation;
        rotationZ = Quaternion.Euler(0, 0, 180);*/
    }
	
	// Update is called once per frame
	void Update () {
        if (power > 0 && isLaunched == true ) //Si ha parat de moure's
        {
            //gm.EndGame(IMiniGame.MiniGameResult.WIN);
            //comprovar rotació i comprovar si l'hem llançat
            //si la rotació és ~(0,0,0) i comprovar si la rotacio en l'eix Z es < epsilon
            //float.Epsilon
        }
	}

    public void Launch()
    {
        bottle.AddForce(Vector3.up * power);
        bottle.AddRelativeTorque(Vector3.forward * power);
        power = 0f;
        isLaunched = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        initialPos= bottle.transform.position;
        state = Game.GameState.Countdown;
        canvasSlider.SetActive(false);

    }

    public override void beginGame()
    {
        state = Game.GameState.Playing;
        canvasSlider.SetActive(true);
        isLaunched = false;
    }
    private void Reset()
    {
        botella.transform.position = initialPos;
        botella.transform.rotation = initialRot;
        botella.SetActive(false);
        isLaunched = false;
    }
}
