using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngPicross3D : MonoBehaviour
{

    [SerializeField] int maxlifes;
    [SerializeField] GameObject fatherLife;

    private int lifes;
    private int badCubes;
    private int badCubesNum;
          
    // Start is called before the first frame update
    void Start() {
        if (maxlifes <= 0) maxlifes = 3;
        lifes = maxlifes;
        badCubes = GameObject.FindGameObjectsWithTag("Walls").Length;
        badCubesNum = GameObject.FindGameObjectsWithTag("Walls").Length; 
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SetTotalCubes() {
        badCubesNum--;
        Debug.Log("Total bad cubes: " + badCubesNum + " / " + badCubes);
        if (badCubesNum == 0) {
            Debug.Log("You win!!");
        }
    }

    public void SetLife() {
        lifes--;
        fatherLife.transform.GetChild(lifes).GetComponent<Animator>().SetBool("delete", true);
        if(lifes == 0) {
            Debug.Log("You lose!!");
        }
    }
}
