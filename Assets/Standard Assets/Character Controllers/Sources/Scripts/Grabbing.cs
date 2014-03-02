using UnityEngine;
using System.Collections;

public class Grabbing : MonoBehaviour {
	public GameObject Weapon = null;
	public bool holdingitem = false;
	GameObject hand;
	GameObject finger1;
	GameObject finger2;
	GameObject finger3;
	GameObject finger4;
	GameObject finger5;
	GameObject wep;
	// Use this for initialization
	void Start () {
		hand = GameObject.FindWithTag("Hand");
		finger1 = GameObject.FindWithTag("finger1");
		finger2 = GameObject.FindWithTag("finger2");
		finger3 = GameObject.FindWithTag("finger3");
		finger4 = GameObject.FindWithTag("finger4");
		finger5 = GameObject.FindWithTag("finger5");
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void holding(bool a){
		holdingitem = a;
	}
	public void Equip(int wepnum){
		Debug.Log(wepnum);
		if(holdingitem == false){
			holdingitem = true;
		}else{
			if(wepnum == 0){
				
			}else{
				hand.transform.DetachChildren();
				if(wepnum == 1){
					wep = GameObject.Find("weaponPoker/jnt_poker");
					wep.transform.parent = GameObject.Find("weaponPoker").transform;
					SphereCollider sphere = wep.GetComponent<SphereCollider>();
					sphere.enabled = true;
				}
				if(wepnum == 2){
					wep = GameObject.Find("weaponBucket/jnt_bucket");
					wep.transform.parent = GameObject.Find("weaponBucket").transform;
					SphereCollider sphere = wep.GetComponent<SphereCollider>();
					sphere.enabled = true;
				}
				wep.collider.enabled = true;
				finger1.transform.parent = hand.transform;
				finger2.transform.parent = hand.transform;
				finger3.transform.parent = hand.transform;
				finger4.transform.parent = hand.transform;
				finger5.transform.parent = hand.transform;
				//wep.transform.parent = null;
				}

		}
	}
}
