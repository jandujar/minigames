using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class creditController : MonoBehaviour {

    public Button back;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Button btnB = back.GetComponent<Button>();
        btnB.onClick.AddListener(backMenu);
	}

    void backMenu()
    {
        SceneManager.LoadScene("Menu_CarlosSevilla");
    }
}
