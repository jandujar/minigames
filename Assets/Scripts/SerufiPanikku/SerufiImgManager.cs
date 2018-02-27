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
            int imgRand = Random.Range(0, 10);
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("Img "+imgRand);
            gameRenderer.material = selfieToPrint[imgRand];
        }        
    }
}
