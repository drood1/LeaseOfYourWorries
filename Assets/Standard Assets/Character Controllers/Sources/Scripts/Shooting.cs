using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public float bspeed = 3000f;
	public GameObject bullet = null;
	public GameObject bullettype1 = null;
	public GameObject bullettype2 = null;
	public bool melee = false;
	public float maxdis = 10f;
	public Bullet bull;
	float starttime = -1000f;
	public float cdtime = 1f;
	int buldmg = 0;
	int bultype = 0;
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
				if(melee == true){
					shot.renderer.enabled = false;
				}
				shot.GetComponent<Bullet>().setdis(maxdis,bspeed);
				shot.GetComponent<Bullet>().setdmg(buldmg);
				shot.rigidbody.AddForce(transform.forward*bspeed);
			}
		}
	}
	public void stat(int[] arraystats,float timer,float range, bool type){
		buldmg = arraystats[0];
		bultype = arraystats[1];
		maxdis = range;
		cdtime = timer;
		melee = type;
	}

}
