using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoBow : MonoBehaviour {

    public GameObject bowString;
    public GameObject arrow;
    public GameObject gameCamera;

    private bool charging = false;
    private bool shooting = false;

    void Update () {
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) {
            if (charging) return;
            charging = true;
            StartCoroutine(ChargeShoot());
        }

        if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON1))
        {
            if (shooting) return;
            shooting = true;
            arrow.GetComponent<Rigidbody>().AddForce(gameCamera.transform.forward * 2000);
            arrow.GetComponent<Rigidbody>().useGravity = true;
            gameCamera.GetComponent<Camera>().enabled = false;
            arrow.GetComponent<AudioSource>().PlayOneShot(arrow.GetComponent<ArcoArrow>().shoot);
            arrow.GetComponent<ArcoArrow>().Shooted();
        }
        if (!shooting)
        {
            float moveHor = InputManager.Instance.GetAxisVertical();
            float moveVer = InputManager.Instance.GetAxisHorizontal();

            Vector3 rotateValue = new Vector3(moveHor, moveVer * -1, 0);
            gameCamera.transform.eulerAngles = gameCamera.transform.eulerAngles - rotateValue;

        }
    }

    IEnumerator ChargeShoot() {
        float timeLeft = 0.5f;
        while (!shooting && timeLeft > 0) {
            yield return new WaitForFixedUpdate();
            bowString.transform.position = new Vector3(bowString.transform.position.x, bowString.transform.position.y, bowString.transform.position.z - Time.deltaTime);
            arrow.transform.position = new Vector3(arrow.transform.position.x, arrow.transform.position.y, arrow.transform.position.z - Time.deltaTime);
            gameCamera.GetComponent<Camera>().fieldOfView -= Time.deltaTime * 10;
            timeLeft -= Time.deltaTime;
        }
    }
}
