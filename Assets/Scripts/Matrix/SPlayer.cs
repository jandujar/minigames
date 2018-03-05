using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayer : MonoBehaviour
{

    public GameManager gm;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        RaycastHit2D rc = Physics2D.Raycast(transform.position, movement.normalized, movement.magnitude, LayerMask.NameToLayer("Default"), 1.0f);

        if (rc.collider != null && rc.collider.tag == "GameController")
        {
            movement = Vector3.zero;
        }

        transform.Translate(movement * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Bullet")
        {
            gm.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }
}
