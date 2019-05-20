using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBarril : MonoBehaviour {

    [SerializeField] GameObject barrilInstance;
    [SerializeField] GameObject parent;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void InstatiateObject() {
        Instantiate(barrilInstance, new Vector3(-6.68f, 2.839f, 0), barrilInstance.transform.rotation);
    }
}
