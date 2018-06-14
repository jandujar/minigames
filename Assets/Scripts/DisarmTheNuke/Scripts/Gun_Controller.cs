using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Controller : MonoBehaviour {
	
public Animator animator;
private bool Idle  = false;
private bool Move = false;
private bool Reload = false;
private bool Fire = false;
private bool EmptyReload = false;
private bool FastMove = false;
private bool ZoomIdle = false;
private bool ZoomMove = false;
private bool ZoomFire = false;
private bool MeleeAttack = false;
private bool Select = false;
private bool PutAway = false;
private bool DryFire = false;
private bool AltToAndFrom = false;
private bool AltFire = false;
private bool AltZoomFire = false;
private bool ReloadLoop = false;
private bool EndReload = false;
private bool AlternateTo = false;
private bool AlternateFrom = false;
private bool SwitchToAlt1;
private bool SwitchToAlt2;
private int clip;
private float CounterSpeed = 2;
public int AmmoQuantity;
public int AmmoReserve;
public int HasAlternateFireMode;
public int IsShotgun;
    //**********
    public int damage;
    //**********
public GUIStyle mystyle;
public GameObject MuzzleFlash1;
public GameObject MuzzleFlash2;
public GameObject MuzzleFlashLight;
public GameObject ShellEjecting;
public GameObject Crosshair;
public GameObject Collimator;
public GameObject AmmoIcon1;
public GameObject AmmoIcon2;
    //**********
    public GameObject Shoot; 
    //**********
public AudioSource FireSound; 
public AudioSource DryFireSound;
public AudioSource ReloadPart1Sound; 
public AudioSource ReloadPart2Sound;
public AudioSource ReloadPart3Sound;
public AudioSource ReloadPart4Sound;
public AudioSource ReloadPart5Sound;
public AudioSource ReloadPart6Sound;
public AudioSource ReloadPart7Sound;
public AudioSource ReloadPart8Sound;
public AudioSource CockSound;
public AudioSource RetrieveSound;
public AudioSource PutawaySound;
public AudioSource ZoomSound;
public AudioSource MeleeSound;
public AudioSource SwitchSound;
public AudioSource BoltPart1Sound;
public AudioSource BoltPart2Sound;
public AudioSource FlapPart1Sound;
public AudioSource FlapPart2Sound;
public AudioSource SlideSound;


    // Use this for initialization
    void Start() {
        transform.Rotate(0, 0, 0);
        gameObject.SetActive(true);
        Cursor.visible = false;
        Collimator.SetActive(false);
        AmmoIcon1.SetActive(true);
        AmmoIcon2.SetActive(false);
        MuzzleFlashLight.SetActive(false);
        ShellEjecting.SetActive(true);
        mystyle.fontSize = 20;
        mystyle.normal.textColor = Color.white;
        clip = AmmoQuantity;
        damage = 10;
    }
	
	// Update is called once per frame
    void Update () {

    if (HasAlternateFireMode == 1 && IsShotgun == 0){
	if(Input.GetKeyDown(KeyCode.X)){ // Switch to Alternate Fire Mode
	if(SwitchToAlt1){
    AltToAndFrom = true;
	StartCoroutine(AltToAndFromDelay());
	Idle = true;
	Select = false;
    SwitchToAlt1 = false;
	AmmoIcon1. SetActive(true);
	AmmoIcon2. SetActive(false);
     }
    else {
    AltToAndFrom = true;
	StartCoroutine(AltToAndFromDelay());
	Idle = true;
	Select = false;
    SwitchToAlt1 = true;
	AmmoIcon1. SetActive(false);
	AmmoIcon2. SetActive(true);
   }
	}
    }
if (HasAlternateFireMode == 1 && IsShotgun == 1){
	if(Input.GetKeyDown(KeyCode.X) && Move == false && Fire == false && FastMove == false
	&& Reload == false && EmptyReload == false){ // Switch to Alternate Fire Mode (Shotgun)
	if(SwitchToAlt2){
	StartCoroutine(AltToAndFromDelay());
	Idle = true;
	Select = false;
    SwitchToAlt2 = false;
	AlternateTo = false;
	AlternateFrom = true;
	AmmoIcon1. SetActive(true);
	AmmoIcon2. SetActive(false);
     }
    else {
	AlternateTo = true;
	AlternateFrom = false;
	StartCoroutine(AltToAndFromDelay());
	Idle = true;
	Select = false;
    SwitchToAlt2 = true;
	AmmoIcon1. SetActive(false);
	AmmoIcon2. SetActive(true);
   }
	}
    }/*
if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) 
	|| Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4)
    || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6)
	|| Input.GetKeyDown(KeyCode.Alpha7)){  
    Idle = false;
	PutAway = true;
	Select = false;
	Fire = false;
	AltFire = false;
    }*/
        
if (InputManager.Instance.GetAxisVertical() < 0.1 
            || InputManager.Instance.GetAxisVertical() > 0.1
            || InputManager.Instance.GetAxisHorizontal() < 0.1 
            || InputManager.Instance.GetAxisHorizontal() > 0.1) { //Move 
       //|| Input.GetKeyDown(KeyCode.A) 
      // || Input.GetKeyDown(KeyCode.D) 
	  // || Input.GetKeyDown(KeyCode.S)) {   
        Move = true;
        Idle = false;
  		Fire = false;
		AltFire = false;
		FastMove = false;
		Select = false;
    }
	else if (InputManager.Instance.GetAxisVertical() == 0
            || InputManager.Instance.GetAxisHorizontal() == 0)
        {
         // (Input.GetKeyUp(KeyCode.W) 
		//|| Input.GetKeyUp(KeyCode.A) 
	   // || Input.GetKeyUp(KeyCode.D) 
		//|| Input.GetKeyUp(KeyCode.S)){  
        Move = false;
        Idle = true;
		Fire = false;
		AltFire = false;
		FastMove = false;
    }
if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4) && clip == AmmoQuantity || AmmoReserve == 0){   //Reload
        Reload = false;
		EmptyReload = false;
        Idle = true;
   	    } 
