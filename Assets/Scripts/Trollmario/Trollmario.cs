using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace guillem_gracia {

    public class Trollmario : IMiniGame
    {
        GameManager gameManager;
        [SerializeField] GameObject[] allGameObjectsWithScript;

        int health;

        [SerializeField] Text txt;

        bool finished;

        bool init;

        public AudioSource audioWin, audioLose;

        public override void beginGame()
        {
            Debug.Log("BeginGame");
            init = true;
            health = 3;
            txt.text = health + " LIVES";
            foreach (GameObject go in allGameObjectsWithScript)
            {
                go.SetActive(true);
            }
        }

        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            foreach (GameObject go in allGameObjectsWithScript)
            {
                go.SetActive(false);
            }
            Debug.Log("InitGame");
            GameObject.Find("Collision").GetComponent<Renderer>().enabled = false;
            GameObject.Find("DieCollisions").GetComponent<Renderer>().enabled = false;
            gameManager = gm;
        }

        public void RestartGame()
        {
            if (finished) return;
            audioLose.Play();
            allGameObjectsWithScript[0].GetComponent<Character>().enabled = false;
            allGameObjectsWithScript[0].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (--health <= 0)
            {
                txt.text = "0 LIVES";
                EndGame(false);
                return;
            }
            txt.text = health + " LIVES";
            StartCoroutine(RestartGameCoroutine());

        }

        public void EndGame(bool win)
        {
            if (finished) return;
            allGameObjectsWithScript[0].GetComponent<Character>().enabled = false;
            allGameObjectsWithScript[0].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            finished = true;
            StartCoroutine(ChangeScene(win));
        }
        

        IEnumerator RestartGameCoroutine()
        {
            
            yield return new WaitForSecondsRealtime(audioLose.clip.length);
            allGameObjectsWithScript[0].GetComponent<Character>().enabled = true;
            for (int i = 0; i < allGameObjectsWithScript.Length; i++)
            {
                allGameObjectsWithScript[i].GetComponent<Entity>().Init();
            }
        }

        IEnumerator ChangeScene(bool win)
        {
            if (win)
            {
                audioWin.Play();
                allGameObjectsWithScript[0].GetComponent<Rigidbody2D>().gravityScale = 0;
                yield return new WaitForSecondsRealtime(audioWin.clip.length);
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
            else
            {
                yield return new WaitForSecondsRealtime(audioLose.clip.length);
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }

        public override string ToString()
        {
            return "Trollmario by ggracia";
        }
    }
}
