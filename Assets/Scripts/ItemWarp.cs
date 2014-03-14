using UnityEngine;
using System.Collections;

public class ItemWarp : MonoBehaviour {
	public GameObject player = null;
	public GameObject Boo = null;
	GameObject hand;
	GameObject wep;
	public int wepnum = 0;
	public int wepdmg = 0;
	public int wepbul = 0;
	public float wepcd = 0f;
	public float weprange = 0f;
	public bool melee = false;
	public int[] arraystats;
	Grabbing whatdo;
	// Use this for initialization
	void Start () {
		hand = GameObject.FindWithTag("Hand");
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
		collider.isTrigger = true;
		arraystats = new int[2];
		arraystats[0] = wepdmg;
		arraystats[1] = wepbul;

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseOver (){
		//if(whatdo.holdingitem == false){


		if(Input.GetMouseButtonDown(1)){
			player.SendMessage("Equip",wepnum);
			Boo.SendMessage("Warp");
			player.GetComponent<Shooting>().stat(arraystats,wepcd,weprange,melee);
				//wep.collider.enabled = false;
				//player.gameObject.GetComponent<Grabbing>().holding(true);
			//gameObject.transform.parent = player.transform.Find("Bip001/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/Bip001 R Hand").transform;
			wep.transform.parent = hand.transform;
			wep.transform.localPosition = new Vector3(0,0,0);
			this.transform.localRotation = Quaternion.identity;
			//this.transform.localRotation = Quaternion.Euler(0, 0, -50);
			//gameObject.transform.parent.gameObject;
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "enemy"){

		}
	}
	public void unequip(int numnum){

		if(numnum == 1){
			wep = GameObject.Find("jnt_poker");
			wep.transform.parent = null;
			//wep.transform.parent = GameObject.Find("weaponPoker").transform;
		}
		if(numnum == 2){
			wep = GameObject.Find("jnt_bucket");
			wep.transform.parent = null;
			//wep.transform.parent = GameObject.Find("weaponBucket").transform;
		}
		if(numnum == 3){
			wep = GameObject.Find("jnt_knife");
			wep.transform.parent = null;

		}
		if(numnum == 4){
			wep = GameObject.Find("jnt_duster");
			wep.transform.parent = null;

		}

	}
	}