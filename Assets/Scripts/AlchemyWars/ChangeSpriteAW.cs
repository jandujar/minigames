using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ivan_alvarez_enri
{public class ChangeSpriteAW : MonoBehaviour
{
    public SpriteRenderer affectChange;
    public Sprite newSprite;
   public void Changesprite(){
       affectChange.sprite=newSprite;
   }
}
}
