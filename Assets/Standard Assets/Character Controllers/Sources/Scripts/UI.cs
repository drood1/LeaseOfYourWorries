using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public GameObject Heart = null;
	int Candies = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject shot = Instantiate (Heart, Vector3(0,0,0),Quaternion.identity) as GameObject;
	}
	void OnGUI () {
		GUI.Label ( new Rect (10,Screen.height - 20,100,50), "Candies " + Candies);
	}
}
