using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTargetPoint : MonoBehaviour {

    [SerializeField] GameObject objectiveObject;
    bool shoot;
    GameObject parent;
    [SerializeField] Color paintColor;
    bool painting;
    [SerializeField] EngPicross3D Engine;

    // Start is called before the first frame update
    void Start() {
        shoot = false;
        painting = false;
    }

    // Update is called once per frame
    void Update() {
        //Boton disparar
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) {
            shoot = true;
        }
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)) {
            painting = true;
        }
        else if(InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON3)) {
            painting = false;
        }

        if (shoot) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (objectiveObject.transform.position - transform.position), out hit)){
                //Debug.DrawRay(transform.position, (objectiveObject.transform.position - transform.position), Color.yellow);
                //Debug.Log("Golpeo a: " + hit.collider.gameObject.name);
                if(hit.collider.gameObject.name == "redCube") {
                    if (!painting && !hit.collider.gameObject.GetComponent<DeleteCube>().paint) {
                        hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                        Engine.SetTotalCubes();
                    }
                    else if(painting) {
                        if (!hit.collider.gameObject.GetComponent<DeleteCube>().paint) { 
                            for (int i = 0; i < hit.collider.gameObject.GetComponent<Renderer>().materials.Length; i++) {
                                hit.collider.gameObject.GetComponent<Renderer>().materials[i].color = paintColor;
                            }
                            hit.collider.gameObject.GetComponent<DeleteCube>().paint = true;
                        }
                        else {
                            for (int i = 0; i < hit.collider.gameObject.GetComponent<Renderer>().materials.Length; i++) {
                                hit.collider.gameObject.GetComponent<Renderer>().materials[i].color = Color.white;
                            }
                            hit.collider.gameObject.GetComponent<DeleteCube>().paint = false;
                        }
                    }
                }
                else if(hit.collider.gameObject.name == "Box002") {
                    if(!painting && !hit.collider.gameObject.GetComponent<DeleteCube>().paint && !hit.collider.gameObject.GetComponent<DeleteCube>().broke) {
                        parent = hit.collider.gameObject.transform.parent.gameObject;
                        parent.transform.GetChild(0).gameObject.SetActive(true);
                        Engine.SetLife();
                        for (int i = 0; i < hit.collider.gameObject.GetComponent<Renderer>().materials.Length; i++) {
                            hit.collider.gameObject.GetComponent<Renderer>().materials[i].color = paintColor;
                        }
                        hit.collider.gameObject.GetComponent<DeleteCube>().paint = true;
                        hit.collider.gameObject.GetComponent<DeleteCube>().broke = true;
                    }
                    else if(painting){
                        if (!hit.collider.gameObject.GetComponent<DeleteCube>().paint && !hit.collider.gameObject.GetComponent<DeleteCube>().broke) {
                            for (int i = 0; i < hit.collider.gameObject.GetComponent<Renderer>().materials.Length; i++) {
                                hit.collider.gameObject.GetComponent<Renderer>().materials[i].color = paintColor;
                            }
                            hit.collider.gameObject.GetComponent<DeleteCube>().paint = true;
                        }
                        else {
                            for (int i = 0; i < hit.collider.gameObject.GetComponent<Renderer>().materials.Length; i++) {
                                hit.collider.gameObject.GetComponent<Renderer>().materials[i].color = Color.white;
                            }
                            hit.collider.gameObject.GetComponent<DeleteCube>().paint = false;
                        }
                    }
                    
                    
                }
            }
            shoot = false;
        }
    }
}
