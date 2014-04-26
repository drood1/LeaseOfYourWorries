using UnityEngine;
using System.Collections;

public class Door4 : MonoBehaviour {
	Vector3 closed;
	Vector3 rot;
	bool opened = false;
	// Use this for initialization
	void Start () {
		closed = transform.localPosition;
		rot = transform.eulerAngles;
	}
	// Update is called once per frame
	void Update () {
		var ui = GameObject.Find ("Main Camera");
		//UI ui_script = ui.GetComponent<UI>();

		var Boo = GameObject.Find ("playerChar");
		//TalkToBoo talk_script = Boo.GetComponent<TalkToBoo>();

		//int cur_level = ui_script.getLvl ();
		
		/*if(cur_level == 4){
			if(opened == false){
				talk_script.trigger = 40;
				Vector3 new_pos = new Vector3(19.27148f, 2.78724f, 13.6414f);
				transform.localPosition = new_pos;
				Vector3 new_rot = new Vector3(0f, 247.797f, 0f);
				transform.eulerAngles = new_rot;
			}
			opened = true;
		}*/
	}
	void OpenDoor() {
		opened = true;
		Vector3 new_pos = new Vector3(19.27148f, 2.78724f, 13.6414f);
		transform.localPosition = new_pos;
		Vector3 new_rot = new Vector3(0f, 247.797f, 0f);
		transform.eulerAngles = new_rot;
	}
	
	void CloseDoor() {
		opened = false;
		transform.localPosition = closed;
		transform.localEulerAngles = rot;
		
	}
}
