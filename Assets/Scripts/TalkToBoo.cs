using UnityEngine;
using System.Collections;

public class TalkToBoo : MonoBehaviour {
	
	
	public bool inRange = false;
	public int trigger = 0;
	public Font WashingtonText;
	public bool DoorsOpen = false;
	
	private bool SpokenOpen = true;
	private bool SpokenClosed = false;
	
	public Texture2D text_box;
	public Texture2D text_box_2;
	
	bool toopoor = false;
	void OnGUI() {
		GUI.skin.font = WashingtonText;
		
		
		if(trigger == 1)	{
			GUI.Box ( new Rect(500, 600, 700, 70), text_box);
			GUI.Box ( new Rect (500, 600,700,70), "Enough lazing about boy!");
		}
		else if(trigger == 2){
			GUI.Box ( new Rect(500, 600, 700, 70), text_box);
			GUI.Box ( new Rect (500, 600,700,70), "Don't you want your candy back?");
		}
		else if(trigger == 3){
			GUI.Box ( new Rect(500, 600, 700, 70), text_box);
			GUI.Box ( new Rect (550, 600,700,70), "Have at them!");
		}
		else if(trigger == 12){
			GUI.Box ( new Rect(300, 600, 900, 70), text_box_2);
			GUI.Box ( new Rect (300, 600, 900, 70), "Such a kind gesture from a kind young man!");
		}
		else if(trigger == 13)	{
			GUI.Box ( new Rect(500, 600, 900, 70), text_box_2);
			GUI.Box (new Rect (500, 600, 900, 70), "That's not nearly enough to satisfy me!");
		}
		else if(trigger == 15)	{
			GUI.Box ( new Rect(300, 600, 900, 70), text_box_2);
			GUI.Box (new Rect (300, 600, 750, 70), "Well done young man! You've earned a brief respite.");
		}
		else if(trigger == 16)	{
			GUI.Box ( new Rect(300, 600, 900, 70), text_box_2);
			GUI.Box (new Rect (300, 600, 750, 70), "Ready your arms, here they come!");
		}
		
		
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
	public void Poor(){
		toopoor = true;
	}
	// Update is called once per frame
	void Update () {
		var ui = GameObject.Find ("Main Camera");
		UI ui_script = ui.GetComponent<UI>();
		
		int cur_level = ui_script.getLvl ();
		
		if(inRange == true){
			if(Input.GetKeyDown("t")){
				trigger++;
				if(trigger == 4)
					trigger = 0;
			}
		}
		if(Input.GetKeyDown("t") && trigger > 9)
			trigger = 0;
		
		if(Input.GetKeyDown("space")){
			trigger = 0;
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
		//else
		//	trigger = 0;
	}
}