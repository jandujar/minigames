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

    public float max_power = 100f;
    public float power = 0f;
    private Vector3 initial_pos, inertia;

    [SerializeField]
    private Rigidbody bottle;

    [SerializeField]
    private bool is_flip = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if (inertia == Vector3.zero) //Si ha parat de moure's
        {
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
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        initial_pos = bottle.transform.position;
        state = Game.GameState.Countdown;
    }

    public override void beginGame()
    {
        state = Game.GameState.Playing;
    }
}
