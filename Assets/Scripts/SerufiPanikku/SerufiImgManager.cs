using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerufiImgManager : MonoBehaviour {

    public List<Material> selfieToPrint = new List<Material>();

    public GameObject gamePhone;
    private Renderer gameRenderer;
    // Use this for initialization
	void Start ()
    {
        gameRenderer = this.gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeImgGame()
    {
        StartCoroutine(changeImgTest());
    }

    public IEnumerator changeImgTest()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("Img 0");
            gameRenderer.material = selfieToPrint[0];
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("Img 1");
            gameRenderer.material = selfieToPrint[1];
        }        
    }
}
