using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleShooterEngine : IMiniGame
{

    [SerializeField] Camera MainCamera;
    [SerializeField] GameManager gameManagerInstance;


    public override void beginGame()
    {
        
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        gm = gameManagerInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }




}
