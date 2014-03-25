using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GUISkin customskin = null;
	public void OnGUI(){
		if(customskin != null)
			GUI.skin = customskin;
		int buttonwidth = 100;
		int buttonheight = 100;
		int halfbuttonwidth = buttonwidth/2;
		int halfscreenwidth = Screen.width/2;
		if(GUI.Button(new Rect(halfscreenwidth-halfbuttonwidth,390,buttonwidth,buttonheight),"Play")){
			Application.LoadLevel("Lease Of Your Worries");

		}
	}
}
