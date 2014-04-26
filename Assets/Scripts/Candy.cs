using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {
	public GameObject ui = null;
	public int num;
	// Use this for initialization
	void Start () {
		ui = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Player") {
			ui.SendMessage("addCandy", num);
			Debug.Log("Picked up Candy " + num.ToString());
			GameObject.Destroy(gameObject);
		}
	}

	void setVal(int howmuch) {
		num = howmuch;
		Debug.Log ("Value set to " + num);
	}
}