else if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4) && clip >0){
        Reload = true;
        Idle = false;
		Fire = false;
		AltFire = false;
   	    }
        //InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON6)
        //InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6)
        //InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON6)

        if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON6))
        { 
		DryFire = false;
        Idle = true;
        Move = false;;
		Fire = false;
		AltFire = false;
    }
	if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON6) && (InputManager.Instance.GetAxisHorizontal() > 0.1 || InputManager.Instance.GetAxisHorizontal() < 0.1))
        { 
        Idle = false;
        Move = true;
		Fire = false;
		AltFire = false;
    }
	if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && (InputManager.Instance.GetAxisHorizontal() > 0.1 || InputManager.Instance.GetAxisHorizontal() < 0.1))
        { //Fire
		if (SwitchToAlt1 == false){
        Idle = false;
        Move = false;
		Fire = true;
		Select = false;
    }
	else 
	{
	    Idle = false;
        Move = false;
		AltFire = true;
		Select = false;
	}
		}
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && clip == 0 && AmmoReserve > 0) { 
		StartCoroutine(StopFireSound());
		Move = false;
		Fire = false;
		AltFire = false;
		EmptyReload = true;
		Idle = false;
		Select = false;
    }
else if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && clip > 0){
    if (SwitchToAlt1 == false){
        EmptyReload = false;	
        Fire = true;
        Select = false;
    }
    else{
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON6) && clip > 0){
            EmptyReload = false;	
            AltFire = true;
            Select = false;
        }
    }
}
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && clip == 0 && AmmoReserve == 0) { 
		StartCoroutine(StopFireSound());
		Move = false;
		Fire = false;
		AltFire = false;
		EmptyReload = false;
		Idle = false;
	    DryFire = true;
    }
else if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON6))
        {
	EmptyReload = false;
	Idle = true;
}
 if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON6) && clip == 0 && AmmoReserve == 0) { 
        FireSound.Stop();
		DryFireSound.Play();
		
}
	if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) //FastMove
		|| Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) 
	    || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) 
		|| Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S)){   
		Move = false;
		FastMove = true;
		Reload = false;
        Idle = false;
		Fire = false;
		AltFire = false;
		Select = false;
          }
	else if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)
		|| Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey(KeyCode.A)
	    || Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey(KeyCode.D)
		|| Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey(KeyCode.S)){  
        Idle = false;
        Move = true;
		FastMove = false;
    }
