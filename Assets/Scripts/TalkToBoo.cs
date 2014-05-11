using UnityEngine;
using System.Collections;

public class TalkToBoo : MonoBehaviour {
	
	//boolean to see if the player is within a certain radius of Booregard (The patrolling NPC)
	public bool inRange = false;
	//trigger variable to determine what dialogue to use
	public int trigger = 0;
	//fancy style font for the dialogue (defined in the Inspector)
	public GUIStyle boo_font;
	//boolean to see if the doors of the house are open or not
	public bool DoorsOpen = false;


	private bool SpokenOpen = true;
	private bool SpokenClosed = false;

	//images to use as backdrops for the dialogue
	public Texture2D text_box;
	public Texture2D text_box_2;

	//self-explanatory. When trigger == 0, there will be no text box or dialogue
	void resetTrigger()	{
		trigger = 0;
	}


	void OnGUI() {

		//triggers 1-3 are for idle converation with Booregard
		
		if(trigger == 1)	{
			GUI.DrawTexture( new Rect(290, 600, 700, 70), text_box);
			GUI.Label ( new Rect (375, 600,700,70), "Enough lazing about boy!", boo_font);
		}
		else if(trigger == 2){
			GUI.DrawTexture ( new Rect(270, 600, 760, 70), text_box);
			GUI.Label ( new Rect (315, 600,700,70), "Don't you want your candy back?", boo_font);
		}
		else if(trigger == 3){
			GUI.DrawTexture ( new Rect(450, 600, 400, 70), text_box);
			GUI.Label ( new Rect (500, 600,700,70), "Have at them!", boo_font);
		}

		//triggered when the player gives Booregard candy in exchange for reputation (disappears after 2 seconds)
		else if(trigger == 12){
			GUI.DrawTexture ( new Rect(170, 600, 950, 70), text_box_2);
			GUI.Label ( new Rect (200, 600, 900, 70), "Such a kind gesture from a kind young man!", boo_font);
			//clear after 2 seconds
			Invoke ("resetTrigger", 2);
		}

		//triggered when the player tries to give Booregard candy, but doesn't have enough
		else if(trigger == 13)	{
			GUI.DrawTexture ( new Rect(220, 600, 900, 70), text_box_2);
			GUI.Label (new Rect (270, 600, 900, 70), "That's not nearly enough to satisfy me!", boo_font);
			Invoke ("resetTrigger", 2);
		}

		//triggered between waves (doors are then opened temporarily)
		else if(trigger == 15)	{
			GUI.DrawTexture ( new Rect(220, 600, 900, 70), text_box_2);
			GUI.Label (new Rect (250, 600, 750, 70), "Well done! You've earned a brief respite.", boo_font);
			Invoke ("resetTrigger", 2);
		}

		//triggered at the start of a wave (doors get closed)
		else if(trigger == 16)	{
			GUI.DrawTexture ( new Rect(220, 600, 900, 70), text_box_2);
			GUI.Label (new Rect (325, 600, 750, 70), "Ready your arms, here they come!", boo_font);
			Invoke ("resetTrigger", 2);
		}

		//triggered when player tries to trade candy for a new weapon, but doesn't have enough
		else if(trigger == 17)	{	
			GUI.DrawTexture ( new Rect(210, 600, 920, 70), text_box_2);
			GUI.Label (new Rect (225, 600, 750, 70), "I'm afraid that's a bit out of your range boy.", boo_font);
			Invoke ("resetTrigger", 2);
		}

		//conditions for dialogue for start/end of waves
		if(DoorsOpen == true && SpokenOpen == false)	{
			trigger = 15;
			SpokenOpen = true;
			SpokenClosed = false;
		}
		if(DoorsOpen == false && SpokenClosed == false)	{
			trigger = 16;
			SpokenClosed = true;
			SpokenOpen = false;
		}

	}
	
	void Update () {
		//finding the UI script attached to the camera to access its public variables
		var ui = GameObject.Find ("Main Camera");
		UI ui_script = ui.GetComponent<UI>();

		//idle conversation with Booregard by pressing t while in range
		//if the player exits Booregard's "range", the trigger will reset to 0
		if(inRange == true){
			if(Input.GetKeyDown("t")){
				if(trigger < 10)
					trigger++;
				if(trigger == 4)
					trigger = 0;
			}
		}

		//press space to clear out any current text (was mostly just used for debug/testing)
		if(Input.GetKeyDown("space")){
			resetTrigger ();
		}
		
		//********************trading candy for rep******************
		if(inRange == true) {
			if(Input.GetKeyDown ("c")){
				if(ui_script.Candies < 10)
					trigger = 13;
				else{
					trigger = 12;
					ui_script.Candies -= 10;
					ui_script.curRep += 20;
				}
			}
		}
	}
}