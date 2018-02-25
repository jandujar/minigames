using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoInstance : MonoBehaviour {

    public GameObject troncoCortado;
    public GameObject[] wood = new GameObject[5];
    private Rigidbody2D[] rdbWood = new Rigidbody2D[5];
    int count = 0;
    float power = 300f;
    Vector2 pos;

    void Awake()
    {
        for (int i = 0; i < 5; i++) {
            wood[i].gameObject.SetActive(false);
            pos = wood[i].transform.position;
            rdbWood[i] = wood[i].GetComponent<Rigidbody2D>();
        }   
    }

    // Update is called once per frame
    
	
	// Update is called once per frame
	void Update () {
        if (WoodCutter.instance.getIsCutting())
        {
            if (count == 5) {
                count = 0;
            }

            troncoCortado.gameObject.SetActive(false);
            wood[count].gameObject.SetActive(true);
            rdbWood[count].AddTorque(power);
            rdbWood[count].AddForce(Vector2.up * power);
            rdbWood[count].AddForce(Vector2.right * power);

            for (int i = 0; i < 5; i++) {
                if (wood[i].transform.position.x > -1)
                {
                    wood[i].transform.position = pos;
                    wood[i].gameObject.SetActive(false);
                }
            }



            StartCoroutine(waitSecondsToActive(0.2f));
            
            count++;
        }
    }

      
    

    IEnumerator waitSecondsToActive(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("ello co");
        troncoCortado.gameObject.SetActive(true);
    }

void resetPos()
    {
        
    }
}
