using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    Transform myT;
    private bool death = false;
    private bool deathActive = false;
    private bool started = false;
    private float moveVer;
    private float moveHor;
    public float spd = 50f;
    public float rotationSpd = 1f;
    public float maxposy = 5.9f;
    public float maxposx = 10f;
    private Vector3 tmpPosition;
    public DestroyTheWorld gameEngine;
    private GameManager gameManager;
    public AudioClip explosion;
    private AudioSource source;

    void Awake()
    {
        myT = transform;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (started)
        {
            if (!death)
            {
                Movement();
                Rotation();
            }
            else if (death && !deathActive)
            {
                DeathExplosion();
            }
            else if (death && deathActive)
            {
                if (!transform.Find("SmallExplosionEffect").GetComponent<ParticleSystem>().isPlaying)
                {
                    EndGame();
                }
            }
        }
    }

    private void Movement()
    {
        myT.position += transform.forward * Time.deltaTime * spd;
    }

    private void Rotation() {
        float yaw = rotationSpd * Time.deltaTime * InputManager.Instance.GetAxisHorizontal();
        float pitch = rotationSpd * Time.deltaTime * InputManager.Instance.GetAxisVertical();

        myT.Rotate(pitch,yaw,0);
    }

    private void DeathExplosion()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;
        transform.Find("FlameThrowerEffect").gameObject.SetActive(false);
        transform.Find("SmallExplosionEffect").GetComponent<ParticleSystem>().Play();
        source.PlayOneShot(explosion, .5f);
        deathActive = true;
    }

    public void StartGame(GameManager gm)
    {
        started = true;
        gameManager = gm;
    }

    public void EndGame()
    {
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            death = true;
        }
    }
}
