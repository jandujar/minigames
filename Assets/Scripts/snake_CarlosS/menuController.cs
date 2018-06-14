using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {

    public Button Play;
    public Button credits;
    public Button Exit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Button btnPlay = Play.GetComponent<Button>();
        btnPlay.onClick.AddListener(StartGame);

        Button btnCred = credits.GetComponent<Button>();
        btnCred.onClick.AddListener(StartCredits);

        Button btnExit = Exit.GetComponent<Button>();
        btnExit.onClick.AddListener(exitGame);
	}


    void StartGame()
    {
        MenuManager.Instance.LaunchMiniGame();
    }

    void StartCredits()
    {
        SceneManager.LoadScene("Creditos_CarlosSevilla");
    }

    void exitGame()
    {
        Application.Quit();
    }
}
