using UnityEngine;
using System.Collections;

public class BooregardDetection : MonoBehaviour {
	
	//NEED TO MAKE IT SO WHEN EXITING BOOREGARDS "RANGE", SET INRANGE TO FALSE
	
	void OnTriggerEnter(Collider coll)	{
		GameObject g = coll.gameObject;	
		TalkToBoo charCode = g.GetComponent<TalkToBoo>();

		if(charCode != null){
			charCode.inRange = true;
		}
	}
	
	void OnTriggerExit(Collider coll)	{
		GameObject g = coll.gameObject;
		TalkToBoo charCode = g.GetComponent<TalkToBoo>();

		if(charCode != null){
			charCode.inRange = false;
			if(charCode.trigger < 10)
				charCode.trigger = 0;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}