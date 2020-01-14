using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : IMiniGame
{
    GameManager game;

    float timer = 4f;

    public static bool InventoryPaused = false;

    public GameObject PauseMenuUI;

    public override void beginGame()
    {
        
       //game.EndGame(MiniGameResult.WIN);        
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        game = gm;
    }

    
    void Update()
    {
        // timer -= Time.deltaTime;
        // if(timer <= 0){
        //     PauseMenuUI.SetActive(false);
        //     Time.timeScale = 1f;
        // }
        // else{
        //     PauseMenuUI.SetActive(true);
        //     Time.timeScale = 0f;
        // }
        // Debug.Log(timer);
       
        // if(Input.GetKeyDown("e")){
        //     Win();
            
        // }
    }

    public void Win(){
        game.EndGame(MiniGameResult.WIN);
    }
    public void Lose(){
        game.EndGame(MiniGameResult.LOSE);
    }
    public void setVictory(bool win){
        if(win){
            game.EndGame(MiniGameResult.WIN);
        }
    }
    public void setDefeat(bool defeat){
       if(defeat){
           Debug.Log("LOSE");
           game.EndGame(MiniGameResult.LOSE);
       }
    }

}