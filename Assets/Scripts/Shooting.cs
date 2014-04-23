using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public float bspeed = 300f;
	private Animator anim;
	private HashIDs hash;

	public GameObject bullet = null;
	public GameObject Circle = null;
	public GameObject Cone = null;
	public GameObject Rectangles = null;
	public GameObject Sphere = null;
	public GameObject bullettype2 = null;
	public bool melee = false;
	public float maxdis = 10f;
	public Bullet bull;
	float starttime = -1000f;
	public float cdtime = 1f;
	int buldmg = 0;
	int bultype = 1;
	void Start () {
		//starttime = Time.time;
		
	}
	
	// Update is called once per frame
	void Awake(){
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag("Object").GetComponent<HashIDs>();
		anim.SetLayerWeight(1, 1f);
	}
	void Update () {
		if(bultype == 1){
			bullet = Circle;
		}else if(bultype == 2){
			bullet = Cone;
		}else if(bultype == 3){
			bullet = Rectangles;
		}else if(bultype == 4){
			bullet = Sphere;
		}else if(bultype == 5){
			bullet = bullettype2;//custom bullet for knife
		}
		Animatormang(bultype);
		if(Input.GetMouseButtonDown(0)){
			if(Time.time >= starttime){


				starttime = Time.time + cdtime;
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
	void Animatormang(int bultype){
		if(bultype == 2){
			anim.SetBool(hash.catk,true);
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
