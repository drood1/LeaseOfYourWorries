using UnityEngine;
using System.Collections;

public class ItemWarp : MonoBehaviour {
	public GameObject player = null;
	GameObject hand;
	GameObject wep;
	public int wepnum = 0;
	int prewepnum = 0;
	Grabbing whatdo;
	// Use this for initialization
	void Start () {
		hand = GameObject.FindWithTag("Hand");
		if(wepnum == 1){
					wep = GameObject.Find("weaponPoker/jnt_poker");
		}
		if(wepnum == 2){
			wep = GameObject.Find("weaponBucket/jnt_bucket");
		}
		prewepnum = wepnum;

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseOver (){
		//if(whatdo.holdingitem == false){


			if(Input.GetMouseButtonDown(1)){
				
				player.SendMessage("Equip",prewepnum);
				wep.collider.enabled = false;
				//player.gameObject.GetComponent<Grabbing>().holding(true);
			//gameObject.transform.parent = player.transform.Find("Bip001/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/Bip001 R Hand").transform;
				wep.transform.parent = hand.transform;
				wep.transform.localPosition = new Vector3(0,0,0);
			//this.transform.localRotation = Quaternion.identity;
			//this.transform.localRotation = Quaternion.Euler(0, 0, -50);
			//gameObject.transform.parent.gameObject;
			}

		}
	}