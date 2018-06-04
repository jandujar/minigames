using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour {
    private Text text;
    private int count = 0;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = MenuManager.Instance.currentScore.ToString();
        count = 0;
	}


    public void Update(){
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) {
            count++;
            if (count > 3)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
