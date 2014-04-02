using UnityEngine;
using System.Collections;

public class Door1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	bool opened = false;
	
	// Update is called once per frame
	void Update () {
		var ui = GameObject.Find ("Main Camera");
		UI ui_script = ui.GetComponent<UI>();

		var Boo = GameObject.Find ("playerChar");
		TalkToBoo talk_script = Boo.GetComponent<TalkToBoo>();
		
		int cur_level = ui_script.getLvl();
		
		if(cur_level == 1){
			if(opened == false)	{
				talk_script.trigger = 10;
				Vector3 new_pos = new Vector3(1.94719f, 2.78724f, -9.4773f);
				transform.localPosition = new_pos;
				Vector3 new_rot = new Vector3(0f, 110.355f, 0f);
				transform.eulerAngles = new_rot;
			}
			opened = true;
		}
	}
}
