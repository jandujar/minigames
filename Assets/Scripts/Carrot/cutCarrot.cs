using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class cutCarrot : MonoBehaviour {

    public GameObject[] carrotParts;
    public Text keyToPress;

    int randomInt;
    KeyCode myButton;

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4);
        GamePlay();
    }

    void GamePlay()
    {
        
        switch (randomInt)
        {
            case 0:
                myButton = KeyCode.X;
                keyToPress.text = "X";
                break;
            case 1:
                myButton = KeyCode.Y;
                keyToPress.text = "Y";
                break;
            case 2:
                myButton = KeyCode.B;
                keyToPress.text = "B";
                break;
            case 3:
                myButton = KeyCode.A;
                keyToPress.text = "A";
                break;
            default:
                print("Algo o alguien huele mal");
                break;
        }
    }

	void Start () {
        StartCoroutine(StartGame());
        GamePlay();
	}

    void Update()
    {
        randomInt = Random.Range(0, 4);
        for (int i = 0; i < carrotParts.Length; i++)
        {
            if (Input.GetKeyUp(myButton))
            {
                carrotParts[i].SetActive(false);
            }
        }
    }
}
