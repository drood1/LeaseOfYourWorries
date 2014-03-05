using UnityEngine;
using System.Collections;

public class BooregardDetection : MonoBehaviour {

	void OnTriggerEnter(Collider coll)	{
		GameObject g = coll.gameObject;
		print ("In range of Booregard.");	
		TalkToBoo charCode = g.GetComponent<TalkToBoo>();
		if(charCode != null){
			charCode.inRange = true;
	}
	}

	// Update is called once per frame
	void Update () {
	
	}
}