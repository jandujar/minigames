using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace ivan_alvarez_enri
{public class ChangeSpriteAW : MonoBehaviour
{
    public SpriteRenderer affectChange;
    public Sprite newSprite;
    public string newName;
    public TextMeshProUGUI Interrogante;
    public TextMeshProUGUI Name;
    public AlchemyWars game;
    
   public void Changesprite(){
       affectChange.sprite=newSprite;
       Interrogante.SetText("");
       Name.SetText(newName);
   }
   public void GoFight(){
       game.StartFigth();
   }
   public void GoFightUpside(){
       game.StartFigthUpside();
   }
   public void soundPlay(){
       gameObject.GetComponent<AudioSource>().Play();
   }
}
}
