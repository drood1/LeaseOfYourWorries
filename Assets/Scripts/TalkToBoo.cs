using UnityEngine;
using System.Collections;

public class TalkToBoo : MonoBehaviour {

	public bool inRange = false;
	public int trigger = 0;
	bool toopoor = false;
	void OnGUI() {
		if(trigger == 1)	{
			//GUI.skin.font = Canterbury;
			GUI.Label ( new Rect (300, 300,350,300), "WHY HULLO THAR!");
		}
		else if(trigger == 2)
			GUI.Label ( new Rect (300, 300,350,300), "THIS IS A TEXT BAWKS");
		else if(trigger == 3)
			GUI.Label ( new Rect (300, 300,350,300), "IT TELLS YOU THINGS :o!");
		else trigger = 0;
		if(toopoor)
			GUI.Label ( new Rect (300, 300,350,300), "You poor!");
	}
	public void Poor(){
		toopoor = true;
	}
	// Update is called once per frame
	void Update () {
		if(inRange == true){
			if(Input.GetKeyDown("t")){
				trigger++;
			}
	}
	}
}