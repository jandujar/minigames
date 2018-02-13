using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardPlayer : MonoBehaviour {

    private float v;
    private float h;
    private InputManager IpManager;
    [HideInInspector]
    public float Power = 0;
    [SerializeField]
    private float MaxPower = 50;
    public Rigidbody BallRb;
    private bool HasShot = false;
    private bool PlayerShot = false;
    private GameManager Gm;

    // Use this for initialization
    void Start () {
        IpManager = new InputManager();
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("UICanvas").transform.GetChild(0).transform.GetChild(0).gameObject.activeSelf) {
            return;
        }

        ShotLine();

        v = IpManager.GetAxisVertical();
        h = IpManager.GetAxisHorizontal();

        transform.Rotate(0, 0, v * Time.deltaTime * 20);
        if (transform.eulerAngles.z < 40 && transform.eulerAngles.z > 30) {
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        if (transform.eulerAngles.z > 360 - 40 && transform.eulerAngles.z < 360 - 30)
        {
            transform.rotation = Quaternion.Euler(0, 0, 360-30);
        }

        if (IpManager.GetButton(InputManager.MiniGameButtons.BUTTON1)) {
            if (PlayerShot) {
                return;
            }

            if (Power < MaxPower)
            {
                transform.GetChild(0).transform.position += transform.right / 5;
                Power += Time.deltaTime * 100;
            }
            else
            {
                Power = MaxPower;
            }
        }

        if (IpManager.GetButtonUp(InputManager.MiniGameButtons.BUTTON1)) {
            if (PlayerShot)
            {
                return;
            }

            StartCoroutine(Shot());
            StartCoroutine(SecondsToWin());
            HasShot = true;
            PlayerShot = true;
        }

        if (HasShot) {
            transform.GetChild(0).transform.position -= transform.right;
        }


    }

    private IEnumerator SecondsToWin()
    {
        yield return new WaitForSecondsRealtime(10f);
        Gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

    IEnumerator Shot()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        BallRb.AddForce(transform.TransformDirection(-Vector3.right) * Power, ForceMode.Impulse);
        HasShot = false;

    }

    private void ShotLine() {
        Ray a = new Ray(transform.position, -transform.right);
        Ray b;
        RaycastHit hit;

        if (Deflect(a, out b, out hit))
        {
            Debug.DrawLine(a.origin, hit.point);
            Debug.DrawLine(b.origin, b.origin + 3 * b.direction);
        }
    }

    private bool Deflect(Ray ray, out Ray deflected, out RaycastHit hit)
    {

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 normal = hit.normal;
            Vector3 deflect = Vector3.Reflect(ray.direction, normal);

            deflected = new Ray(hit.point, deflect);
            return true;
        }

        deflected = new Ray(Vector3.zero, Vector3.zero);
        return false;
    }
}
