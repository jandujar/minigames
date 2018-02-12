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
    public Transform bottRot, bottPos;
    public float maxPower = 300f;
    public float power = 0f;
    private Vector3 initialPos, inercia, initialRot;
    [SerializeField]
    private GameObject canvasSlider;
    [SerializeField]
    private GameManager gm;


    [SerializeField]
    private Rigidbody bottle;

    [SerializeField]
    private bool isFlip = false;

	// Use this for initialization
	void Start () {
        bottRot.transform.eulerAngles = initialRot;
        bottPos.transform.position = initialPos;
    }
	
	// Update is called once per frame
	void Update () {
		if (inercia == Vector3.zero || initialRot != Vector3.zero) //Si ha parat de moure's
        {
            //gm.EndGame(IMiniGame.MiniGameResult.WIN);
            //comprovar rotació i comprovar si l'hem llançat
            //si la rotació és ~(0,0,0) i comprovar si la rotacio en l'eix Z es < epsilon
            //float.Epsilon
        }
        if (initialPos == bottle.transform.position)
        {
            //gm.EndGame(IMiniGame.MiniGameResult.WIN);
        }
        else
        {
            //gm.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
	}

    public void Launch()
    {
        bottle.AddForce(Vector3.up * power);
        bottle.AddRelativeTorque(Vector3.forward * power);
        power = 0f;
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
    }
    private void Reset()
    {
        bottPos.transform.position = initialPos;
    }
}
