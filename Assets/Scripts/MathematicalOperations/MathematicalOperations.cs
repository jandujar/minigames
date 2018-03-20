using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathematicalOperations : IMiniGame
{
    private GameManager gameManager;
    public static MathematicalOperations instance = null;

    public RandomNumbers[] SC_Numbers = new RandomNumbers[4];
    public RandomOperators[] SC_Operators = new RandomOperators[2];
    public PrintNum1Result SC_PrintNum1Result;
    public PrintNum2Result SC_PrintNum2Result;
    public Options SC_Options;
    public OptionPressed[] SC_OptionPressed = new OptionPressed[4];

    private List<int> listNumbers = new List<int>();
    private List<char> listOperators = new List<char>();
    private int countNumbers = 4;
    private int countOperators = 2;
    private int result = 0;
    private bool mathOperationCalculated = false;
    private bool userWin = false;
    private bool optionChose = false;
    public GameObject failed;
    public GameObject passed;
    private Coroutine stopCo;


    void Awake()
    {
        //Init Game
        Debug.LogError("Change this Script for your own Script");
        if(instance == null)
        {
            instance = this;
        }
        
    }

    void Update()
    {
        if (listNumbers.Count == countNumbers && listOperators.Count == countOperators)
        {
            if (!mathOperationCalculated)
            {
                calculateMathOperation();
                Debug.Log("Result: " + result);

                SC_Options.printDifferentOptions(result);
                
            }

            if (!optionChose)
            {
                checkInputs();
                
            }else
            {
                printResult();
                if (SC_PrintNum1Result.getPrintNum1ResultFinished() && SC_PrintNum2Result.getPrintNum2ResultFinished())
                {
                    if (userWin)
                    {
                        StartCoroutine(waitSecondsPrintPassed(1f));
                        StopCoroutine(stopCo);

                    }
                    else
                    {
                        StartCoroutine(waitSecondsPrintFailed(1f));

                    }
                }
            }            
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
        for(int i = 0; i < countNumbers; i++)
        {
            SC_Numbers[i].init();
        }
        for (int i = 0; i < countOperators; i++)
        {
            SC_Operators[i].init();
        }
        stopCo = StartCoroutine(waitSecondsPrintFailed(10f));
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

        mathOperationCalculated = true;

    }

    public int getResultOperation()
    {
        return result;
    }

    void checkInputs()
    {

        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
        {
            Debug.Log("Correct Option: " + SC_Options.getCorrectOption() + " Button pressed: " + (int)InputManager.MiniGameButtons.BUTTON1 + " = A ");
            SC_OptionPressed[(int)InputManager.MiniGameButtons.BUTTON1].setEnableSprite(true);
            if (SC_Options.getCorrectOption() == (int)InputManager.MiniGameButtons.BUTTON1)
            {
                Debug.Log("Resultado Correcto");
                userWin = true;

            }
            optionChose = true;
        }
        else if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON2))
        {
            Debug.Log("Correct Option: " + SC_Options.getCorrectOption() + " Button pressed: " + (int)InputManager.MiniGameButtons.BUTTON2 + " = B ");
            SC_OptionPressed[(int)InputManager.MiniGameButtons.BUTTON2].setEnableSprite(true);
            if (SC_Options.getCorrectOption() == (int)InputManager.MiniGameButtons.BUTTON2)
            {
                Debug.Log("Resultado Correcto");
                userWin = true;
            }
            optionChose = true;
        }
        else if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON3))
        {
            Debug.Log("Correct Option: " + SC_Options.getCorrectOption() + " Button pressed: " + (int)InputManager.MiniGameButtons.BUTTON3 + " = X ");
            SC_OptionPressed[(int)InputManager.MiniGameButtons.BUTTON3].setEnableSprite(true);
            if (SC_Options.getCorrectOption() == (int)InputManager.MiniGameButtons.BUTTON3)
            {
                Debug.Log("Resultado Correcto");
                userWin = true;
            }
            optionChose = true;
        }
        else if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4))
        {
            Debug.Log("Correct Option: " + SC_Options.getCorrectOption() + " Button pressed: " + (int)InputManager.MiniGameButtons.BUTTON4 + " = Y ");
            SC_OptionPressed[(int)InputManager.MiniGameButtons.BUTTON4].setEnableSprite(true);
            if (SC_Options.getCorrectOption() == (int)InputManager.MiniGameButtons.BUTTON4)
            {
                Debug.Log("Resultado Correcto");
                userWin = true;
            }
            optionChose = true;
        }

    }

    void printResult()
    {
        SC_PrintNum1Result.printNum1ResultEnabled = true;

        if (SC_PrintNum1Result.getPrintNum1ResultFinished())
        {
            SC_PrintNum2Result.printNum2ResultEnabled = true;
        }
    }

   
    IEnumerator waitSecondsPrintPassed(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        
        passed.SetActive(true);
        StartCoroutine(waitSecondsWin(2f));
    }
    IEnumerator waitSecondsPrintFailed(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        failed.SetActive(true);
        StartCoroutine(waitSecondsLose(2f));
    }

    IEnumerator waitSecondsWin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

    IEnumerator waitSecondsLose(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

}
