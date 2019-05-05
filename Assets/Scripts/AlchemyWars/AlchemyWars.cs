using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ivan_alvarez_enri
{
    public enum Elements
    {
        FIRE,
        WATER,
        AIR,
        GROUND,
        VOID
    }
    public enum SecondElements
    {
        METAL,
        CLAY,
        GUNPOWDER,
        HEAT,
        ELECTRICITY,
        STEAM,
        FAIL,
        FIRE,
        WATER,
        WIND,
        EARTH



    }
    public enum FinalElements{
        SHOOTER,
        EXPLOSIVE,
        GOLEM,
        HUMAN,
        WEAPON,
        MACHINE,
        INFERNO,
        ZEUS,
        GAIA,
        POSEIDON,
        APOLO,
        EOLO,
        FAIL
    }
    public enum phase{
        PHASE1,
        PHASE2,
        PHASE3,
        PHASE4,
        PHASE5,
        PHASE6,
        PHASEMIX,
        PHASECOMBAT
    }
    public class AlchemyWars : IMiniGame
    {
        public SelectableObjectsAW[] FirstStep;
        public SelectableObjectsAW[] SecondStep;
        public SelectableObjectsAW[] ThirdStep;
        public SelectableObjectsAW[] FourStep;
        public Animator ResultOne;

        private phase _phase=phase.PHASE1;

        private Elements firstSelected=Elements.VOID;
        private Elements secondSelected=Elements.VOID;
        private SecondElements FirstResult;
        private Elements thirdSelected=Elements.VOID;
        private Elements fourthSelected=Elements.VOID;
        private SecondElements SecondResult;
        private FinalElements FinalResult;




        public override void initGame(MiniGameDificulty difficulty, GameManager gm)
        {
            
        }

        public override void beginGame()
        {
            
        }
        // Update is called once per frame
        void Update()
        {
            Debug.Log(_phase);
            // Debug.Log("Horizontal: "+InputManager.Instance.GetAxisHorizontal());
            // Debug.Log("Vertical: "+InputManager.Instance.GetAxisVertical());
            switch(_phase){
                //PRIMERA ELECCION
                case phase.PHASE1:
                {//Pongo esto para poder ordenar el codigo y que no se vea un churro
                    if(InputManager.Instance.GetAxisHorizontal()<0&&firstSelected!=Elements.WATER){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F&&
                        //Debug.Log("Funciono Water");
                        firstSelected=Elements.WATER;
                        FirstStep[(int)Elements.WATER].SelectMe();
                        FirstStep[(int)Elements.FIRE].StopMe();
                        FirstStep[(int)Elements.AIR].StopMe();
                        FirstStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisHorizontal()>0&&firstSelected!=Elements.FIRE){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F
                        //Debug.Log("Funciono FIRE");
                        firstSelected=Elements.FIRE;
                        FirstStep[(int)Elements.WATER].StopMe();
                        FirstStep[(int)Elements.FIRE].SelectMe();
                        FirstStep[(int)Elements.AIR].StopMe();
                        FirstStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()>0F&&firstSelected!=Elements.AIR&&InputManager.Instance.GetAxisHorizontal()==0){//
                        //Debug.Log("Funciono Air");
                        firstSelected=Elements.AIR;
                        FirstStep[(int)Elements.WATER].StopMe();
                        FirstStep[(int)Elements.FIRE].StopMe();
                        FirstStep[(int)Elements.AIR].SelectMe();
                        FirstStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()<0F&&firstSelected!=Elements.GROUND&&InputManager.Instance.GetAxisHorizontal()==0){//&&
                        //Debug.Log("Funciono Ground");
                        firstSelected=Elements.GROUND;
                        FirstStep[(int)Elements.WATER].StopMe();
                        FirstStep[(int)Elements.FIRE].StopMe();
                        FirstStep[(int)Elements.AIR].StopMe();
                        FirstStep[(int)Elements.GROUND].SelectMe();
                    }
                    if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)&&firstSelected!=Elements.VOID){
                        FirstStep[(int)firstSelected].ImChoosed();
                        foreach(SelectableObjectsAW _element in FirstStep){
                            if(_element._element!=firstSelected)
                            _element.FinishMe();
                        }
                        
                        _phase=phase.PHASE2;
                        
                    }
                }
                break;
                case phase.PHASE2://SEGUNDA ELECCION
                {
                 if(InputManager.Instance.GetAxisHorizontal()<0&&secondSelected!=Elements.WATER){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F&&
                        //Debug.Log("Funciono Water");
                        secondSelected=Elements.WATER;
                        SecondStep[(int)Elements.WATER].SelectMe();
                        SecondStep[(int)Elements.FIRE].StopMe();
                        SecondStep[(int)Elements.AIR].StopMe();
                        SecondStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisHorizontal()>0&&secondSelected!=Elements.FIRE){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F
                        //Debug.Log("Funciono FIRE");
                        secondSelected=Elements.FIRE;
                        SecondStep[(int)Elements.WATER].StopMe();
                        SecondStep[(int)Elements.FIRE].SelectMe();
                        SecondStep[(int)Elements.AIR].StopMe();
                        SecondStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()>0F&&secondSelected!=Elements.AIR&&InputManager.Instance.GetAxisHorizontal()==0){//
                        //Debug.Log("Funciono Air");
                        secondSelected=Elements.AIR;
                        SecondStep[(int)Elements.WATER].StopMe();
                        SecondStep[(int)Elements.FIRE].StopMe();
                        SecondStep[(int)Elements.AIR].SelectMe();
                        SecondStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()<0F&&secondSelected!=Elements.GROUND&&InputManager.Instance.GetAxisHorizontal()==0){//&&
                        //Debug.Log("Funciono Ground");
                        secondSelected=Elements.GROUND;
                        SecondStep[(int)Elements.WATER].StopMe();
                        SecondStep[(int)Elements.FIRE].StopMe();
                        SecondStep[(int)Elements.AIR].StopMe();
                        SecondStep[(int)Elements.GROUND].SelectMe();
                    }
                    if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)&&secondSelected!=Elements.VOID){
                        foreach(SelectableObjectsAW _element in SecondStep){
                            if(_element._element!=secondSelected)
                            _element.FinishMe();
                        }
                        SecondStep[(int)secondSelected].ImChoosed();
                        FirstResult=calculateSecond(firstSelected,secondSelected);
                        Debug.Log(FirstResult);
                        ResultOne.SetTrigger("StartAnim");
                        _phase=phase.PHASE3;
                        
                    }
                }
                break;
                case phase.PHASE3://TERCERA ELECCION
                  {
                 if(InputManager.Instance.GetAxisHorizontal()<0&&thirdSelected!=Elements.WATER){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F&&
                        //Debug.Log("Funciono Water");
                        thirdSelected=Elements.WATER;
                        ThirdStep[(int)Elements.WATER].SelectMe();
                        ThirdStep[(int)Elements.FIRE].StopMe();
                        ThirdStep[(int)Elements.AIR].StopMe();
                        ThirdStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisHorizontal()>0&&thirdSelected!=Elements.FIRE){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F
                        //Debug.Log("Funciono FIRE");
                        thirdSelected=Elements.FIRE;
                        ThirdStep[(int)Elements.WATER].StopMe();
                        ThirdStep[(int)Elements.FIRE].SelectMe();
                        ThirdStep[(int)Elements.AIR].StopMe();
                        ThirdStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()>0F&&thirdSelected!=Elements.AIR&&InputManager.Instance.GetAxisHorizontal()==0){//
                        //Debug.Log("Funciono Air");
                        thirdSelected=Elements.AIR;
                        ThirdStep[(int)Elements.WATER].StopMe();
                        ThirdStep[(int)Elements.FIRE].StopMe();
                        ThirdStep[(int)Elements.AIR].SelectMe();
                        ThirdStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()<0F&&thirdSelected!=Elements.GROUND&&InputManager.Instance.GetAxisHorizontal()==0){//&&
                        //Debug.Log("Funciono Ground");
                        thirdSelected=Elements.GROUND;
                        ThirdStep[(int)Elements.WATER].StopMe();
                        ThirdStep[(int)Elements.FIRE].StopMe();
                        ThirdStep[(int)Elements.AIR].StopMe();
                        ThirdStep[(int)Elements.GROUND].SelectMe();
                    }
                    if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)&&thirdSelected!=Elements.VOID){
                        foreach(SelectableObjectsAW _element in ThirdStep){
                            if(_element._element!=thirdSelected)
                            _element.FinishMe();
                        }
                        ThirdStep[(int)secondSelected].ImChoosed();
                        _phase=phase.PHASE4;
                        
                    }
                }
                break;
                case phase.PHASE4://CUARTA ELECCION
                {
                 if(InputManager.Instance.GetAxisHorizontal()<0&&fourthSelected!=Elements.WATER){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F&&
                        //Debug.Log("Funciono Water");
                        fourthSelected=Elements.WATER;
                        FourStep[(int)Elements.WATER].SelectMe();
                        FourStep[(int)Elements.FIRE].StopMe();
                        FourStep[(int)Elements.AIR].StopMe();
                        FourStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisHorizontal()>0&&fourthSelected!=Elements.FIRE){//&&InputManager.Instance.GetAxisVertical()>-0.5F&&InputManager.Instance.GetAxisVertical()<0.5F
                        //Debug.Log("Funciono FIRE");
                        fourthSelected=Elements.FIRE;
                        FourStep[(int)Elements.WATER].StopMe();
                        FourStep[(int)Elements.FIRE].SelectMe();
                        FourStep[(int)Elements.AIR].StopMe();
                        FourStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()>0F&&fourthSelected!=Elements.AIR&&InputManager.Instance.GetAxisHorizontal()==0){//
                        //Debug.Log("Funciono Air");
                        fourthSelected=Elements.AIR;
                        FourStep[(int)Elements.WATER].StopMe();
                        FourStep[(int)Elements.FIRE].StopMe();
                        FourStep[(int)Elements.AIR].SelectMe();
                        FourStep[(int)Elements.GROUND].StopMe();
                    }else if(InputManager.Instance.GetAxisVertical()<0F&&fourthSelected!=Elements.GROUND&&InputManager.Instance.GetAxisHorizontal()==0){//&&
                        //Debug.Log("Funciono Ground");
                        fourthSelected=Elements.GROUND;
                        FourStep[(int)Elements.WATER].StopMe();
                        FourStep[(int)Elements.FIRE].StopMe();
                        FourStep[(int)Elements.AIR].StopMe();
                        FourStep[(int)Elements.GROUND].SelectMe();
                    }
                    if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)&&fourthSelected!=Elements.VOID){
                        foreach(SelectableObjectsAW _element in FourStep){
                            if(_element._element!=fourthSelected)
                            _element.FinishMe();
                        }
                        FourStep[(int)secondSelected].ImChoosed();
                        _phase=phase.PHASE5;
                        
                    }
                }
                break;
                case phase.PHASE5://RESOLUCION
                break;
                case phase.PHASE6://PELEA
                break;
                default:
                break;

            }
        }
        SecondElements calculateSecond(Elements One, Elements Two){
            SecondElements Result=SecondElements.FAIL;
            switch(One){
                case Elements.AIR:{
                    switch(Two){
                        case Elements.AIR:
                            Result=SecondElements.WIND;
                        break;
                        case Elements.FIRE:
                            Result=SecondElements.HEAT;
                        break;
                        case Elements.WATER:
                            Result=SecondElements.ELECTRICITY;
                        break;
                        case Elements.GROUND:
                            Result=SecondElements.GUNPOWDER;
                        break;
                    }
                }
                break;
                case Elements.FIRE:{
                    switch(Two){
                        case Elements.AIR:
                            Result=SecondElements.HEAT;
                        break;
                        case Elements.FIRE:
                            Result=SecondElements.FIRE;
                        break;
                        case Elements.WATER:
                            Result=SecondElements.STEAM;
                        break;
                        case Elements.GROUND:
                            Result=SecondElements.METAL;
                        break;
                    }
                }
                break;
                case Elements.WATER:{
                    switch(Two){
                        case Elements.AIR:
                            Result=SecondElements.ELECTRICITY;
                        break;
                        case Elements.FIRE:
                            Result=SecondElements.STEAM;
                        break;
                        case Elements.WATER:
                            Result=SecondElements.WATER;
                        break;
                        case Elements.GROUND:
                            Result=SecondElements.CLAY;
                        break;
                    }
                }
                break;
                case Elements.GROUND:{
                    switch(Two){
                        case Elements.AIR:
                            Result=SecondElements.GUNPOWDER;
                        break;
                        case Elements.FIRE:
                            Result=SecondElements.METAL;
                        break;
                        case Elements.WATER:
                            Result=SecondElements.CLAY;
                        break;
                        case Elements.GROUND:
                            Result=SecondElements.EARTH;
                        break;
                    }
                }
                break;

            }
            return Result;

        }
        FinalElements calculateFinal(SecondElements One,SecondElements Two){
            FinalElements Result=FinalElements.FAIL;
            switch(One){
                case SecondElements.CLAY:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.GAIA;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.EXPLOSIVE;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.GAIA;
                    break;
                }
                }
                break;
                 case SecondElements.EARTH:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.GAIA;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.GAIA;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.APOLO;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.POSEIDON;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.FAIL;
                    break;
                }
                }
                break;
                 case SecondElements.ELECTRICITY:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.ZEUS;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.EXPLOSIVE;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.MACHINE;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.EOLO;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.POSEIDON;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.EOLO;
                    break;
                }
                }
                break; 
                case SecondElements.FIRE:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.EXPLOSIVE;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.APOLO;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.WEAPON;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.EOLO;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.EOLO;
                    break;
                }
                }
                break;
                 case SecondElements.GUNPOWDER:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.EXPLOSIVE;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.EXPLOSIVE;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.SHOOTER;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.SHOOTER;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.EXPLOSIVE;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.SHOOTER;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.MACHINE;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.FAIL;
                    break;
                }
                }
                break;
                case SecondElements.HEAT:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.APOLO;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.EXPLOSIVE;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.WEAPON;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.EOLO;
                    break;
                }
                }
                break;
                 case SecondElements.METAL:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.GOLEM;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.MACHINE;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.SHOOTER;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.SHOOTER;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.WEAPON;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.MACHINE;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.MACHINE;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.FAIL;
                    break;
                }
                }
                break;
                 case SecondElements.STEAM:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.GAIA;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.INFERNO;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.EOLO;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.WEAPON;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.EOLO;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.POSEIDON;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.EOLO;
                    break;
                }
                }
                break; 
                case SecondElements.WATER:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.ZEUS;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.POSEIDON;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.POSEIDON;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.EOLO;
                    break;
                }
                }
                break;
                 case SecondElements.WIND:{
                switch(Two){
                    case SecondElements.CLAY:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.EARTH:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.ELECTRICITY:
                    Result=FinalElements.ZEUS;
                    break;
                    case SecondElements.FIRE:
                    Result=FinalElements.APOLO;
                    break;
                    case SecondElements.GUNPOWDER:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.HEAT:
                    Result=FinalElements.EOLO;
                    break;
                    case SecondElements.METAL:
                    Result=FinalElements.FAIL;
                    break;
                    case SecondElements.STEAM:
                    Result=FinalElements.EOLO;
                    break;
                    case SecondElements.WATER:
                    Result=FinalElements.HUMAN;
                    break;
                    case SecondElements.WIND:
                    Result=FinalElements.EOLO;
                    break;
                }
                }
                break;
            }
            return Result;
        }
    }
}
