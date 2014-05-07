using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GUISkin customskin = null;
	public Texture Base = null;
	public Texture Tut = null;
	public Texture Tut2 = null;
	public Texture Tut3 = null;
	public GUISkin but = null;
	public GUISkin but2 = null;
	public GUISkin but3 = null;
	private bool tut = false;
	private int screen = 0;
	public void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

	}
	public void OnGUI(){
		if(customskin != null)
			GUI.skin = customskin;
		int buttonwidth = 300;
		int buttonheight = 135;
		int halfbuttonwidth = buttonwidth/2;
		int halfscreenwidth = Screen.width/2;
		if (tut == false){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Base);
			GUI.skin = but;
			if(GUI.Button(new Rect(halfscreenwidth-(buttonwidth)-10,Screen.height - buttonheight-10,buttonwidth,buttonheight)," ")){
				Application.LoadLevel("Intro_Scene");

			}
			GUI.skin = but2;
			if(GUI.Button(new Rect(halfscreenwidth+10,Screen.height - buttonheight-10,buttonwidth,buttonheight), " ")){
				tut = true;
				
			}
		}
		if (tut == true){
			if(screen == 0)
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Tut);
			if(screen == 1)
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Tut2);
			if(screen == 2)
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Tut3);
			GUI.skin = but3;
			if(GUI.Button(new Rect(Screen.width - 214,Screen.height - 101,206,93)," ")){
				screen++;
				if(screen > 2){
					screen = 0;
					tut = false;
				}
			}

		}
	}
}
