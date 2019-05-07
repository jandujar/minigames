using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ivan_alvarez_enri
{public class PlayerAW : MonoBehaviour
{
    public bool isPlayer=false;
    public bool fighting=false;
    public Elements myType=Elements.VOID;
    public float damage;
    public float hp=100;
    public float fireRate=2F;
    private float cooldown=2F;
    public float multipler=-8;
    

    public PlayerAW Rival;

    public GameObject HpBar;
    // Update is called once per frame
    void Update()
    {
        if(fighting){
            cooldown-=0.01F;
            if(cooldown<0){
                cooldown=fireRate;
                Rival.getHit(damage,myType);
            }
            if(isPlayer){
            if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)
                ||InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)
                    ||InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)
                        ||InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)){
                            cooldown-=0.05F;
            }
            }
            gameObject.transform.localPosition=new Vector3(fireRate-cooldown*multipler,0F,0F); 
        }
        
    }

    public void getHit(float dmg,Elements attackElement){

        hp-=dmg/calculateReducer(attackElement);
        HpBar.transform.localScale=new Vector3(hp/100,1,1);
        gameObject.GetComponent<AudioSource>().Play();
    }
    
    private float calculateReducer(Elements attackElement){
        switch(myType){
            case Elements.AIR:
            switch(attackElement){
                case Elements.AIR:
                return 1F;
                case Elements.WATER:
                return 1.5F;
                case Elements.FIRE:
                return 1F;
                case Elements.GROUND:
                return 0.5F;
                case Elements.VOID:
                return 1F;
            }
            break;
            case Elements.WATER:
            switch(attackElement){
                case Elements.AIR:
                return 1.5F;
                case Elements.WATER:
                return 1F;
                case Elements.FIRE:
                return 0.5F;
                case Elements.GROUND:
                return 1F;
                case Elements.VOID:
                return 1F;
            }
            break;
            case Elements.FIRE:
            switch(attackElement){
                case Elements.AIR:
                return 1F;
                case Elements.WATER:
                return 0.5F;
                case Elements.FIRE:
                return 1F;
                case Elements.GROUND:
                return 1.5F;
                case Elements.VOID:
                return 1F;
            }
            break;
            case Elements.GROUND:
            switch(attackElement){
                case Elements.AIR:
                return 0.5F;
                case Elements.WATER:
                return 1F;
                case Elements.FIRE:
                return 1.5F;
                case Elements.GROUND:
                return 1F;
                case Elements.VOID:
                return 1F;
            }
            break;
            case Elements.VOID:
            return 0.1F;
        }
        return 0.1F;
    }
}
}

