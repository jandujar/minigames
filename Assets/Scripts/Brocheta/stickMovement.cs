using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickMovement : MonoBehaviour {

    public GameObject leftSpawn;
    public GameObject rightSpawn;
    public GameObject[] meat;
    Color halfDone;
    Color almostDone;
    Color done;
    int intShader;
    bool canGo;


    void Start()
    {
        intShader = 0;
        halfDone = new Color(150, 88, 49);
        almostDone = new Color(107, 61, 31);
        done = new Color(79, 34, 5);
        canGo = true;
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * -50.0f;
        //float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //stick.transform.Rotate(0, x, 0);
        transform.Translate(0, 0, x);
    }
	
    IEnumerator inSmoke()
    {
        canGo = false;
        intShader++;
        yield return new WaitForSeconds(1);
        canGo = true;
    }

	void Update () {

        Debug.Log(intShader);
        move();

        if(intShader >= 0 && intShader <= 3)
        {
            for(int i = 0; i < meat.Length; i++)
            {
                Renderer rend = meat[i].GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("__MainColor", halfDone);
            }
        }
        else
        if (intShader > 3 && intShader <= 6)
        {
            for (int i = 0; i < meat.Length; i++)
            {
                Renderer rend = meat[i].GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("__MainColor", almostDone);
            }
        }
        else
        if (intShader > 6)
        {
            for (int i = 0; i < meat.Length; i++)
            {
                Renderer rend = meat[i].GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("__MainColor", done);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "left")
        {
            gameObject.transform.position = leftSpawn.transform.position;
        }
        else if (other.name == "right")
        {
            gameObject.transform.position = rightSpawn.transform.position;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.name == "area")
        {
            if (canGo)
            {
                StartCoroutine(inSmoke());
            }
        }
    }
}
