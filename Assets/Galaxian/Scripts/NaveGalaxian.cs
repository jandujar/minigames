using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveGalaxian : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private GameManager gameManager;
    public GameObject bullet;
    public bool alive = false;

    int nextPoint = 0;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }
    void Update()
    {
        if (alive)
        {
            Movement();
            Shoot();
        }
        else
        {
            //gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }

    void Shoot()
    {
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        alive = false;
    }

    void Movement()
    {
        if (InputManager.Instance.GetAxisHorizontal() > 0)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime * InputManager.Instance.GetAxisHorizontal(), 0, 0));
        }
        else if (InputManager.Instance.GetAxisHorizontal() < 0)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime * -InputManager.Instance.GetAxisHorizontal(), 0, 0));
        }
    }
}
