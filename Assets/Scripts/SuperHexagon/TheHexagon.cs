using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHexagon : MonoBehaviour
{
    private GameManager gameManager;
    //--------------------------------------
    [SerializeField] GameObject CameraPivot;
    [SerializeField] ArrowHexagon Arrow;
    [SerializeField] Transform Acumulator;

    [Header("Parts var")]
    public float speed;
    public float speedCamera;
    public float PartsXSecond;
    public float LimitTime;

    [Header("Arrow var")]
    public float arrowSpeed = 350;
    bool accceleration = false;


    public bool DEAD;
    public bool END;

    public List<GameObject> partHexagon = new List<GameObject>();
    public List<GameObject> partTarget = new List<GameObject>();

    int Part;
    int lastPart;
    int lastCase;
    float crono;
    float sad;
    int RandomRot;
    bool direction;
    int HexOption;
    bool repite;

    public void init(GameManager gm){
        gameManager = gm;
        Invoke("StartGame",4);
        Arrow.speed = arrowSpeed;
    }
    
    // Update is called once per frame
    void Update(){
        
        if (crono >= (LimitTime + 5))
            Win();
        crono += Time.deltaTime;

        //Rotation Camera
        RandomRot = Random.Range(0, 2);
        if (RandomRot == 0 && (crono % 3) <= 0.02)
            direction = !direction;
        
        if (direction)
                CameraPivot.transform.Rotate(Vector3.up, speedCamera * Time.deltaTime);
            else
                CameraPivot.transform.Rotate(Vector3.up, -speedCamera * Time.deltaTime);

        if (crono >= (LimitTime+5)/2 && !accceleration){
            PartsXSecond *= 1.3f;
            speed *= 1.3f;
            //Arrow.speed *= 1.3f;
            accceleration = true;
        }
    }
    
    private void StartGame()
    {        
        StartCoroutine(generator());
    }

    public IEnumerator generator(){
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f/PartsXSecond);
            
                Part = Random.Range(0, 6);
            
                HexOption = Random.Range(0, 4);

            if (HexOption == 3 && lastCase == 3){
                if (lastPart == 5) lastPart -= 2;
                    Part = lastPart+1;
            }

            switch (HexOption)
            {
                //Para 1 parte
                case 0:
                    StartCoroutine(CreateHexagon(Part));
                    break;
                //Para 3 partes 1Si_1NO
                case 1:
                    Part = 0;
                    StartCoroutine(CreateHexagon(Part));
                    StartCoroutine(CreateHexagon(Part + 2));
                    StartCoroutine(CreateHexagon(Part + 4));
                    break;
                //Para 3 partes 1Si_1NO
                case 2:
                    Part = 1;
                    StartCoroutine(CreateHexagon(Part));
                    StartCoroutine(CreateHexagon(Part + 2));
                    StartCoroutine(CreateHexagon(Part + 4));
                    break;
                //Para todas -1 parte
                case 3:
                    if (Part !=0)
                        StartCoroutine(CreateHexagon(0));
                    if (Part != 1)
                        StartCoroutine(CreateHexagon(1));
                    if (Part != 2)
                        StartCoroutine(CreateHexagon(2));
                    if (Part != 3)
                        StartCoroutine(CreateHexagon(3));
                    if (Part != 4)
                        StartCoroutine(CreateHexagon(4));
                    if (Part != 5)
                        StartCoroutine(CreateHexagon(5));
                    break;
                //Para partes simetricas
                case 4:
                    if (Part >= 3) Part -= 3;
                        StartCoroutine(CreateHexagon(Part));
                        StartCoroutine(CreateHexagon(Part+3));
                    break;
            }

            lastCase = HexOption;
            lastPart = Part;
        }
    }

    public IEnumerator CreateHexagon(int Part)
    {
        GameObject newHexagon = Instantiate(partHexagon[Part], partHexagon[Part].transform.position, partHexagon[Part].transform.rotation, Acumulator) as GameObject;   
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / speed;
            newHexagon.transform.localScale = Vector3.Lerp(newHexagon.transform.localScale, partTarget[Part].transform.localScale, t);
            yield return null;
        }
    }

    public void Lose() {
        if (DEAD)
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
    public void Win() {
        if (END)
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);

    }
}
