using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCube : MonoBehaviour {

    public bool paint;
    public bool broke;

    // Start is called before the first frame update
    void Start() {
        paint = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void DestroyCube() {
        Destroy(this);
    }
}
