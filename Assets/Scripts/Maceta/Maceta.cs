using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maceta : MonoBehaviour {
    public Lanzador lanzador;
    // Use this for initialization
    public bool WIN;
	void Start () {
        lanzador = GameObject.Find("Player").GetComponent<Lanzador>();
        Debug.LogError("! " + lanzador.name);
        WIN = false;
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Down")
        {
           // lanzador.TryCount--;
            DestroyObject(this.gameObject);
        }
        else if(collision.gameObject.name == "Enemy")
        {
            WIN = true;
            lanzador.setWin(true);
            Debug.Log("hit");
            
        }    
    }

    // Update is called once per frame
    void Update () {
		
	}
}
