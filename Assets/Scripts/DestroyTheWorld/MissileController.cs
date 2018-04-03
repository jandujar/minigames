using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    Transform myT;
    private bool death = false;
    private bool deathActive = false;
    private float moveVer;
    private float moveHor;
    public float spd = 50f;
    public float rotationSpd = 1f;
    public float maxposy = 5.9f;
    public float maxposx = 10f;
    private Vector3 tmpPosition;
    public DestroyTheWorld gameEngine;

    void Awake()
    {
        myT = transform;
    }
	
	// Update is called once per frame
	void Update () {

        if (!death)
        {
            moveVer = -InputManager.Instance.GetAxisVertical();
            moveHor = InputManager.Instance.GetAxisHorizontal();

            Movement();
            Rotation();
        } else if (death && !deathActive)
        {
            DeathExplosion();
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


        deathActive = true;
    }

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wall")
        {

        }
    }
}
