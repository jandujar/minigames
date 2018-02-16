using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    public TextMesh[] options = new TextMesh[4];
    int num = 2;
    int falseResult = 0;
    int correctOption = 0;

	public void printDifferentOptions(int result)
    {
        correctOption = (int)Random.Range(0f, 4f);
        falseResult = result;

        switch (correctOption)
        {
            case 0:
                options[0].text = result.ToString();
                falseResult = num + result;
                options[1].text = falseResult.ToString();
                falseResult = num*2 - result;
                options[2].text = falseResult.ToString();
                falseResult = num + correctOption * 5 - result;
                options[3].text = falseResult.ToString();
                break;
            case 1:
                options[1].text = result.ToString();
                falseResult = num + result;
                options[2].text = falseResult.ToString();
                falseResult = num * 2 - result;
                options[3].text = falseResult.ToString();
                falseResult = num + correctOption * 5 - result;
                options[0].text = falseResult.ToString();
                break;
            case 2:
                options[2].text = result.ToString();
                falseResult = num + result;
                options[1].text = falseResult.ToString();
                falseResult = num * 2 - result;
                options[0].text = falseResult.ToString();
                falseResult = num + correctOption * 5 - result;
                options[3].text = falseResult.ToString();
                break;
            case 3:
                options[3].text = result.ToString();
                falseResult = num + result;
                options[0].text = falseResult.ToString();
                falseResult = num * 2 - result;
                options[2].text = falseResult.ToString();
                falseResult = num + correctOption * 5 - result;
                options[1].text = falseResult.ToString();
                break;
        }
       
    }

    public int getCorrectOption()
    {
        return correctOption;
    }

}
