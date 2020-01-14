using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction{
    up, down, right, left
}
public class SnakeControllerKike : MonoBehaviour
{
    Vector2 targetPosition;
    Vector2 targetNewPosition;

    public Text score;

    Direction direccion;

    public float speed = 1.1f;

    [SerializeField]
    private List<GameObject> snake;
    [SerializeField]
    private GameObject cuerpo;
    [SerializeField]
    private GameObject snakePadre;

    Vector2 lastDirection = Vector2.up;

    private List<Vector2> tablaDirecciones = new List<Vector2>();
    private List<Vector2> tablaRotaciones = new List<Vector2>(); 

    float rotacionPersoanje = 90;

    private bool moveApple;

    private bool changeColor;

    GameManager gameManager = null;

    private bool start = false;

    [SerializeField]
    private Material m1;
    [SerializeField]
    private Material m2;

    [SerializeField]
    private GameObject  puerta;

    [SerializeField]
    private Manzana manzana;

    private bool destroyPuerta = true;

    
    private AudioSource audioSource;

    public void init(GameManager gm)
    {
        gameManager = gm;
        this.gameManager = gm;
    }


    // Start is called before the first frame update
    void Start()
    {          
        audioSource = GetComponent<AudioSource>();
        tablaDirecciones.Add((Vector2) snake[0].transform.position + Vector2.up);
        tablaRotaciones.Add(Vector2.up);
        for (int i = 1; i < snake.Count; i++)
        {
            tablaDirecciones.Add((Vector2) snake[i].transform.position + Vector2.up);
            tablaRotaciones.Add(Vector2.up);

        }

        targetPosition = (Vector2) snake[0].transform.position + Vector2.up;
        lastDirection = Vector2.up;
        moveApple = true;

        changeColor = true;
    }

    // Update is called once per frame
    void Update()
    {  

        if(start){

            if(targetPosition == (Vector2) snake[0].transform.position){

                Vector2 direccion = targetNewPosition;
                lastDirection = targetNewPosition;
                for (int i = snake.Count-1; i > 0; i--)
                {
                    tablaDirecciones[i] = tablaDirecciones[i-1];
                    tablaRotaciones[i] = tablaRotaciones[i-1];
                }
                
                tablaDirecciones[0] = (Vector2) snake[0].transform.position+direccion;
                tablaRotaciones[0] = targetNewPosition;
                targetPosition = (Vector2) snake[0].transform.position+direccion;
            }else {
                if(Input.GetAxis("Horizontal") < 0 && lastDirection.x != 1){ targetNewPosition = Vector2.left;
                }else if(Input.GetAxis("Horizontal") > 0 && lastDirection.x != -1){ targetNewPosition = Vector2.right;
                }else if(Input.GetAxis("Vertical") > 0 && lastDirection.y != -1){ targetNewPosition = Vector2.up;
                }else if(Input.GetAxis("Vertical") < 0 && lastDirection.y != 1){ targetNewPosition = Vector2.down;
                } else targetNewPosition = lastDirection;

            }

            for (int i = 0; i < snake.Count; i++)
            {   
                if(tablaRotaciones[i].x == 1) rotacionPersoanje = -90f;
                else if(tablaRotaciones[i].x == -1) rotacionPersoanje = 90f;
                else if(tablaRotaciones[i].y == 1) rotacionPersoanje = 0f;
                else  rotacionPersoanje = 180f;

                snake[i].transform.rotation = Quaternion.Euler(0,0,rotacionPersoanje);
                snake[i].transform.position = Vector3.MoveTowards(snake[i].transform.position, tablaDirecciones[i], speed*Time.deltaTime);
                
            }
        }
    }

    public Direction getDireccion(){

        return direccion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Apple"){
            GameObject newCuerpo = Instantiate(cuerpo, snakePadre.transform, false);
            newCuerpo.transform.position = snake[snake.Count-1].transform.position;
            tablaDirecciones.Add(tablaDirecciones[tablaDirecciones.Count-1]);
            tablaRotaciones.Add(tablaRotaciones[tablaRotaciones.Count-1]);

            if(changeColor) {newCuerpo.GetComponent<Renderer>().material.color = m1.color; changeColor = false;
            }else {newCuerpo.GetComponent<Renderer>().material.color = m2.color; changeColor = true;}
            
            snake.Add(newCuerpo);
            
            audioSource.Play();

            score.text = "" + (int.Parse(score.text)+100);

            
            if(int.Parse(score.text) > 900){
                if(destroyPuerta){
                    Destroy(puerta.gameObject);
                    manzana.setPosX(14);
                    destroyPuerta = false;
                }                    
            } 

            if(int.Parse(score.text) > 2000){
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }

            speed += 0.15f;
        }


        if(other.tag == "Body" || other.tag == "Wall"){
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);

        }


    }

    public void startGame(){
        start = true;
    }

}
