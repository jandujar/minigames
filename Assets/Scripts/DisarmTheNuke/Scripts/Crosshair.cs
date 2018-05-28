using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
public bool drawCrosshair = true;
public Color crosshairColor = Color.white;   //The crosshair color
         
public int width = 3;      //Crosshair width
public int height = 20;     //Crosshair height

[System.Serializable]        
public class spreading{
     public float spread = 20.0f;          //Adjust this for a bigger or smaller crosshair
     public float maxSpread = 60.0f;
     public float minSpread = 20.0f;
     public float spreadPerSecond = 30.0f;
     public float decreasePerSecond = 25.0f;
 }

 public spreading spread;
         
 private Texture2D tex;
 private GUIStyle lineStyle;

	// Use this for initialization
void Awake (){
	crosshairColor = Color.white;
	 gameObject.SetActive (true);
     tex = new Texture2D(1,1);
     SetColor(tex, crosshairColor); //Set color
     lineStyle = new GUIStyle();
     lineStyle.normal.background = tex;
 }
	
	// Update is called once per frame
	void Update (){
     if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.W)) {
         spread.spread += spread.spreadPerSecond * Time.deltaTime * 5 ;       //Incremente the spread
         Fire();
     }else{
         spread.spread -= spread.decreasePerSecond * Time.deltaTime * 5;      //Decrement the spread        
     }
     
     spread.spread = Mathf.Clamp(spread.spread, spread.minSpread, spread.maxSpread);  
 }
         
 void OnGUI (){
     Vector2 centerPoint = new Vector2(Screen.width / 2, Screen.height / 2);
                
     if(drawCrosshair){
         GUI.Box(new Rect(centerPoint.x - width / 2, centerPoint.y - (height + spread.spread), width, height), "", lineStyle);
         GUI.Box(new Rect(centerPoint.x - width / 2, centerPoint.y + spread.spread, width, height), "", lineStyle);
         GUI.Box(new Rect(centerPoint.x + spread.spread, (centerPoint.y - width / 2), height , width), "", lineStyle);
         GUI.Box(new Rect(centerPoint.x - (height + spread.spread), (centerPoint.y - width / 2), height , width), "", lineStyle);
     }   
 }
 
 void Fire(){
     //Carry out your normal shooting and stuff
 }
     //Applies color to the crosshair
 void SetColor(Texture2D myTexture, Color myColor){
     for (int y = 0; y < myTexture.height; ++y){
         for (int x = 0; x < myTexture.width; ++x){
             myTexture.SetPixel(x, y, myColor);
         }
     }
     
     myTexture.Apply();
 }
}
