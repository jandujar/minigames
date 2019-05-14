using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTargetPoint : MonoBehaviour {

    [SerializeField] GameObject objectiveObject;
    bool shoot;
    GameObject parent;

    // Start is called before the first frame update
    void Start() {
        shoot = false;
    }

    // Update is called once per frame
    void Update() {
        /* 
         float maxRange = 5;
        RaycastHit hit;
 
        if(Vector3.Distance(transform.position, player.position) < maxRange) {
            if(Physics.Raycast(transform.position, (player.position - transform.position), out hit, maxRange)) {
            if(hit.transform == player) {
                // In Range and i can see you!
            }
        }
        */
        //Boton disparar
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) {
            shoot = true;
        }

        if (shoot) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (objectiveObject.transform.position - transform.position), out hit)){
                Debug.DrawRay(transform.position, (objectiveObject.transform.position - transform.position), Color.yellow);
                Debug.Log("Golpeo a: " + hit.collider.gameObject.name);
                if(hit.collider.gameObject.name == "redCube") {
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                }
                else if(hit.collider.gameObject.name == "Box002") {
                    parent = hit.collider.gameObject.transform.parent.gameObject;
                    parent.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            shoot = false;
        }
    }
}
