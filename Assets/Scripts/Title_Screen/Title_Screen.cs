using UnityEngine;
using System.Collections;

public class Title_Screen : MonoBehaviour {

	public Texture buttonTexture;
	public GUISkin titleSkin;
	public string myLevel;


	void OnGUI()	{

		int buttonWidth = 380;
		int buttonHeight = 100;

		float halfScreenWidth = Screen.width/2;
		float halfButtonWidth = buttonWidth/2;

		GUI.skin = titleSkin;

		if(GUI.Button(new Rect(halfScreenWidth - halfButtonWidth, 590, buttonWidth, buttonHeight), buttonTexture)){
			Application.LoadLevel(myLevel);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
