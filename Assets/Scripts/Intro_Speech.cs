using UnityEngine;
using System.Collections;

public class Intro_Speech : MonoBehaviour {
	public int trigger = 1;
	public GUIStyle boo_font;
	
	public Texture2D text_box;
	public Texture2D text_box_2;
	
	
	void next1()	{
		trigger=2;
	}

	void next2()	{
		trigger=3;
	}
	void next3()	{
		trigger=4;
	}
	void next4()	{
		trigger=5;
	}
	void next5()	{
		Application.LoadLevel("Lease Of Your Worries");
	}
	
	void OnGUI() {
		
		
		if(trigger == 1)	{
			GUI.DrawTexture( new Rect(150, 600, 1010, 70), text_box_2);
			GUI.Label ( new Rect (175, 600,700,70), "Welcome to my abode. My name is Booregard.", boo_font);
			Invoke ("next1", 3);
		}
		else if(trigger == 2){
			GUI.DrawTexture ( new Rect(130, 600, 1100, 70), text_box_2);
			GUI.Label ( new Rect (150, 600,700,70), "It seems those scoundrels absconded with your candy!", boo_font);
			Invoke ("next2", 3);
		}
		else if(trigger == 3){
			GUI.DrawTexture ( new Rect(110, 600, 1150, 70), text_box_2);
			GUI.Label ( new Rect (130, 600,700,70), "You may borrow my possessions to get your candy back.", boo_font);
			Invoke ("next3", 3);
		}
		else if(trigger == 4){
			GUI.DrawTexture ( new Rect(135, 600, 1100, 70), text_box_2);
			GUI.Label ( new Rect (150, 600, 900, 70), "However, I will require compensation for my trouble.", boo_font);
			Invoke ("next4", 3);
		}
		else if(trigger == 5)	{
			GUI.DrawTexture ( new Rect(360, 600, 600, 70), text_box_2);
			GUI.Label (new Rect (370, 600, 750, 70), "Tally ho! Let the hunt begin!", boo_font);
			Invoke ("next5", 3);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("t")){
			trigger++;
			if(trigger == 6){
				Application.LoadLevel("Lease Of Your Worries");
				trigger = 0;
			}
		}
//		print (trigger);
	}
}