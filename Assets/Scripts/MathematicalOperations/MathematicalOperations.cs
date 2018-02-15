using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathematicalOperations : IMiniGame
{
    private GameManager gameManager;
    public static MathematicalOperations instance = null;
    private List<int> listNumbers = new List<int>();
    private List<char> listOperators = new List<char>();
    private int countNumbers = 4;
    private int countOperators = 2;
    private int result = 0;


    void Awake()
    {
        //Init Game
        Debug.LogError("Change this Script for your own Script");
        if(instance == null)
        {
            instance = this;
        }
        
    }

    void Start()
    {
        calculateMathOperation();
        Debug.Log("Result: " + result);
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

    public void setNumberInList(int value)
    {
        listNumbers.Add(value);

        Debug.Log("Length ListNumbers: " + listNumbers.Count);

        if (listNumbers.Count == 4)
        {
           invertOrderList();

            foreach (int i in listNumbers)
            {
                Debug.Log("ListNumbers: " + i);
            }
        }
        
    }

    public int getCountNumbers()
    {
        return countNumbers--;
    }

    private void invertOrderList()
    {
        //Coge el primero y segundo 
        int aux = listNumbers[0]; 
        int aux2 = listNumbers[1];

        //Subtituye los 2 últimos por los 2 primeros
        listNumbers[0] = listNumbers[3];
        listNumbers[1] = listNumbers[2];

        //Subtituye los 2 primeros por los 2 últimos
        listNumbers[2] = aux2;
        listNumbers[3] = aux;
    }

    public void setOperatorInList(char op)
    {
        listOperators.Add(op);

        Debug.Log("Length listOperators: " + listOperators.Count);

        if (listOperators.Count == 2)
        {
            foreach (char i in listOperators)
            {
                Debug.Log("ListOperators: " + i);
            }
        }

    }

    public int getCountOperators()
    {
        return countOperators--;
    }

    public void calculateMathOperation()
    {
        int num1 = 0, num2 = 0, num3 = 0, num4 = 0;
        for (int i = 0; i < listNumbers.Count; i++)
        {
            switch (i)
            {
                case 0:
                    num1 = listNumbers[i];
                    break;
                case 1:
                    num2 = listNumbers[i];
                    break;
                case 2:
                    num3 = listNumbers[i];
                    break;
                case 3:
                    num4 = listNumbers[i];
                    break;
            }
        }

        if (listOperators[1] == '-' && listOperators[0] == '-')
        {
            result = num1 - num2 - (num3 * num4);
        }else if(listOperators[1] == '-' && listOperators[0] == '+')
        {
            result = num1 - num2 + (num3 * num4);
        }
        else if (listOperators[1] == '+' && listOperators[0] == '+')
        {
            result = num1 + num2 + (num3 * num4);
        }
        else if (listOperators[1] == '+' && listOperators[0] == '-')
        {
            result = num1 + num2 - (num3 * num4);
        }
    }

    public int getResultOperation()
    {
        return result;
    }

}