if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON5) && FastMove == false && MeleeAttack == false 
    && Reload == false && EmptyReload == false){   //Zoom
        ZoomIdle = true;
		Idle = false;
		Crosshair.SetActive(false);
		Select = false;
		if (EmptyReload == false){
		ZoomSound.Play();
		}
		
    }
	else  if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON5) && FastMove == false && MeleeAttack == false
	   && Reload == false && EmptyReload == false){ 
         ZoomIdle = false;	
		 Idle = true;
		 Crosshair.SetActive(true);
		 ZoomSound.Play();
    }	
	if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && clip > 0) {   //Zoom Auto Fire
	 if (SwitchToAlt1 == false){
		ZoomFire = true;
		AltZoomFire  = false;
		Fire = false;
		AltFire = false;
        ZoomIdle = false;
		ZoomMove = false;
		Move = false;
		Idle = false;
		Select = false;
		Crosshair.SetActive(false);
	 }
	 else{
		if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON6) && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && clip > 0){
		ZoomFire = false;
		AltZoomFire  = true;
		Fire = false;
		AltFire = false;
        ZoomIdle = false;
		ZoomMove = false;
		Move = false;
		Idle = false;
		Select = false;
		Crosshair.SetActive(false); 
	 }
	}
    }
	else if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON6) && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5)){ 
         ZoomFire = false;
		 AltZoomFire  = false;
		 ZoomIdle = true;	
		 Idle = false;
		 Crosshair.SetActive(false);
    }	
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON5)){ 
         ZoomFire = false;
		 AltZoomFire = false;
		 ZoomIdle = false;	
		 Idle = true;
		 Crosshair.SetActive(false);
		 }
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && clip == 0 && AmmoReserve == 0) { 
		StartCoroutine(StopFireSound());
		Move = false;
		ZoomFire = false;
		AltZoomFire = false;
		EmptyReload = false;
		ZoomIdle = true;
    }
if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON6) && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && clip == 0 && AmmoReserve == 0) { 
        FireSound.Stop();
		DryFireSound.Play();

}
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisVertical() != 0 //Zoom Move 
	    || InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisHorizontal() != 0)
        {   
		ZoomMove = true;
		Fire = false;
		AltFire = false;
		Move = false;
		ZoomFire = false;
		AltZoomFire = false;
        ZoomIdle = false;
		Idle = false;
		Crosshair.SetActive(false);
		Reload = false;
		EmptyReload = false;
		}
else if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisVertical() == 0
          || InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisHorizontal() == 0)
        {  
	     ZoomMove = false;
         ZoomFire = false;
		 AltZoomFire = false;
		 ZoomIdle = true;	
		 Idle = false;
		 Move = false;
		 Crosshair.SetActive(false);
        }
    else if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisVertical() != 0
          || InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisHorizontal() != 0)
        {  
	     ZoomMove = false;
         ZoomFire = false;
		 AltZoomFire = false;
		 ZoomIdle = false;	
		 Idle = false;
		 Move = true;
		 Crosshair.SetActive(false);
        }
if ((InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisVertical() != 0 && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6))
        || (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && InputManager.Instance.GetAxisHorizontal() != 0 && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6)))
        { 
        if (SwitchToAlt1 == false){		
		ZoomMove = false;
		ZoomFire = true;
		Move = false;
		ZoomFire = true;
        ZoomIdle = false;
		Idle = false;
		Crosshair.SetActive(false);
		}
		else
		{
		ZoomMove = false;
		AltZoomFire = true;
		Move = false;
		ZoomFire = true;
        ZoomIdle = false;
		Idle = false;
		Crosshair.SetActive(false);	
		}
    }
        
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON5) && clip == 0 && AmmoReserve > 0) { 
		StartCoroutine(StopFireSound());
		Move = false;
		ZoomFire = false;
		AltZoomFire = false;
		EmptyReload = true;
		Idle = false;
    }	

