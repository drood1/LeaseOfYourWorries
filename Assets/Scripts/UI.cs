using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public Texture Bar = null;
	public Texture Bar1 = null;
	public Texture Bar2 = null;
	public Texture Bar3 = null;
	public Texture Bar4 = null;
	public Texture Enem = null;
	public Texture BarBack = null;
	public Texture candy = null;
	public GUIStyle style = null;
	public GUIStyle style2 = null;
	public GUIStyle style3 = null;
	public int Candies = 99;
	public int curRep = 0;
	private int maxRep = 99;
	private int curLevel = 0;
	private int maxLevel = 4;
	private int enemy_count = 0;
    float timeToWave = 0;
	int yo = 0;
	//public Texture repTexture = null;
	
	public float repBarLength;
	// Use this for initialization
	void Start () {
		repBarLength = (409)*(curRep /(float)maxRep);
		curRep = 0;


	}
	
	// Update is called once per frame
	void Update () {
		if(curLevel < maxLevel){
			//AdjustCurrentRep(1);
			if(curRep >= maxRep){
				curRep = curRep-maxRep;
				curLevel++;
				maxRep += (20 *curLevel) + 100;
				
			}
			if(Input.GetKeyDown ("p")){
				curLevel++;
			}
		}
		//GameObject shot = Instantiate (Heart, Vector3(0,0,0),Quaternion.identity) as GameObject;
		yo = (int)timeToWave;
	}
	public void AdjustCurrentRep(int adjRep){
		curRep += adjRep;
		repBarLength = (409)*(curRep /(float)maxRep);
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
		GUI.DrawTexture(new Rect(975,10,89,112),Enem);
		// Enemy Count
		if(enemy_count < 10)
			GUI.Label ( new Rect(1010,80,89,112), "0" + enemy_count.ToString(), style3);
		else
			GUI.Label ( new Rect(1010,80,89,112), enemy_count.ToString(), style3);

		if(timeToWave > 0)
			GUI.Label (new Rect (1150,80, 89, 112), "Time to Next Wave: " + yo.ToString(), style3);
		// gray bar behind Rep meter
		GUI.DrawTexture(new Rect(532,10,425,77),BarBack);
		// Increasing bar
		if(curRep > 0 && curLevel != 4)
			GUI.Box(new Rect(540,30,repBarLength,48),"");
		if(curLevel == 0){
		// Actual Rep meter
			GUI.DrawTexture(new Rect(532,10,425,77),Bar);
		}
		if(curLevel == 1){
			GUI.DrawTexture(new Rect(532,10,425,77),Bar1);
		}
		if(curLevel == 2){
			GUI.DrawTexture(new Rect(532,10,425,77),Bar2);
		}
		if(curLevel == 3){
			GUI.DrawTexture(new Rect(532,10,425,77),Bar3);
		}
		if(curLevel == 4){
			GUI.DrawTexture(new Rect(532,10,425,77),Bar4);
		}
		GUI.DrawTexture(new Rect(10,Screen.height - 100,64,100),candy);
		if(curLevel != 4) //If not at max Rep, display current Rep out of amount needed for next level
			GUI.Box(new Rect(532,27,393,54), curRep + " / " + maxRep + " Rep", style2);
		else
			GUI.Box(new Rect(562,27,393,54), "Maxed out Rep", style2);
	}
	void addCandy() {
		Candies++;
	}

	void DisplayEnemyCount(int count) {
		enemy_count = count;
	}
	void DisplayTimeToNextWave(float yo) {
		timeToWave = yo;
	}
}
