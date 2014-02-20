using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public float bspeed = 3000f;
	public GameObject bullet = null;
	public bool melee = false;
	public float maxdis = 500f;
	public Bullet bull;
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){

			GameObject shot = Instantiate (bullet, transform.position+transform.forward,transform.rotation) as GameObject;
			if(melee == false){
				shot.renderer.enabled = false;
			}
			shot.GetComponent<Bullet>().setdis(maxdis,bspeed);
			shot.rigidbody.AddForce(transform.forward*bspeed);
		}
	}
}
