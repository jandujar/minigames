using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ivan_alvarez_enri
{
public class OnTriggerEnterWin : MonoBehaviour
{
    public ivan_alvarez_enri.Drunkey_Sc GameManager;
    public AudioSource AudioWin;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(GameManager.StartInputs){
            GameManager.Audio.Stop();
            AudioWin.Play();
            StartCoroutine(Run());
            GameManager.win=true;
            Debug.Log("Has Ganao");
            StartCoroutine(Win());
        }
    }

    IEnumerator Run(){
        yield return null;
        GameManager.Player.transform.Translate(new Vector3(0, 0.2F, 0));
        StartCoroutine(Run());
    }
    IEnumerator Win(){
        yield return new WaitForSeconds(2F);
        GameManager.gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        
    }
}
}