if (Input.GetKeyDown(KeyCode.LeftAlt)){   //Melee Attack
        MeleeAttack = true;
		Idle = false;
		Select = false;
    }
	else if (Input.GetKeyUp(KeyCode.LeftAlt)){  
        MeleeAttack = false;
		Idle = true;
		}
	if(Idle== true) {
        animator.SetBool("Idle", true);
		animator.SetBool("AltToAndFrom", false);
		animator.SetBool("AlternateTo", false);
		animator.SetBool("AlternateFrom", false);
        animator.SetBool("Move", false);
		animator.SetBool("DryFire", false);
		animator.SetBool("FastMove", false);
        animator.SetBool("Reload", false);
		animator.SetBool("ReloadLoop", false);
		animator.SetBool("EndReload", false);
		animator.SetBool("Fire", false);
		animator.SetBool("AltFire", false);
		animator.SetBool("EmptyReload", false);
		animator.SetBool("ZoomIdle", false);
		animator.SetBool("MeleeAttack", false);
		animator.SetBool("Select", false);
		
    }
if(Move == true) {
        animator.SetBool("Move", true);
        animator.SetBool("Idle", false);
		animator.SetBool("FastMove", false);
        animator.SetBool("Reload", false);
		animator.SetBool("Fire", false);
		animator.SetBool("EmptyReload", false);
		animator.SetBool("MeleeAttack", false);
		animator.SetBool("ZoomMove", false);
		animator.SetBool("DryFire", false);
		Crosshair.SetActive(true);
		Collimator.SetActive(false);
    }
if(Reload == true) {
        animator.SetBool("Reload", true);
        animator.SetBool("Move", false);
		animator.SetBool("FastMove", false);
        animator.SetBool("Idle", false);
		animator.SetBool("Fire", false);
		animator.SetBool("EndReload", false);
		animator.SetBool("ReloadLoop", false);
		animator.SetBool("EmptyReload", false);
		animator.SetBool("MeleeAttack", false);
    }
	    if(Fire == true) {
        animator.SetBool("Fire", true);
        animator.SetBool("Move", false);
        animator.SetBool("Idle", false);
		animator.SetBool("Select", false);
		animator.SetBool("FastMove", false);
		animator.SetBool("Reload", false);
		animator.SetBool("EmptyReload", false);
		animator.SetBool("MeleeAttack", false);
    }
		if(EmptyReload == true) {
        animator.SetBool("EmptyReload", true);
        animator.SetBool("Move", false);
        animator.SetBool("Idle", false);
		animator.SetBool("FastMove", false);
		animator.SetBool("EndReload", false);
		animator.SetBool("ReloadLoop", false);
		animator.SetBool("ZoomMove", false);
		animator.SetBool("ZoomIdle", false);
		animator.SetBool("Fire", false);
		animator.SetBool("Reload", false);
		animator.SetBool("MeleeAttack", false);
    }
	    if(FastMove == true) {
        animator.SetBool("EmptyReload", false);
        animator.SetBool("Move", false);
		animator.SetBool("FastMove", true);
        animator.SetBool("Idle", false);
		animator.SetBool("Fire", false);
		animator.SetBool("Reload", false);
		animator.SetBool("MeleeAttack", false);
		 }
	if(ZoomIdle== true) {
        animator.SetBool("ZoomIdle", true);
		animator.SetBool("FastMove", false);
		animator.SetBool("Idle", false);
		animator.SetBool("ZoomFire", false);
		animator.SetBool("ZoomMove", false);
		animator.SetBool("AltZoomFire", false);
	}
	if(ZoomFire == true) {
		animator.SetBool("ZoomFire", true);
		animator.SetBool("AltZoomFire", false);
        animator.SetBool("ZoomIdle", false);
		animator.SetBool("Idle", false);
		animator.SetBool("ZoomMove", false);
}
	if(ZoomMove == true) {
		animator.SetBool("ZoomFire", false);
		animator.SetBool("AltZoomFire", false);
        animator.SetBool("ZoomIdle", false);
		animator.SetBool("Idle", false);
		animator.SetBool("ZoomMove", true);
		animator.SetBool("Move", false);
}
	if(MeleeAttack == true) {
		animator.SetBool("Idle", false);
		animator.SetBool("MeleeAttack", true);
		}
