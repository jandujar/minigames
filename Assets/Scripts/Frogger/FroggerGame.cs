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

    private GameObject[,] grid;
    private bool moving = false;
    private float playerX = 0;
    private float playerZ;


    void Start () {
        grid = new GameObject[rows, cols];
        float initZ = -(cols / 2.0f) * scale + 0.5f;
        playerZ = cols / 2;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                grid[i, j] = Instantiate(prefabTerrain, new Vector3(i * scale, 0, initZ + (j * scale)), transform.rotation);
                grid[i, j].transform.SetParent(gameObject.transform);
                grid[i, j].GetComponent<FroggerTerrain>().initialState = cols / 3;
                grid[i, j].GetComponent<FroggerTerrain>().currentState = (cols - j) % 3;
                if (i > 0 && i < 4) {
                    grid[i, j].GetComponent<FroggerTerrain>().type = 1;
                }
            }
        }
        StartCoroutine(UpdateStates());
    }


    void Update() {
        if (Input.GetKeyDown("space")) {
            Debug.Log("SPACE: " + playerX + " " + cols);
            if (!moving && playerX < rows - 1) {
                playerX++;
                StartCoroutine(MoveTo(player.transform.position.x + scale));
            }
        }
    }


    IEnumerator MoveTo(float target_pos) {
        moving = true;
        float dt = Time.deltaTime;
        while (player.transform.position.x + (moveSpeed * scale * dt) < target_pos) {
            player.transform.position = new Vector3(player.transform.position.x + (moveSpeed * scale * dt), player.transform.position.y, player.transform.position.z);
            yield return new WaitForSeconds(dt);
            dt = Time.deltaTime;
        }
        player.transform.position = new Vector3(target_pos, player.transform.position.y, player.transform.position.z);
        moving = false;
    }

    IEnumerator UpdateStates()
    {
        float t = Time.deltaTime;
        while (true)
        {
            Debug.Log((Time.deltaTime - t )/ 1000);
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    grid[i, j].GetComponent<FroggerTerrain>().UpdateState();
                }
            }
            t = Time.deltaTime;
            yield return new WaitForSeconds(1);
        }

    }

}
