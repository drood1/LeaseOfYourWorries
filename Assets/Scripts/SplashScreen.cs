using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GUISkin customskin = null;
	public Texture Base = null;
	public Texture Tut = null;
	private bool tut = false;
	public void OnGUI(){
		if(customskin != null)
			GUI.skin = customskin;
		int buttonwidth = 100;
		int buttonheight = 100;
		int halfbuttonwidth = buttonwidth/2;
		int halfscreenwidth = Screen.width/2;
		if (tut == false){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Base);
			if(GUI.Button(new Rect(halfscreenwidth-(buttonwidth/2),500,buttonwidth,buttonheight),"Play")){
				Application.LoadLevel("Lease Of Your Worries");

			}
			if(GUI.Button(new Rect(halfscreenwidth+(buttonwidth/2),500,buttonwidth,buttonheight),"Instructions")){
				tut = true;
				
			}
		}
		if (tut == true){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Tut);
			if(GUI.Button(new Rect(halfscreenwidth-halfbuttonwidth,400,buttonwidth,buttonheight),"Back")){
				tut = false;
			}

		}
	}
}
