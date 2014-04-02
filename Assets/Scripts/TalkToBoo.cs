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
			GUI.Label ( new Rect (700, 600,350,300), "WHY HULLO THAR!");
		}
		else if(trigger == 2)
			GUI.Label ( new Rect (700, 600,350,300), "THIS IS A TEXT BAWKS");
		else if(trigger == 3)
			GUI.Label ( new Rect (700, 600,350,300), "IT TELLS YOU THINGS :o!");
		else if(trigger == 10)
			GUI.Label ( new Rect (700, 600,350,300), "MAH BOI, CHECK OUT DAT DINING HALL");
		else if(trigger == 20)
			GUI.Label ( new Rect (700, 600,350,300), "NOW LOOK AT MAH ROOM");
		else if(trigger == 30)
			GUI.Label ( new Rect (700, 600,350,300), "DAT BATHROOM");
		else if(trigger == 40)
			GUI.Label ( new Rect (700, 600,350,300), "MM MMMM DAT KITCHEN");
		if(toopoor)
			GUI.Label ( new Rect (700, 600,350,300), "You poor!");
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