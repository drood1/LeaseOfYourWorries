using UnityEngine;
using System.Collections;

public class ItemWarp : MonoBehaviour {
	private GameObject player = null;
	public GameObject Boo = null;
	public GameObject cam = null;
	GameObject hand;
	GameObject wep;
	public bool eq = false;
	public int wepnum = 0;
	public int wepdmg = 0;
	public int wepbul = 0;
	public float wepcd = 0f;
	public float weprange = 0f;
	public int level = 0;
	public bool melee = false;
	public int[] arraystats;
	private Vector3 ov;
	public Texture popup;
	public Texture popups;
	public Texture popups1;
	public Texture popups2;
	public Texture popups3;
	public Texture popups4;
	public Sprite[] array;
	public float MAX_RANGE = 40;
	private bool showme = false;
	Grabbing whatdo;
	// Use this for initialization
	void Start () {
		MAX_RANGE = 2.5f;
		cam = GameObject.FindWithTag("MainCamera");
		player = GameObject.FindWithTag("Player");
		hand = GameObject.FindWithTag("Hand");
		Boo = GameObject.FindWithTag("Boo");
		if(wepnum == 1){
			wep = GameObject.Find("jnt_poker");
		}
		if(wepnum == 2){
			wep = GameObject.Find("jnt_bucket");
		}
		if(wepnum == 3){
			wep = GameObject.Find("jnt_knife");
		}
		if(wepnum == 4){
			wep = GameObject.Find("jnt_duster");
		}
		if(wepnum == 5){
			wep = GameObject.Find("jnt_bread");
		}
		if(wepnum == 6){
			wep = GameObject.Find("jnt_book");
		}
		if(wepnum == 7){
			wep = GameObject.Find("jnt_rifle");
		}
		if(wepnum == 8){
			wep = GameObject.Find("jnt_sword");
		}
		if(wepnum == 9){
			wep = GameObject.Find("jnt_rapier");
		}
		if(wepnum == 10){
			wep = GameObject.Find("jnt_turkeyLeg");
		}
		if(wepnum == 11){
			wep = GameObject.Find("jnt_rake");
		}
		if(wepnum == 12){
			wep = GameObject.Find("jnt_razor");
		}
		if(wepnum == 13){
			wep = GameObject.Find("jnt_rollingPin");
		}
		collider.isTrigger = true;
		arraystats = new int[2];
		arraystats[0] = wepdmg;
		arraystats[1] = wepbul;

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void OnGUI(){
		if(eq == false){
			int plvl = cam.GetComponent<UI>().getLvl();
			int temp = plvl - level;
			int pcandies = cam.GetComponent<UI>().getcan();
			if(temp >= 0)
				popup = popups;
			if(temp == -1)
				popup = popups1;
			if(temp == -2)
				popup = popups2;
			if(temp == -3)
				popup = popups3;
			if(temp <= -4)
				popup = popups4;
			if(showme)
				GUI.DrawTexture(new Rect(Input.mousePosition.x,Screen.height-Input.mousePosition.y,100,100),popup);
		}
	}
	void OnMouseExit(){
		showme = false;

	}
	void OnMouseOver (){
		//if(whatdo.holdingitem == false){

		float dist = Vector3.Distance(this.transform.position,player.transform.position);
		//Debug.Log(player.transform.position);
		//Debug.Log(dist);
		if(dist <= MAX_RANGE){
			showme = true;
		}
		if(Input.GetMouseButtonDown(1) && dist <= MAX_RANGE){
			int plvl = cam.GetComponent<UI>().getLvl();
			int temp = plvl - level;
			int pcandies = cam.GetComponent<UI>().getcan();
			if(temp >= 0)
				pcandies -= 5;
			if(temp == -1)
				pcandies -= 10;
			if(temp == -2)
				pcandies -= 20;
			if(temp == -3)
				pcandies -= 35;
			if(temp <= -4)
				pcandies -= 75;
			if(pcandies < 0){
				//Boo.SendMessage("Warp");
				player.SendMessage("Poor");
			}else{
				eq = true;
				cam.GetComponent<UI>().setcan(pcandies);
				player.SendMessage("Equip",wepnum);
				//Boo.SendMessage("Warp");
				player.GetComponent<Shooting>().stat(arraystats,wepcd,weprange,melee);
				//wep.collider.enabled = false;
				//player.gameObject.GetComponent<Grabbing>().holding(true);
			//gameObject.transform.parent = player.transform.Find("Bip001/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/Bip001 R Hand").transform;
				wep.transform.parent = hand.transform;
				wep.transform.localPosition = new Vector3(0,0,0);
				ov = this.transform.eulerAngles;
				this.transform.rotation = Quaternion.identity;
	

			//this.transform.localRotation = Quaternion.Euler(0, 0, -50);
			//gameObject.transform.parent.gameObject;
			}
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "enemy" || other.gameObject.tag == "weap"){

		}
	}
	public void unequip(int numnum){
		this.transform.parent = null;
		this.transform.eulerAngles = ov;
		eq = false;
	}
	}