if(Select == true) {
		animator.SetBool("Select", true);
		animator.SetBool("PutAway", false);
		}
if(PutAway == true) {
	    animator.SetBool("PutAway", true);
	    animator.SetBool("Fire", false);
		animator.SetBool("Idle", false);
		animator.SetBool("Select", false);
		animator.SetBool("FastMove", false);
}
if(DryFire == true) {
		animator.SetBool("DryFire", true);
		animator.SetBool("Fire", false);
		animator.SetBool("ZoomFire", false);
		animator.SetBool("Idle", false);
		animator.SetBool("EmptyReload", false);
		}
 if(AlternateTo == true) {
	    animator.SetBool("AlternateTo", true);
		animator.SetBool("AlternateFrom", true);
		animator.SetBool("Idle", false);
		}
 if(AlternateFrom == true) {
	    animator.SetBool("AlternateFrom", true);
	    animator.SetBool("AlternateTo", false);
		animator.SetBool("Idle", false);
		}
 if(AltToAndFrom == true) {
	    animator.SetBool("AltToAndFrom", true);
		animator.SetBool("Idle", false);
		}
if(ReloadLoop == true) {
	    animator.SetBool("ReloadLoop", true);
		animator.SetBool("EndReload", false);
		animator.SetBool("Reload", false);
		animator.SetBool("Idle", false);
		animator.SetBool("Fire", false);
		animator.SetBool("Move", false);
}
if(EndReload == true) {
	    animator.SetBool("EndReload", true);
        animator.SetBool("Reload", false);
        animator.SetBool("Move", false);
		animator.SetBool("FastMove", false);
        animator.SetBool("Idle", false);
		animator.SetBool("Fire", false);
		animator.SetBool("ReloadLoop", false);
		animator.SetBool("EmptyReload", false);
		animator.SetBool("MeleeAttack", false);
}
if(AltFire == true) {
	    animator.SetBool("AltFire", true);
        animator.SetBool("Fire", false);
        animator.SetBool("Move", false);
        animator.SetBool("Idle", false);
		animator.SetBool("Select", false);
		animator.SetBool("FastMove", false);
		animator.SetBool("Reload", false);
		animator.SetBool("EmptyReload", false);
		animator.SetBool("MeleeAttack", false);
    }
if(AltZoomFire == true) {
	    animator.SetBool("AltZoomFire", true);
		animator.SetBool("ZoomFire", false);
        animator.SetBool("ZoomIdle", false);
		animator.SetBool("Idle", false);
		animator.SetBool("ZoomMove", false);
}
}
void OnGUI () {
	GUI.Label (new Rect (20,Screen.height - 40,100,50), clip+"/"+AmmoReserve,mystyle);
}
void AddAmmo(){
  int totalAmmo = clip + AmmoReserve;
if (totalAmmo <=AmmoQuantity) {
    StartCoroutine(Wait());
	StartCoroutine(WaitForReserve2());
}
else
{
StartCoroutine(WaitForClip());	
StartCoroutine(WaitForReserve1());
}
}
void AddShotgunAmmo(){
clip +=1;
if(clip == AmmoQuantity){
ReloadLoop = false;
EndReload = true;
}
}
IEnumerator WaitForClip(){
	
	yield return new WaitForSeconds (1.5f);
	clip = AmmoQuantity;
	
}
IEnumerator WaitForReserve1(){
    int shotsFired = AmmoQuantity-clip;
	yield return new WaitForSeconds (1.5f);
	AmmoReserve -= shotsFired;
}
IEnumerator WaitForReserve2(){
	yield return new WaitForSeconds (1.5f);
	AmmoReserve = 0;
}
void PlayFireSound()
{
	FireSound.Play();
}
IEnumerator StopFireSound()
{
yield return new WaitForSeconds(1);
FireSound.Stop();
}
void PlayReloadPart1Sound()
{
	ReloadPart1Sound.Play();
}
void PlayReloadPart2Sound()
{
	ReloadPart2Sound.Play();
}
void PlayReloadPart3Sound()
{
	ReloadPart3Sound.Play();
}
void PlayReloadPart4Sound()
{
	ReloadPart4Sound.Play();
}
void PlayReloadPart5Sound()
{
	ReloadPart5Sound.Play();
}
void PlayReloadPart6Sound()
{
	ReloadPart6Sound.Play();
}
void PlayReloadPart7Sound()
{
	ReloadPart7Sound.Play();
}
void PlayReloadPart8Sound()
{
	ReloadPart8Sound.Play();
}
void PlayCockSound()
{
	CockSound.Play();
}
void PlayMeleeSound()
{
	MeleeSound.Play();
	
}
IEnumerator Wait(){
    int totalAmmo = clip + AmmoReserve;
    yield return new WaitForSeconds (1.5f);
	clip = totalAmmo;
}
void PlayPutawaySound()
{
	PutawaySound.Play();
	
}
void PlayRetrieveSound()
{
	RetrieveSound.Play();
	
}
void PlaySwitchSound(){
	SwitchSound.Play();
}
void PlayBoltPart1Sound(){
	BoltPart1Sound.Play();
}
void PlayBoltPart2Sound(){
	BoltPart2Sound.Play();
}
void PlayFlapPart1Sound(){
	FlapPart1Sound.Play();
}
void PlayFlapPart2Sound(){
	FlapPart2Sound.Play();
}
void PlaySlideSound(){
	SlideSound.Play();
}
IEnumerator AltToAndFromDelay(){
	yield return new WaitForSeconds (0.2f);
	AltToAndFrom = false;
	AlternateTo = false;
}
void DisableSelectAnim(){
	Select = false;
	PutAway = false;
	Idle = true;
	Crosshair.SetActive (true);
}
void AltFireToIdle(){
	AltFire = false;
	Fire = false;
	Idle = true;
    }
