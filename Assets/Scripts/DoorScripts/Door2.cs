using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour {
	Vector3 closed;
	Vector3 rot;
	
	// Use this for initialization
	void Start () {
		closed = transform.localPosition;
		rot = transform.eulerAngles;
	}

	bool opened = false;
	
	// Update is called once per frame
	void Update () {
		var ui = GameObject.Find ("Main Camera");
		//UI ui_script = ui.GetComponent<UI>();

		var Boo = GameObject.Find ("playerChar");
		//TalkToBoo talk_script = Boo.GetComponent<TalkToBoo>();

		//int cur_level = ui_script.getLvl ();
		
		/*if(cur_level == 2){
			if(opened == false)	{
				talk_script.trigger = 20;
				Vector3 new_pos = new Vector3(24.9512f, 2.78724f, -7.0862f);
				transform.localPosition = new_pos;
				Vector3 new_rot = new Vector3(0f, 295.645f, 0f);
				transform.eulerAngles = new_rot;
			}
			opened = true;
		}*/
	}
	void OpenDoor() {
		opened = true;
		Vector3 new_pos = new Vector3(24.9512f, 2.78724f, -7.0862f);
		transform.localPosition = new_pos;
		Vector3 new_rot = new Vector3(0f, 295.645f, 0f);
		transform.eulerAngles = new_rot;
	}
	
	void CloseDoor() {
		opened = false;
		transform.localPosition = closed;
		transform.localEulerAngles = rot;
		
	}
}
