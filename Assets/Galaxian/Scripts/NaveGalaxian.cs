using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveGalaxian : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private GameManager gameManager;
    public GameObject bullet;
    public bool alive = false;

    Animator animator;

    int nextPoint = 0;

    public void init(GameManager gm)
    {
        gameManager = gm;
        animator = GetComponent<Animator>();
        animator.SetBool("alive", true);
    }
    void Update()
    {
        if (alive)
        {
            Movement();
            Shoot();
        }
    }

    void Shoot()
    {
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4))
        {
            var shot = Instantiate(bullet, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(shot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void Die()
    {
        alive = false;
    }

    void Movement()
    {
        if (InputManager.Instance.GetAxisHorizontal() > 0 && transform.position.x < 3)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime * InputManager.Instance.GetAxisHorizontal(), 0, 0));
        }
        else if (InputManager.Instance.GetAxisHorizontal() < 0 && transform.position.x > -3)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime * -InputManager.Instance.GetAxisHorizontal(), 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "DestroyBullet")
        {
            animator.SetBool("alive", false);
            ManejadorDeSonido.Instance.playPlayerDeath();
            Invoke("Die", 1f);
        }

    }
}
