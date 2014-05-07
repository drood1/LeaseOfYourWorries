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
	public GameObject bullettype1 = null;
	public GameObject bullettype2 = null;
	public GameObject bullettype3 = null;
	public bool melee = false;
	public float maxdis = 10f;
	public Bullet bull;
	float starttime = -1000f;
	public float cdtime = 1f;
	public float offsettime = -100f;
	int buldmg = 0;
	int bultype = 0;
	void Start () {
		//starttime = Time.time;
		anim.SetBool(hash.ratk,false);
		Vector3 temp = bullettype3.transform.eulerAngles;
		temp.y = 180;
		bullettype3.transform.rotation = Quaternion.Euler(temp);
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
			bullet = bullettype2;//custom bullet for knife
		}else if(bultype == 5){
			bullet = bullettype1;//custom bullet for knife
		}else if(bultype == 6){
			bullet = bullettype3;//custom bullet for knife


		}


		if(Input.GetMouseButtonDown(0) && bultype != 0 && Time.time >= offsettime){
			if(Time.time >= starttime){
			
				Animatormang(bultype);
				offsettime = Time.time + .41f;
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
		if(Time.time >= offsettime){
			//anim.SetBool(hash.ratk,false);
			anim.SetBool(hash.ciratk,false);
			anim.SetBool(hash.catk,false);
			anim.SetBool(hash.latk,false);
			anim.SetBool(hash.tatk,false);
		}

	}
	void LateUpdate(){

	}

	void AnimatorHold(int bultype){
		if(bultype == 1){
			anim.Play("Hold circle");
		}
		if(bultype == 2){
			anim.Play("Hold cone");
		}
		if(bultype == 3){
			anim.Play("Hold line");
		}
		if(bultype == 4){
			anim.Play("Hold throw");
		}
		if(bultype == 5){
			anim.Play("Hold cone");
		}
		if(bultype == 6){
			anim.Play("Hold throw");
		}

	}
	void Animatormang(int bultype){

		if(bultype == 1){

			anim.SetBool(hash.ciratk,true);
		}
		if(bultype == 2){

			anim.SetBool(hash.catk,true);
		}
		if(bultype == 3){

			anim.SetBool(hash.latk,true);
		}
		if(bultype == 4){

			anim.SetBool(hash.tatk,true);
		}
		if(bultype == 5){
			//anim.Play("Hold cone");
		}
		if(bultype == 6){
			anim.SetBool(hash.tatk,true);
		}
		//anim.SetBool(hash.ratk,true);
	}
	public void stat(int[] arraystats,float timer,float range, bool type){
		buldmg = arraystats[0];
		bultype = arraystats[1];
		maxdis = range;
		cdtime = timer;
		melee = type;
		AnimatorHold(bultype);
	}

}
