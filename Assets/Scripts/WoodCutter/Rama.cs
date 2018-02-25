using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rama : MonoBehaviour {
    public Transform reset;
    Vector2 pos;

    float playerHeight = 3.65f;
    

	// Use this for initialization
	void Awake () {
        /* Dos tipos de ramas:
         *  - Rama derecha: instanciarla con una Y de 3.65 superior a la anterior para que quepa el player debajo y sin rotaciones
         *  - Rama izquierda: instanciarla con una Y de 3.65 superior a la anterior para que quepa el player debajo y con una rotación X de 180 y Z de 180
         * */
         
        pos = this.transform.position;


    }
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.y <= reset.position.y)
        {
            this.transform.position = pos;
        } 

        if (WoodCutter.instance.getIsCutting())
        {
            StartCoroutine(waitSecondsToMove(0.25f));
            
        }

        

    }

    IEnumerator waitSecondsToMove(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - playerHeight);
    }
}
