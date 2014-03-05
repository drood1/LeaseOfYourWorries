using UnityEngine;
using System.Collections;

public class ItemWarp : MonoBehaviour {
	public GameObject player = null;
	GameObject hand;
	GameObject wep;
	public int wepnum = 0;

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
		collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseOver (){
		//if(whatdo.holdingitem == false){


		if(Input.GetMouseButtonDown(1)){
				
			player.SendMessage("Equip",wepnum);
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

	}
	}