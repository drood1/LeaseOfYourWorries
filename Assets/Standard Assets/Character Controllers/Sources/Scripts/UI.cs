using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public GameObject Heart = null;
	int Candies = 3;
	public int curRep = 0;
	private int maxRep = 100;
	private int curLevel = 1;
	//public Texture repTexture = null;

	public float repBarLength;
	// Use this for initialization
	void Start () {
		repBarLength = Screen.width/2;
		curRep = 0;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentRep(1);
		if(curRep >= maxRep){
			curRep = 0;
			curLevel++;
			maxRep += (20 *curLevel);
		}
		//GameObject shot = Instantiate (Heart, Vector3(0,0,0),Quaternion.identity) as GameObject;

	}
	public void AdjustCurrentRep(int adjRep){
		curRep += adjRep;
		repBarLength = (Screen.width/3)*(curRep /(float)maxRep);
	}
	void OnGUI () {
		GUI.Label ( new Rect (10,Screen.height - 20,100,50), "Candies " + Candies);
		//GUI.Box(new Rect(20,50,60,curRep), curRep + " / " + maxRep);
		GUI.Box(new Rect(10,50,repBarLength,25),"");
		GUI.Box(new Rect(10,50,(Screen.width/3),25), curRep + " / " + maxRep + " Rep");
	}
}
