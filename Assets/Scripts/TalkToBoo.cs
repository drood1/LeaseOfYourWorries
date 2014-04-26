using UnityEngine;
using System.Collections;

public class TalkToBoo : MonoBehaviour {
	
	
	public bool inRange = false;
	public int trigger = 0;
	public GUIStyle boo_font;
	public bool DoorsOpen = false;
	
	private bool SpokenOpen = true;
	private bool SpokenClosed = false;
	
	public Texture2D text_box;
	public Texture2D text_box_2;
	
	bool toopoor = false;
	void OnGUI() {
		
		
		if(trigger == 1)	{
			GUI.DrawTexture( new Rect(400, 600, 700, 70), text_box);
			GUI.Label ( new Rect (500, 600,700,70), "Enough lazing about boy!", boo_font);
		}
		else if(trigger == 2){
			GUI.DrawTexture ( new Rect(350, 600, 700, 70), text_box);
			GUI.Label ( new Rect (360, 600,700,70), "Don't you want your candy back?", boo_font);
		}
		else if(trigger == 3){
			GUI.DrawTexture ( new Rect(350, 600, 700, 70), text_box);
			GUI.Label ( new Rect (550, 600,700,70), "Have at them!", boo_font);
		}
		else if(trigger == 12){
			GUI.DrawTexture ( new Rect(150, 600, 900, 70), text_box_2);
			GUI.Label ( new Rect (300, 600, 900, 70), "Such a kind gesture from a kind young man!", boo_font);
		}
		else if(trigger == 13)	{
			GUI.DrawTexture ( new Rect(350, 600, 900, 70), text_box_2);
			GUI.Label (new Rect (500, 600, 900, 70), "That's not nearly enough to satisfy me!", boo_font);
		}
		else if(trigger == 15)	{
			GUI.DrawTexture ( new Rect(300, 600, 900, 70), text_box_2);
			GUI.Label (new Rect (360, 600, 750, 70), "Well done! You've earned a brief respite.", boo_font);
		}
		else if(trigger == 16)	{
			GUI.DrawTexture ( new Rect(250, 600, 900, 70), text_box_2);
			GUI.Label (new Rect (325, 600, 750, 70), "Ready your arms, here they come!", boo_font);
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