using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Luka : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        //MenuManager.Instance.LaunchMiniGame();
        SceneManager.LoadScene("Snake_Luka.Scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos_Luka");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
