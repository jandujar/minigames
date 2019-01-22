using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crupier : MonoBehaviour
{
    public bool StartRep = false;
    private GameManager gameManager;
    //-------------

    bool crupierMove = false;

    private int result, nRandom, pointsPlayer, pointsCrupier, cardsPlayer, cardsCrupier;

    bool wait = false;
    private float waitTime;
    public float maxWaitTime;

    public GameObject CartaP, CartaC;

    public Material[] Texturas;

    private Vector3 posP,posC;
    //[SerializeField] Text pointsText;

    public void init(GameManager gm)
    {
        posP = CartaP.transform.position;
        posC = CartaC.transform.position;

        waitTime = maxWaitTime;
        gameManager = gm;
        CrupierAttack();       
    }

    // Update is called once per frame
    void Update()
    {
        if (StartRep)
        {
            // "Shift!!"
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)){
                if (!wait){
                    MoreCards();
                    Pause();
                    ShowCart(nRandom);
                }
            }

            //"Space!!"
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4))
                crupierMove = true;
            

            if (crupierMove)
            {
                if (!wait){
                    CrupierAttack();
                    Pause();

                    if (pointsCrupier >= 17)
                        pointsCompare();

                    ShowCart(nRandom);
                }
            }
            
            if (wait){
                waitTime -= Time.deltaTime;
                if (waitTime <= 0){
                    wait = false;
                    waitTime = maxWaitTime;
                }
            }else{

                if (pointsPlayer > 21)
                    Lose();
                
                if (pointsCrupier > 21)
                    Win();
                
            }
            
            
        }
    }


    private void MoreCards(){
        nRandom = (int)Random.Range(1f, 10f);

        if (pointsPlayer <= 10 && nRandom == 1)
            nRandom = 11;
        
        pointsPlayer += nRandom;

        Debug.Log("Payer:  " + pointsPlayer);
        cardsPlayer++;
    }

    private void CrupierAttack(){

        nRandom = (int)Random.Range(1f, 10f);

        if (pointsCrupier <= 10 && nRandom == 1)
            nRandom = 11;
        
        pointsCrupier += nRandom;
        
        
        Debug.Log("Crupier:  " + pointsCrupier);
        cardsCrupier++;

        firstCripier(nRandom);
    }

    private void pointsCompare()
    {
        result = pointsPlayer.CompareTo(pointsCrupier);

        switch (result)
        {
            case 1:
                Win();
                break;

            case -1:
                Lose();
                break;

            case 0:
                Lose();
                /*
                pointsPlayer = 0;
                cardsPlayer = 0;

                pointsCrupier = 0;
                cardsCrupier = 0;

                crupierMove = false;
                */
                break;

        }
    }

    void Pause()
    {
        wait = true;
    }

    void ShowCart(int carta)
    {
        if (!crupierMove)
        {
            GameObject NewCart = Instantiate(CartaP,CartaP.transform.position,CartaP.transform.rotation);
            NewCart.gameObject.SetActive(true);
            NewCart.transform.position = new Vector3(posP.x + cardsPlayer,posP.y + cardsPlayer, posP.z - cardsPlayer);
            string TextureCart = carta.ToString();
            if (carta == 11)
                carta = 1;
            if (carta == 10)
                carta = (int)Random.Range(10f, 11f);

            //NewCart.gameObject.GetComponent<Renderer>().tex

            NewCart.gameObject.GetComponent<MeshRenderer>().material = Texturas[carta - 1];
            
        }
        else
        {
            GameObject NewCartC = Instantiate(CartaC, CartaC.transform.position, CartaC.transform.rotation);
            NewCartC.gameObject.SetActive(true);
            NewCartC.transform.position = new Vector3(posC.x - cardsCrupier, posC.y - cardsCrupier, posC.z - cardsCrupier);
            string TextureCart = carta.ToString();
            if (carta == 11)
                carta = 1;
            if (carta == 10)
                carta = (int)Random.Range(10f, 11f);

            NewCartC.gameObject.GetComponent<MeshRenderer>().material = Texturas[carta - 1];
        }
    }

    void firstCripier(int carta)
    {
        GameObject NewCartC = Instantiate(CartaC, CartaC.transform.position, CartaC.transform.rotation);
        NewCartC.gameObject.SetActive(true);
        NewCartC.transform.position = new Vector3(posC.x - cardsCrupier, posC.y - cardsCrupier, posC.z - cardsCrupier);
        string TextureCart = carta.ToString();
        if (carta == 11)
            carta = 1;
        if (carta == 10)
            carta = (int)Random.Range(10f, 11f);

        NewCartC.gameObject.GetComponent<MeshRenderer>().material = Texturas[carta - 1];
    }


    private void Lose() { gameManager.EndGame(IMiniGame.MiniGameResult.LOSE); }
    
    private void Win(){gameManager.EndGame(IMiniGame.MiniGameResult.WIN);}

}
