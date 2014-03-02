using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {
	public GameObject ui = null;

	// Use this for initialization
	void Start () {
		ui = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Player") {
			ui.SendMessage("addCandy");
			Debug.Log("Picked up Candy");
			GameObject.Destroy(gameObject);
		}
	}
}
