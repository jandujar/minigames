using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bullet;
    private GameObject[] bulletPool;
    public Matrix game;
    public float time_between_bullets = 0.2f;

    // Use this for initialization
    void Start()
    {
        int ammount = 20;
        bulletPool = new GameObject[ammount];
        for(int i = 0; i < ammount; i++)
        {
            bulletPool[i] = Instantiate(bullet);
            bulletPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SpawnBullet()
    {
        while (true)
        {
            float x, y;
            x = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
            y = Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2);

            GameObject b = GetBullet();

            b.SetActive(true);
            b.transform.SetPositionAndRotation(new Vector3(x, y), transform.rotation);
            b.transform.Rotate(new Vector3(0, 0, 90));

            yield return new WaitForSeconds(time_between_bullets);
        }
    }

    private GameObject GetBullet()
    {
        for (int i = 0; i < bulletPool.Length; i++)
        {
            if (!bulletPool[i].activeSelf)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
}