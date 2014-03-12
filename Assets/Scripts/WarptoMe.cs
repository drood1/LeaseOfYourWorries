using UnityEngine;
using System.Collections;

public class WarptoMe : MonoBehaviour {
	public GameObject player = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void Warp (){
		gameObject.GetComponent<BooPathing>().Stop();
		gameObject.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.LookAt(player.transform);
	}
}
