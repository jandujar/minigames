using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    private Text text;


	void Awake()
    {
        text = transform.Find("CountDown").gameObject.GetComponent<Text>();
    }
    
    // Use this for initialization

    //public IEnumerator BeginCountDown()
   // {
        /*text.text = "3";
        yield return new WaitForSeconds(1f);

        text.text = "2";

        yield return new WaitForSeconds(1f);

        text.text = "1";

        yield return new WaitForSeconds(1f);

        text.text = "Go!";

        yield return new WaitForSeconds(1f);*/
   // }
}
