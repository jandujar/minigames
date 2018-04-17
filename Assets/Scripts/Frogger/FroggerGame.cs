using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerGame : MonoBehaviour {

    public int rows = 9;
    public int cols = 7;
    public float scale = 1.1f;
    public float moveSpeed = 5;
    public GameObject prefabTerrain;
    public GameObject player;
    public GameObject partLose;

    private GameObject[,] grid;
    private bool moving = false;
    private int playerX = 0;
    private int playerZ;

    private bool playing = true;

   


    void Start () {
        grid = new GameObject[rows, cols];
        float initZ = -(cols / 2.0f) * scale + 0.5f;
        playerZ = cols / 2;
        int n = 4;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                grid[i, j] = Instantiate(prefabTerrain, new Vector3(i * scale, 0, initZ + (j * scale)), transform.rotation);
                grid[i, j].transform.SetParent(gameObject.transform);
                grid[i, j].GetComponent<FroggerTerrain>().initialState = cols / 3;
                grid[i, j].GetComponent<FroggerTerrain>().currentState = (cols - j + i) % 3;
                if (i > 0 && i < 4)
                {
                    grid[i, j].GetComponent<FroggerTerrain>().type = 1;
                }

                else if (i > 4 && i < rows - 1)
                {
                    grid[i, j].GetComponent<FroggerTerrain>().type = 2;

                    grid[i, j].GetComponent<FroggerTerrain>().currentState = j % n;
                    grid[i, j].GetComponent<FroggerTerrain>().initialState = n - 1;
                }

                else if (i == rows - 1) {
                    grid[i, j].GetComponent<FroggerTerrain>().type = 3;
                }
            }
            if (i > 4 && i < rows - 1)
            {
                n--;
            }
        }
        StartCoroutine(UpdateStates());
    }


    void Update()
    {
        if (!playing) return;
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            Debug.Log("SPACE: " + playerX + " " + playerZ);
            if (!moving && playerX < rows - 1)
            {
                StartCoroutine(MoveTo(player.transform.position.x + scale));
            }
        }
        
    }

    public void CheckGameState() {
        if (moving) return;
        if (grid[playerX, playerZ].GetComponent<FroggerTerrain>().type == 1 &&
            grid[playerX, playerZ].GetComponent<Renderer>().material.color == Color.red)
        {
            EndGame(false);
        }
        else if (grid[playerX, playerZ].GetComponent<FroggerTerrain>().type == 2 &&
                grid[playerX, playerZ].GetComponent<Renderer>().material.color == Color.red)
        {
            EndGame(false);
        }
        else if (grid[playerX, playerZ].GetComponent<FroggerTerrain>().type == 3) {
            EndGame(true);
        }
        Debug.Log("Player at " + playerX + ", " + playerZ + " at " + grid[playerX, playerZ].GetComponent<Renderer>().material.color);
    }

    void EndGame(bool win) {
        playing = false;
        if (win)
        {
            StartCoroutine(GoUp());
            Debug.Log("Win");
        }
        else {
            Debug.Log("Lose");
            StartCoroutine(DestroyPlayer());
        }

        StartCoroutine(FinishGame(win));
    }

    IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(1);
        player.GetComponent<MeshRenderer>().enabled = false;
        partLose.SetActive(true);
    }


    IEnumerator GoUp()
    {
        float dt = Time.deltaTime;
        while (true)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + (moveSpeed * scale * dt), player.transform.position.z);
            yield return new WaitForSeconds(dt);
            dt = Time.deltaTime;
            moveSpeed += dt;
        }
    }

    IEnumerator FinishGame(bool win)
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("Game").GetComponent<Frogger>().EndGame(win);
    }


    IEnumerator MoveTo(float target_pos) {
        moving = true;
        float dt = Time.deltaTime;
        Quaternion targetRotation = player.transform.localRotation *= Quaternion.AngleAxis(-90, Vector3.forward);
        while (player.transform.position.x + (moveSpeed * scale * dt) < target_pos) {
            player.transform.position = new Vector3(player.transform.position.x + (moveSpeed * scale * dt), player.transform.position.y, player.transform.position.z);
            player.transform.localRotation *= Quaternion.AngleAxis(-90 * moveSpeed * dt, Vector3.forward);
            yield return new WaitForSeconds(dt);
            dt = Time.deltaTime;
        }
        player.transform.position = new Vector3(target_pos, player.transform.position.y, player.transform.position.z);
        player.transform.localRotation = targetRotation;
        moving = false;
        playerX++;
        CheckGameState();
    }

    IEnumerator UpdateStates()
    {
        while (true)
        {
            if (!playing) break;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    grid[i, j].GetComponent<FroggerTerrain>().UpdateState();
                }
            }
            CheckGameState();
            yield return new WaitForSeconds(0.5454545454545455f);
        }

    }

}
