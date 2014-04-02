using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public Texture Bar = null;
	public Texture BarBack = null;
	public Texture candy = null;
	public GUIStyle style = null;
	int Candies = 99;
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
		repBarLength = (512)*(curRep /(float)maxRep);
	}
	public int getLvl(){
		return curLevel;
	}
	public int getcan(){
		return Candies;
	}
	public void setcan(int a){
		Candies = a;
	}
	void OnGUI () {
		GUI.Label ( new Rect (85,Screen.height - 55,100,50), "" + Candies,style);
		//GUI.Box(new Rect(20,50,60,curRep), curRep + " / " + maxRep);
		GUI.Box(new Rect(10,90,repBarLength,25),"");
		GUI.Box(new Rect(10,90,512,25), curRep + " / " + maxRep + " Rep");
		GUI.DrawTexture(new Rect(532,0,413,88),BarBack);
		GUI.DrawTexture(new Rect(532,0,413,88),Bar);
		GUI.DrawTexture(new Rect(10,Screen.height - 100,64,100),candy);

	}
	void addCandy() {
		Candies++;
	}
}
