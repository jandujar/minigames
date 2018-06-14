using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour {

    public Button Jugar;
    public Button Creditos;
    public Button Salir;
    //public Text Credits;
    //public Image fondo;
    //private bool cred;

    // Use this for initialization
    void Start () {
        Button creditos = Creditos.GetComponent<Button>(); 
        creditos.onClick.AddListener(CreditsClick);

        Button salir = Salir.GetComponent<Button>();
        salir.onClick.AddListener(SalirClick);

        //cred = true;
    }
	
    public void CreditsClick()
    {

        SceneManager.LoadScene("Creditos_raul");
       /* if (cred == true) {
            Credits.gameObject.SetActive(true);
            fondo.gameObject.SetActive(false);
            cred = false;
        }
        else if (cred == false)
        {
            Credits.gameObject.SetActive(false);
            fondo.gameObject.SetActive(true);
        }*/

    }

    public void SalirClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
