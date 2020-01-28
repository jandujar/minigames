using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : IMiniGame
{
     GameManager game;
     //public Text txt;
     bool alive = false;

     public GameObject PlayerFishing;

     public PlayerFishing PFishing;
    public override void beginGame()
    {
        //txt.text = PFishing.totalFish + " Total Fish";
       // PFishing = PlayerFishing.GetComponent<PlayerFishing>();
    }

    void Update(){
        if(alive){
            if(PFishing.totalFish <=0 ){
                game.EndGame(MiniGameResult.WIN);
            }
            if(PFishing.lives <=0 ){
                game.EndGame(MiniGameResult.LOSE);
            }
        }
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        game = gm;
        alive = true;
    }

}
