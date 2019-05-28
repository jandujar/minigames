using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody rb;

    public GameObject[] Effects;

    [SerializeField] AudioClip[] projectileAudios;
    AudioSource audio;

    private float tempTimer = 50f;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);

        audio = gameObject.AddComponent<AudioSource>();

        audio.clip = projectileAudios[1];
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);

        
    }


    private void OnCollisionEnter(Collision collision)
    {

        rb.constraints = RigidbodyConstraints.FreezeAll;

        if (collision.gameObject.tag == "EnemyShip"){  //the human
            Effects[0].GetComponent<ParticleSystem>().Play();
            audio.clip = projectileAudios[0];
            audio.Play();
            Invoke("LoseGame", 2);
        }
        else if (collision.gameObject.tag == "Finish"){ //the apple
            audio.clip = projectileAudios[2];
            audio.Play();
            Invoke("WinGame", 2);
        }
        else //the arrow hit something else, so we delete the camera of the arrow
        {
            audio.clip = projectileAudios[2];
            audio.Play();
            Invoke("ResetCamera", 1);

        }
    }

    private void WinGame()
    {
        GameObject.Find("Game").GetComponent<AppleShooterEngine>().WinGame();
    }

    private void LoseGame()
    {
        GameObject.Find("Game").GetComponent<AppleShooterEngine>().LoseGame();
    }

    private void ResetCamera()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject.GetComponent<Projectile>());
        GameObject.Find("Game").GetComponent<AppleShooterEngine>().cannotShootAnymore = false;
    }
}
