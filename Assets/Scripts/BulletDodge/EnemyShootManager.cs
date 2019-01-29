using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace oscar_vergara_jimenez
{
    public class EnemyShootManager : MonoBehaviour
    {
        private GameManager gameManager;
        public List<Enemy[]> enemyGroups;
        int enemyToShoot;
        public float shootDelay;
        public float startTimer;

        public void init(GameManager gm)
        {
            gameManager = gm;
        }
        void Start()
        {
            enemyGroups = new List<Enemy[]>();
            for (int i = 0; i < transform.childCount; i++)
            {
                enemyGroups.Add(transform.GetChild(i).gameObject.GetComponentsInChildren<Enemy>());
            }
        }

        private void Update()
        {
            if (startTimer > 0)
            {
                startTimer--;
                if (startTimer <= 0)
                {
                    StartCoroutine(ShootDelay());
                }
            }
        }
        IEnumerator ShootDelay()
        {
            yield return new WaitForSeconds(shootDelay);
            shootDelay -= shootDelay/40;
            for (int i = 0; i < enemyGroups.Count; i++)
            {
                enemyToShoot = Random.Range(0, enemyGroups[i].Length);
                enemyGroups[i][enemyToShoot].Shoot();
                GetComponent<AudioSource>().Play();
            }
            StartCoroutine(ShootDelay());
            if (shootDelay < 0.75f)
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }
}
