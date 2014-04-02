using UnityEngine;
using System.Collections;

public class TalkToBoo : MonoBehaviour {
	
	//NEED TO MAKE IT SO WHEN EXITING BOOREGARDS "RANGE", SET INRANGE TO FALSE
	
	public bool inRange = false;
	public int trigger = 0;
	public GameObject boo = null;
	/*
	void OnGUI() {
		if(inRange == true)	{
			if(trigger == 1)	{
				//GUI.skin.font = Canterbury;
				GUI.Label ( new Rect (700, 600,350,300), "WHY HULLO THAR!");
			}
			else if(trigger == 2)
				GUI.Label ( new Rect (700, 600,350,300), "THIS IS A TEXT BAWKS");
			else if(trigger == 3)
				GUI.Label ( new Rect (700, 600,350,300), "IT TELLS YOU THINGS :o!");
			else trigger = 0;
		}
		else
			trigger = 0;

		//need to set first variable to Booregard's transform.position
	}
	*/
	
	bool toopoor = false;
	void OnGUI() {
		if(trigger == 1)	{
			GUI.Label ( new Rect (550, 600,550,300), "Enough lazing about boy!");
		}
		else if(trigger == 2)
			GUI.Label ( new Rect (550, 600,550,300), "Don't you want your candy back?");
		else if(trigger == 3)
			GUI.Label ( new Rect (550, 600,550,300), "Have at them!");
		else if(trigger == 10)
			GUI.Label ( new Rect (550, 600,550,300), "It seems you have some spunk about you! Why don't you try your luck in the dining hall?");
		else if(trigger == 20)
			GUI.Label ( new Rect (550, 600,550,300), "Forget the spunk, you've got good old-fashioned moxie! Feel free to poke around the master bedroom.");
		else if(trigger == 30)
			GUI.Label ( new Rect (550, 600,550,300), "There seems to be even more ruffians occupying the bathroom. Be a lad and clear them out for me.");
		else if(trigger == 40)
			GUI.Label ( new Rect (550, 600,550,300), "You continue to impress me my boy! Feel free to peruse my entire estate and give those delinquents what for!");
		if(toopoor)
			GUI.Label ( new Rect (550, 600,550,300), "You poor!");
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
				if(trigger == 4 || trigger == 10 || trigger == 20 || trigger == 30 || trigger == 40)
					trigger = 0;
			}
		}
		if(Input.GetKeyDown("t") && trigger > 9)
			trigger = 0;

		if(Input.GetKeyDown("space")){
			trigger = 0;
		}


	}
}