using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float move_speed = .5f;
	public float health  = 10f;
	public float time_hit;
	public float move_again = 1.5F;
	
	public bool alive = true;
	public bool is_hit = false;
	
	public GameObject player = null;
	public GameObject candy = null;
	public GameObject standard_candy = null;
	public GameObject candy2 = null;
	public GameObject candy3 = null;
	public GameObject GUIPrefab = null;
	public GameObject GUIDamage = null;
	public GameObject spawner = null;
	
	public int drop_chance = 50;
	
	public SkinnedMeshRenderer mesh_rend = null;
	public Material damaged = null;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("playerChar");
		gameObject.tag = "enemy";
		
		mesh_rend = GetComponentInChildren<SkinnedMeshRenderer>();
		damaged = new Material(Shader.Find("Diffuse"));
		damaged.color = new Color(1,0,0,.1f);
		
		spawner = GameObject.Find ("Terrain");
		this.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
		Physics.IgnoreLayerCollision(8,9);
		animation.Play();
	}
	
	private void OnCollisionEnter(Collision c) 
	{
		//if(c.gameObject.tag == "bullet") {
		//}
		if(c.gameObject.tag == "Player") {
			this.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
			this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			is_hit = true;
			time_hit = Time.time;
			
		}

		if(c.gameObject.tag == "enemy") {
			//Debug.Log("Enemy collides with enemy");
		}
	}
	
	void Update () {
		if(animation.isPlaying)
			Debug.Log("Animation is Playing");
		else {
			Debug.Log ("Animation not playing");
			animation.Play();
		}
		if(!is_hit) {
			Move();
		}
		else {
			if(Time.time - time_hit > move_again)
				is_hit = false;
		}
		
		if(health <= 0f) {
			//Debug.Log("Enemy Killed");
			/*
			int chance = Random.Range(0,100);
			if(chance < drop_chance) {
				candy = standard_candy;
				Instantiate(candy, transform.position, transform.rotation);
			}
			*/
			spawner.SendMessage("increase_death_count");
			GameObject yay = GameObject.FindWithTag("MainCamera");
			yay.SendMessage("AdjustCurrentRep",5);
			GameObject.Destroy (gameObject);
		}	
	}
	
	void Move() {
		//transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .05f);
		this.transform.LookAt(player.transform);
		this.transform.Translate(Vector3.forward * move_speed *Time.deltaTime);
	}

	void getHit(int dmg) {
		animation.Play ("Stun");
		int chance = Random.Range(0,100);
		if(chance < drop_chance) {
			chance = Random.Range (1,10);
			if(chance < 6) {
				candy = standard_candy;
				candy = Instantiate(candy, transform.position, transform.rotation) as GameObject;
				candy.SendMessageUpwards("setVal", 1);
			}
			else if(chance > 6 && chance < 10) {
				candy = candy2;
				candy = Instantiate(candy, transform.position, transform.rotation) as GameObject;
				candy.SendMessageUpwards("setVal", 2);
			}
			else if(chance == 10) {
				candy = candy3;
				candy = Instantiate(candy, transform.position, transform.rotation) as GameObject;
				candy.SendMessageUpwards("setVal", 3);
			}
		}
		this.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
		is_hit = true;
		time_hit = Time.time;
		GUIDamage = Instantiate(GUIPrefab,Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity) as GameObject;
		GUIDamage.guiText.text = dmg.ToString();
		health -= dmg;
		mesh_rend.material = damaged;
	}
}
