using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BilliardPlayer : MonoBehaviour {

    private float v;

    [HideInInspector]
    public float Power = 0;
    [SerializeField]
    private float MaxPower = 50;
    public Rigidbody BallRb;
    private bool HasShot = false;
    private bool PlayerShot = false;
    private GameManager Gm;
    private bool StartCountdown = false;
    public Text CountDown;
    public BilliardBall BBall;

    // Use this for initialization
    void Start () {
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        CountDown.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("UICanvas").transform.GetChild(0).transform.GetChild(0).gameObject.activeSelf) {
            return;
        }

        if (!StartCountdown) {
            CountDown.gameObject.SetActive(true);
            StartCoroutine(SecondsToWin());
            StartCountdown = true;
        }

        ShotLine();

        v = InputManager.Instance.GetAxisVertical();

        transform.Rotate(0, 0, v * Time.deltaTime * 20);
        if (transform.eulerAngles.z < 40 && transform.eulerAngles.z > 30) {
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        if (transform.eulerAngles.z > 360 - 40 && transform.eulerAngles.z < 360 - 30)
        {
            transform.rotation = Quaternion.Euler(0, 0, 360-30);
        }

        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1)) {
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

        if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON1)) {
            if (PlayerShot)
            {
                return;
            }

            StartCoroutine(Shot());
            HasShot = true;
            PlayerShot = true;
        }

        if (HasShot) {
            transform.GetChild(0).transform.position -= transform.right;
        }


    }

    private IEnumerator SecondsToWin()
    {
        CountDown.text = "Seconds Remaining: 10";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 9";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 8";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 7";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 6";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 5";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 4";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 3";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 2";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 1";
        yield return new WaitForSecondsRealtime(1f);
        CountDown.text = "Seconds Remaining: 0";
        yield return new WaitForSecondsRealtime(1f);
        Gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

    IEnumerator Shot()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        BallRb.AddForce(transform.TransformDirection(-Vector3.right) * Power, ForceMode.Impulse);
        HasShot = false;
        BBall.VelocityLoose = true;

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