void AltZoomFireToIdle(){
	AltZoomFire = false;
	ZoomIdle = true;
}
void ReloadToIdle(){
Reload = false;
Idle = true;
}
IEnumerator AddSingleFireEffects(){
MuzzleFlash1.SetActive(true);
MuzzleFlash2.SetActive(true);
MuzzleFlashLight.SetActive(true);
ShellEjecting.SetActive(true);
yield return new WaitForSeconds (0.05f);
MuzzleFlash1.SetActive(false);
MuzzleFlash2.SetActive(false);
MuzzleFlashLight.SetActive(false);
ShellEjecting.SetActive(false);
}
    

void AutoFireAmmoCounter(){
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && clip >0){
	CounterSpeed -=1;
	if (CounterSpeed == 0) {
	clip -= 1;
	CounterSpeed = 2;
                Shoot.GetComponent<com.marc.escobar.Shoot>().ShootRay();
	}	
}
}
void SingleFireAmmoCounter(){
if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON6) && clip >0){
	clip -= 1;
            Shoot.GetComponent<com.marc.escobar.Shoot>().ShootRay();
        }
}
void ShowCollimator(){
Collimator.SetActive(true);
}
void HideCollimator(){
Collimator.SetActive(false);
}
void PlayReloadLoop(){
Reload = false;
ReloadLoop = true;
}
void EndReloadToIdle(){
EndReload = false;
Idle = true;
}
void AltToChangeLayerWeight(){
animator.SetLayerWeight(1, 1);
AlternateTo = false;
Idle = true;
}
void AltFromChangeLayerWeight(){
animator.SetLayerWeight(1, 0);
AlternateFrom = false;
Idle = true;
}
void Deactivation(){
AmmoIcon1. SetActive(true);
AmmoIcon2. SetActive(false);
PutAway = false;
Idle = false;
Move = false;
Reload = false;
Fire = false;
EmptyReload = false;
FastMove = false;
ZoomIdle = false;
ZoomMove = false;
ZoomFire = false;
MeleeAttack = false;
Select = false;
DryFire = false;
AltToAndFrom = false;
AltFire = false;
AltZoomFire = false;
ReloadLoop = false;
EndReload = false;
AlternateTo = false;
AlternateFrom = false;
SwitchToAlt1 = false;
SwitchToAlt2 = false;
Crosshair.SetActive (false);
gameObject.SetActive (false);
}
}