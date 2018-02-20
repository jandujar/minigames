using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakcsText : MonoBehaviour {

    private TextMesh text;
    private int textScore = 0;
    [SerializeField]private int maxScore = 4;
    [SerializeField]KnifeAttack knife;
    
	void Start () {
        text = gameObject.GetComponent<TextMesh>();
	}

    public int getTextScore()
    {
        return textScore;
    }

    public void setTextScore(int newTextScore)
    {
        textScore = newTextScore;
        updateTextScore();
    }

    void updateTextScore()
    {
        text.text = textScore.ToString();
        if (textScore >= maxScore)
        {
            knife.stopKnife();
            knife.setVictory();
        }
    }
}