using UnityEngine;
using System.Collections;

public class Grabbing : MonoBehaviour {
	public GameObject Weapon = null;
	public bool holdingitem = false;
	GameObject hand;
	int prewepnum = 0;
	GameObject wep;
	// Use this for initialization
	void Start () {
		hand = GameObject.FindWithTag("Hand");
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void holding(bool a){
		holdingitem = a;
	}
	public void Equip(int wepnum){
		if(holdingitem == false){
			holdingitem = true;
			prewepnum = wepnum;
		}else{

				//hand.transform.DetachChildren();
			if(prewepnum == 1){
				wep = GameObject.Find("jnt_poker");
			}
			if(prewepnum == 2){
				wep = GameObject.Find("jnt_bucket");
			}
			wep.SendMessage("unequip",prewepnum);
			prewepnum = wepnum;
				//wep.transform.parent = null;
			}

		}
}
