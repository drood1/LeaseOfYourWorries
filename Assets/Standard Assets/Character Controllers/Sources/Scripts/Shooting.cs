using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public float bspeed = 3000f;
	public GameObject bullet = null;
	public GameObject bullettype1 = null;
	public GameObject bullettype2 = null;
	public bool melee = false;
	public float maxdis = 500f;
	public Bullet bull;
	float starttime = 0f;
	public float cdtime = 1f;
	void Start () {
		//starttime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		bullet = bullettype1;
		if(Input.GetMouseButtonDown(0)){
			if(Time.time-starttime >= cdtime){
				starttime = Time.time;
				GameObject shot = Instantiate (bullet, transform.position+transform.forward,transform.rotation) as GameObject;
				if(melee == false){
					shot.renderer.enabled = false;
				}
				shot.GetComponent<Bullet>().setdis(maxdis,bspeed);
				shot.rigidbody.AddForce(transform.forward*bspeed);
			}
		}
	}
}
