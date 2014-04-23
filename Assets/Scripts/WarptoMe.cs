using UnityEngine;
using System.Collections;

public class WarptoMe : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}
	void Warp (){
		gameObject.GetComponent<BooPathing>().Stop();
		//gameObject.transform.position = player.transform.position;
		gameObject.transform.position = new Vector3(player.transform.position.x + 1f, gameObject.transform.position.y, player.transform.position.z + 1f);
		gameObject.transform.LookAt(player.transform);
	}
}
