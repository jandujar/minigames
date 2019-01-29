using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace laura_romo { 
    public class moveCrane : MonoBehaviour {
        private bool toLeft;
        public float craneSpeed;
        private bool instantiate;
        private float instantiateCount;
        [SerializeField] GameObject instaceBuilding;
        private GameObject actualPiece;
        [SerializeField] GameObject buildingFather;
        private int piecesPut;
        public bool gameStart;
        private GameManager gameManager;
        public bool winGame;
        
        public void init(GameManager gm) {
            gameManager = gm;
        }

        // Start is called before the first frame update
        void Start() {
            winGame = false;
            toLeft = false;
            instantiate = false;
            instantiateCount = 6;
            piecesPut = 0;
        }

        // Update is called once per frame
        void Update() {
            //Instantiate piece of building
            if (instantiateCount > 2) {
                if (!winGame) { 
                    actualPiece = Instantiate(instaceBuilding, this.transform);
                    instantiate = false;
                    instantiateCount = 0;
                }
                else {
                    EndGame(true);
                }
            }

            if (instantiate) {
                instantiateCount += Time.deltaTime;
            }

            //Move the crave
            if (toLeft) {
                for (int i = 0; i < craneSpeed; i++) {
                    transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
                }
                if (transform.position.x < -6.5) {
                    toLeft = false;
                }
            }
            else {
                for(int i = 0; i < craneSpeed; i++) {
                    transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                }
                if (transform.position.x > 6.01) {
                    toLeft = true;
                }
            }

            //Inputs
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) {
                if (gameStart) {
                    piecesPut++;
                    actualPiece.transform.parent = buildingFather.transform;
                    actualPiece.GetComponent<Rigidbody2D>().gravityScale = 1;
                    instantiate = true;
                    if (piecesPut == 10) {
                        winGame = true;
                    }
                    craneSpeed += 2;
                    
                }
            }
        }

        public void EndGame(bool win) {
            if (win) {
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
            else {
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }
    }
}
