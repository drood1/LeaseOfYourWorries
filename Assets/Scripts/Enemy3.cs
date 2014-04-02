using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour {
	public float health  = 10f;
	
	public bool alive = true;
	public bool invincible = true;
	public bool not_shot = true;
	public float i_timer = 3f;
	public float a_timer;
	
	public GameObject player = null;
	public GameObject candy = null;
	public GameObject standard_candy = null;
	public GameObject GUIPrefab = null;
	public GameObject GUIDamage = null;
	public GameObject spawner = null;
	
	public int drop_chance = 50;
	
	public MeshRenderer mesh_rend = null;
	public Material damaged = null;
	public Material normal = null;

	public GameObject bullet = null;
	public GameObject cone = null;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("playerChar");
		gameObject.tag = "enemy";
		
		mesh_rend = GetComponent<MeshRenderer>();
		normal = mesh_rend.material;
		damaged = new Material(Shader.Find("Diffuse"));
		damaged.color = new Color(1,0,0,.1f);

		bullet = cone;
		spawner = GameObject.Find ("Terrain");
	}
	
	private void OnCollisionEnter(Collision c) 
	{
		/*if(c.gameObject.tag == "bullet") {
			if(!invincible) {
				//Debug.Log("Enemy Hit");
				GUIDamage = Instantiate(GUIPrefab,Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity) as GameObject;
				GUIDamage.guiText.text = "5";
				health -= 5;
				mesh_rend.material = damaged;
			}
		}*/
	}
	
	void Update () {
		Move();
		
		if(health <= 0f) {
			Debug.Log("Enemy Killed");
			int chance = Random.Range(0,100);
			if(chance < drop_chance) {
				candy = standard_candy;
				Instantiate(candy, transform.position, transform.rotation);
			}
			spawner.SendMessage("increase_death_count");
			GameObject.Destroy (gameObject);
		}	

		if(!invincible) {
			if(Time.time - a_timer > i_timer) {
				invincible = true;
				mesh_rend.material = normal;
				not_shot = true;
			}
			if(Time.time - a_timer > i_timer-1 && not_shot) {
				shoot();
				not_shot = false;
			}
		}
	}
	
	void Move() {
		if(invincible) {
			this.transform.LookAt(player.transform);
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .05f);
		}
		float dist = Vector3.Distance(this.transform.position, player.transform.position);
		if(dist < 2f && invincible)
			Attack();
	}

	void Attack() {
		invincible = false;
		a_timer = Time.time;
		mesh_rend.material = damaged;

	}

	void shoot() {
		GameObject shot = Instantiate (bullet, transform.position+transform.forward * 1.5f,transform.rotation) as GameObject;
		shot.gameObject.tag = "Enemy Bullet";
		//shot.rigidbody.AddTorque(0,30,0);
		shot.GetComponent<Bullet>().setdis(10f,10f);
		shot.GetComponent<Bullet>().setdmg(2);
		shot.rigidbody.AddForce(transform.forward*20f);
	}

	void getHit(int dmg) {
		if(!invincible) {
			//Debug.Log("Enemy Hit");
			GUIDamage = Instantiate(GUIPrefab,Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity) as GameObject;
			GUIDamage.guiText.text = dmg.ToString();
			health -= dmg;
			mesh_rend.material = damaged;
		}
	}
}
