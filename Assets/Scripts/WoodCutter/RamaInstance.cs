using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamaInstance : MonoBehaviour {

    public GameObject[] ramas = new GameObject[3];
    TypeRama type = TypeRama.RIGHT;
    float rand = 0f;

    private enum TypeRama
    {
        NONE,
        RIGHT,
        LEFT
    }

    // Use this for initialization
    public void init () {
        rand = Random.Range(0f, 10f);
        if(rand >= 6)
        {
            type = TypeRama.RIGHT;
        }else if(rand >= 2 && rand < 6)
        {
            type = TypeRama.LEFT;
        }else
        {
            type = TypeRama.NONE;
        }
        ramas[(int)type].gameObject.SetActive(true);
    }
}
