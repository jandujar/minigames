using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathematicalOperations : IMiniGame
{
    private GameManager gameManager;
    public static MathematicalOperations instance = null;
    private List<string> listNumbers = new List<string>();
    private int countNumbers = 4;

    
    void Awake()
    {
        //Init Game
        Debug.LogError("Change this Script for your own Script");
        if(instance == null)
        {
            instance = this;
        }

       

    }

    public override void beginGame()
    {
        //Game Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        //ball.init(gm);
    }

    public override string ToString()
    {
        return "Mathematical Operations by Sergi López";
    }

    public void setNumberInList(string nameID, int value)
    {
        listNumbers.Add(nameID + ", " + value);

        Debug.Log("Length ListNumbers: " + listNumbers.Count);

        if (listNumbers.Count == 4)
        {
           invertOrderList();

            foreach (string i in listNumbers)
            {
                Debug.Log("ListNumbers: " + i);
            }
        }
        
    }

    public List<string> getOperation()
    {
        return listNumbers;
    }

    public int getCountNumbers()
    {
        return countNumbers--;
    }

    private void invertOrderList()
    {
        //Coge el primero y segundo 
        string aux = listNumbers[0]; 
        string aux2 = listNumbers[1];

        //Subtituye los 2 últimos por los 2 primeros
        listNumbers[0] = listNumbers[3];
        listNumbers[1] = listNumbers[2];

        //Subtituye los 2 primeros por los 2 últimos
        listNumbers[2] = aux2;
        listNumbers[3] = aux;
    }
    
}
