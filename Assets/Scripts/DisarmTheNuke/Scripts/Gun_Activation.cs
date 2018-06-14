using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Activation : MonoBehaviour {
	
public GameObject WeaponSlot01;
public GameObject WeaponSlot02;
public GameObject WeaponSlot03;
public GameObject WeaponSlot04;
public GameObject WeaponSlot05;
public GameObject WeaponSlot06;
public GameObject WeaponSlot07;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
void Update () {

if (Input.GetKeyDown(KeyCode.Alpha1))
{
if (WeaponSlot02.activeSelf == true || WeaponSlot03.activeSelf == true 
 || WeaponSlot04.activeSelf == true || WeaponSlot05.activeSelf == true
 || WeaponSlot06.activeSelf == true || WeaponSlot07.activeSelf == true){
StartCoroutine(WaitForSlot01());	 
}	
else{
WeaponSlot01.SetActive (true);	
}
}

if (Input.GetKeyDown(KeyCode.Alpha2))
{
if (WeaponSlot01.activeSelf == true || WeaponSlot03.activeSelf == true
 || WeaponSlot04.activeSelf == true || WeaponSlot05.activeSelf == true
 || WeaponSlot06.activeSelf == true || WeaponSlot07.activeSelf == true){
StartCoroutine(WaitForSlot02());
}	
else{
WeaponSlot02.SetActive (true);	
}
}

if (Input.GetKeyDown(KeyCode.Alpha3))
{
if (WeaponSlot01.activeSelf == true || WeaponSlot02.activeSelf == true
 || WeaponSlot04.activeSelf == true || WeaponSlot05.activeSelf == true
 || WeaponSlot06.activeSelf == true || WeaponSlot07.activeSelf == true){
StartCoroutine(WaitForSlot03());
}	
else{
WeaponSlot03.SetActive (true);	
}
}

if (Input.GetKeyDown(KeyCode.Alpha4))
{
if (WeaponSlot01.activeSelf == true || WeaponSlot02.activeSelf == true
 || WeaponSlot03.activeSelf == true || WeaponSlot05.activeSelf == true
 || WeaponSlot06.activeSelf == true || WeaponSlot07.activeSelf == true){
StartCoroutine(WaitForSlot04());
}	
else{
WeaponSlot04.SetActive (true);	
}
}

if (Input.GetKeyDown(KeyCode.Alpha5))
{
if (WeaponSlot01.activeSelf == true || WeaponSlot02.activeSelf == true
 || WeaponSlot03.activeSelf == true || WeaponSlot04.activeSelf == true
 || WeaponSlot06.activeSelf == true || WeaponSlot07.activeSelf == true){
StartCoroutine(WaitForSlot05());
}	
else{
WeaponSlot05.SetActive (true);	
}
}

if (Input.GetKeyDown(KeyCode.Alpha6))
{
if (WeaponSlot01.activeSelf == true || WeaponSlot02.activeSelf == true
 || WeaponSlot03.activeSelf == true || WeaponSlot04.activeSelf == true
 || WeaponSlot05.activeSelf == true || WeaponSlot07.activeSelf == true){
StartCoroutine(WaitForSlot06());
}	
else{
WeaponSlot06.SetActive (true);	
}
}

if (Input.GetKeyDown(KeyCode.Alpha7))
{
if (WeaponSlot01.activeSelf == true || WeaponSlot02.activeSelf == true
 || WeaponSlot03.activeSelf == true || WeaponSlot04.activeSelf == true
 || WeaponSlot05.activeSelf == true || WeaponSlot06.activeSelf == true){
StartCoroutine(WaitForSlot07());
}	
else{
WeaponSlot07.SetActive (true);	
}
}
}

IEnumerator WaitForSlot01(){
yield return new WaitForSeconds (0.5f);
WeaponSlot01.SetActive (true);
}
IEnumerator WaitForSlot02(){
yield return new WaitForSeconds (0.5f);
WeaponSlot02.SetActive (true);
}
IEnumerator WaitForSlot03(){
yield return new WaitForSeconds (0.5f);
WeaponSlot03.SetActive (true);
}
IEnumerator WaitForSlot04(){
yield return new WaitForSeconds (0.5f);
WeaponSlot04.SetActive (true);
}
IEnumerator WaitForSlot05(){
yield return new WaitForSeconds (0.5f);
WeaponSlot05.SetActive (true);
}
IEnumerator WaitForSlot06(){
yield return new WaitForSeconds (0.5f);
WeaponSlot06.SetActive (true);
}
IEnumerator WaitForSlot07(){
yield return new WaitForSeconds (0.5f);
WeaponSlot07.SetActive (true);
}
}
