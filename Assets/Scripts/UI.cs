using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public Texture Bar = null;
	public Texture Bar1 = null;
	public Texture Bar2 = null;
	public Texture Bar3 = null;
	public Texture Bar4 = null;
	public Texture BarBack = null;
	public Texture candy = null;
	public GUIStyle style = null;
	public GUIStyle style2 = null;
	public int Candies = 99;
	public int curRep = 0;
	private int maxRep = 99;
	private int curLevel = 0;
	private int maxLevel = 4;
	//public Texture repTexture = null;
	
	public float repBarLength;
	// Use this for initialization
	void Start () {
		repBarLength = (393)*(curRep /(float)maxRep);
		curRep = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(curLevel < maxLevel){
			//AdjustCurrentRep(1);
			if(curRep >= maxRep){
				curRep = 0;
				curLevel++;
				maxRep += (20 *curLevel) + 100;
				
			}
			if(Input.GetKeyDown ("p")){
				curLevel++;
			}
		}
		//GameObject shot = Instantiate (Heart, Vector3(0,0,0),Quaternion.identity) as GameObject;
		
	}
	public void AdjustCurrentRep(int adjRep){
		curRep += adjRep;
		repBarLength = (393)*(curRep /(float)maxRep);
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
		
		
		GUI.DrawTexture(new Rect(552,0,413,88),BarBack);
		if(curLevel == 0){
			GUI.DrawTexture(new Rect(552,0,413,88),Bar);
		}
		if(curLevel == 1){
			GUI.DrawTexture(new Rect(552,0,413,88),Bar1);
		}
		if(curLevel == 2){
			GUI.DrawTexture(new Rect(552,0,413,88),Bar2);
		}
		if(curLevel == 3){
			GUI.DrawTexture(new Rect(552,0,413,88),Bar3);
		}
		if(curLevel == 4){
			GUI.DrawTexture(new Rect(552,0,413,88),Bar4);
		}
		GUI.DrawTexture(new Rect(10,Screen.height - 100,64,100),candy);
		if(curLevel != 4)
			GUI.Box(new Rect(562,23,393,54), curRep + " / " + maxRep + " Rep", style2);
		else
			GUI.Box(new Rect(562,23,393,54), "Maxed out Rep", style2);
		if(curRep != 0)
			GUI.Box(new Rect(562,23,repBarLength,54),"");
	}
	void addCandy() {
		Candies++;
	}
}
