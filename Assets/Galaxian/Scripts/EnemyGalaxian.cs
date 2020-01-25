using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGalaxian : MonoBehaviour
{
    float timer = 0;
    int contHor = 0;
    int contVer = 0;
    int seconds = 0;
    public bool alive = false;
    [SerializeField] float shootChance = 10f;
    public GameObject enemyShot;
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("alive", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                contHor++;
                seconds++;
                if (contHor > 4)
                {
                    TranslateEnemy(0, -0.5f);
                    contHor = 0;
                    contVer++;
                }
                else
                {
                    if (contVer % 2 == 0)
                    {
                        TranslateEnemy(0.5f, 0);
                    }
                    else
                    {
                        TranslateEnemy(-0.5f, 0);
                    }
                }

                timer = 0;


            }

            Shoot();

            if (transform.position.y < -2)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<NaveGalaxian>().alive = false;
            }
        }
    }

    void TranslateEnemy(float posX, float posY)
    {
        transform.Translate(new Vector2(posX, posY));

        if (seconds % 2 == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }

    }

    void Shoot()
    {
        var rnd = Random.Range(0, 10000);
        if (rnd < shootChance)
        {
            GameObject bullet = Instantiate(enemyShot, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "GalaxianEnemyShot")
        {
            anim.SetBool("alive", false);
            ManejadorDeSonido.Instance.playEnemyDeath();
            Invoke("Die", 0.4f);
        }
    }

    void Die()
    {
        alive = false;
        Destroy(gameObject);
    }
}
