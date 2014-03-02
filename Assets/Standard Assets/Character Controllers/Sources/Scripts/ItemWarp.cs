using UnityEngine;
using System.Collections;

public class ItemWarp : MonoBehaviour {
	public GameObject player = null;
	GameObject hand;
	GameObject wep;
	public int wepnum = 0;
	// Use this for initialization
	void Start () {
		hand = GameObject.FindWithTag("Hand");
		if(wepnum == 1){
			wep = GameObject.Find("fireplacePoker/joint_poker");
		}
		if(wepnum == 2){
			wep = GameObject.Find("woodenBucket");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseOver (){
		if(Input.GetMouseButtonDown(1)){
			//gameObject.transform.parent = player.transform.Find("Bip001/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/Bip001 R Hand").transform;
			wep.transform.parent = hand.transform;
			wep.transform.localPosition = new Vector3(0,0,0);
			//this.transform.localRotation = Quaternion.identity;
			//this.transform.localRotation = Quaternion.Euler(0, 0, -50);
			//gameObject.transform.parent.gameObject;
		}

	}
}
