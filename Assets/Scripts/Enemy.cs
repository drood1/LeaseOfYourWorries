using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float move_speed = 2;
	public float health  = 10f;
	public float time_hit;
	public float move_again = 1.5F;
	
	public bool alive = true;
	public bool is_hit = false;
	
	public GameObject player = null;
	public GameObject candy = null;
	public GameObject standard_candy = null;
	public GameObject GUIPrefab = null;
	public GameObject GUIDamage = null;
	public GameObject spawner = null;
	
	public int drop_chance = 50;
	
	public MeshRenderer mesh_rend = null;
	public Material damaged = null;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("playerChar");
		gameObject.tag = "enemy";
		
		mesh_rend = GetComponent<MeshRenderer>();
		damaged = new Material(Shader.Find("Diffuse"));
		damaged.color = new Color(1,0,0,.1f);
		
		spawner = GameObject.Find ("Terrain");
		this.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
	}
	
	private void OnCollisionEnter(Collision c) 
	{
		if(c.gameObject.tag == "bullet") {
			this.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
			is_hit = true;
			time_hit = Time.time;
			GUIDamage = Instantiate(GUIPrefab,Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity) as GameObject;
			GUIDamage.guiText.text = "5";
			health -= 5;
			mesh_rend.material = damaged;
		}
		if(c.gameObject.tag == "Player") {
			this.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
			is_hit = true;
			time_hit = Time.time;
			
		}
	}
	
	void Update () {
		if(!is_hit) {
			Move();
		}
		else {
			if(Time.time - time_hit > move_again)
				is_hit = false;
		}
		
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
	}
	
	void Move() {
		//transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .05f);
		this.transform.LookAt(player.transform);
		this.transform.Translate(Vector3.forward * move_speed *Time.deltaTime);
	}
}
