using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerufiImgManager : MonoBehaviour {

    public List<Material> selfieToPrint;

    Material gameMaterial;
	
    // Use this for initialization
	void Start ()
    {
        selfieToPrint = new List<Material>();
        gameMaterial = this.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator changeImgTest()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("Img 1");
            gameMaterial = selfieToPrint[1];
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("Img 0");
            gameMaterial = selfieToPrint[0];
        }        
    }
}
