using UnityEngine;
using System.Collections;

public class ItemWarp : MonoBehaviour {
	private GameObject player = null;
	private GameObject Boo = null;
	private GameObject cam = null;
	GameObject hand;
	GameObject wep;
	private bool eq = false;
	public int wepnum = 0;
	public int wepdmg = 0;
	public int wepbul = 0;
	public float wepcd = 0f;
	public float weprange = 0f;
	public int level = 0;
	public bool melee = true;
	public int[] arraystats;
	private Quaternion lr;
	private Quaternion ov;
	private Quaternion ovv;
	private Transform prev;
	private Vector3 prevt;
	private Texture popup;
	public Texture popups;
	public Texture popups1;
	public Texture popups2;
	public Texture popups3;
	public Texture popups4;
	private Texture freez;
	public float MAX_RANGE = 40;
	private bool showme = false;
	private bool test = false; 
	public float MAX_CD = 1.5f;
	private float cdnum;
	private bool purchased = false;
	Grabbing whatdo;
	// Use this for initialization
	void Start () {
		cdnum = wepcd/5 * MAX_CD;
		MAX_RANGE = 2.5f;
		cam = GameObject.FindWithTag("MainCamera");
		player = GameObject.FindWithTag("Player");
		hand = GameObject.FindWithTag("Hand");
		Boo = GameObject.FindWithTag("Boo");
		collider.isTrigger = true;
		arraystats = new int[2];
		arraystats[0] = wepdmg;
		arraystats[1] = wepbul;
		prev = this.transform.parent;
		prevt = this.transform.eulerAngles;
		purchased = false;
		freez = Resources.Load("no cost (new color)") as Texture;
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
			if(purchased == true)
				popup = freez;
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
				TalkToBoo talk_script = player.GetComponent<TalkToBoo>();
				talk_script.trigger = 17;
			}
			if(purchased == true || pcandies >= 0){
				eq = true;
				if(purchased == false)
					cam.GetComponent<UI>().setcan(pcandies);
				player.SendMessage("Equip",wepnum);
				//Boo.SendMessage("Warp");
				player.GetComponent<Shooting>().stat(arraystats,cdnum,weprange,melee);
				//wep.collider.enabled = false;
				ov = transform.rotation;
				transform.parent = hand.transform;
				transform.localPosition = new Vector3(0,0,0);
				transform.localRotation = Quaternion.identity;
				if(wepbul == 3){
					//Debug.Log("Line");
					transform.localRotation = Quaternion.Euler(90,0,0);
					
				}
				if(name == "jnt_rifle"){
					transform.localRotation = Quaternion.Euler(0,0,-60);

				}
				purchased = true;
			}


		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "enemy" || other.gameObject.tag == "weap"){

		}
	}
	public void unequip(){

		hand.transform.DetachChildren();
		//this.transform.rotation = Quaternion.identity;
		transform.parent = prev;
		//this.transform.parent.rotation = ovv;
		transform.rotation = ov;
		//this.transform.localRotation = lr;
		//this.transform.eulerAngles = prevt;
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y-.5f,player.transform.position.z);
		if(name == "jnt_bucket")
			transform.position = new Vector3(player.transform.position.x, 2.250953f,player.transform.position.z);
		if(name == "jnt_coatTree")
			transform.position = new Vector3(player.transform.position.x, 2.601861f,player.transform.position.z);
		eq = false;
	}
	}