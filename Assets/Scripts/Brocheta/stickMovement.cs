using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickMovement : MonoBehaviour {

    public GameObject leftSpawn;
    public GameObject rightSpawn;
    public GameObject meatA;
    public GameObject meatB;
    public GameObject meatC;
    public GameObject meatD;
    Color halfDone;
    Color almostDone;
    Color done;
    int intShader;
    bool canGo;
    public bool win;


    void Start()
    {
        intShader = 0;
        halfDone = new Color(150, 88, 49);
        almostDone = new Color(107, 61, 31);
        done = new Color(79, 34, 5);
        canGo = true;
        meatA.SetActive(true);
        meatB.SetActive(false);
        meatC.SetActive(false);
        meatD.SetActive(false);
        win = false;
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
        move();

        if(intShader >= 1 && intShader <= 2)
        {
            meatA.SetActive(false);
            meatB.SetActive(true);
        }
        else
        if (intShader > 2 && intShader <= 4)
        {
            meatB.SetActive(false);
            meatC.SetActive(true);
        }
        else
        if (intShader > 4)
        {
                meatC.SetActive(false);
                meatD.SetActive(true);
                win = true;
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
