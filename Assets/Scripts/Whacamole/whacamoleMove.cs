using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whacamoleMove : MonoBehaviour {

    public IEnumerator moveCorutine;
    public bool active;

    private void Start() {
        moveCorutine = move();
    }



    IEnumerator move()
    {
        active = true;
        Debug.Log("active_true");
        yield return new WaitForSeconds(1.2f);
        Debug.Log("yield");
        active = false;
        Debug.Log("active_false");
        StopCoroutine(moveCorutine);
        Debug.Log("stop_corutine");
        this.gameObject.SetActive(false);
        Debug.Log("desactivar");
    }


}
