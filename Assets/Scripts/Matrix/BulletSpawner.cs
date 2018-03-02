using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    public GameObject bullet;
    public Matrix game;
    public float time_between_bullets = 0.2f;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnBullet());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator SpawnBullet()
    {
        while (game.started){
            float x, y;
            x = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
            y = Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2);
            Instantiate(bullet, new Vector3(x, y), transform.rotation);
            yield return new WaitForSeconds(time_between_bullets);
        }
    }
}
