 using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Pong : IMiniGame
{
     private GameManager gameManager;
     public Ball ball;
 
     void Awake()
     {
         //Init Pong
         Debug.LogError("Change this Script for your own Script");
     }
 
     public override void beginGame()
     {
         //Pong Begins
         Debug.Log(this.ToString() + " game Begin");
         ball.enableBall = true;
     }
 
     public override void initGame(MiniGameDificulty difficulty, GameManager gm)
     {
         this.gameManager = gm;
         ball.init(gm); 
     }
 
     public override string ToString()
     {
         return "Pong by Jandujar";
     }
 }