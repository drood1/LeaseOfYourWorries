using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float x_speed = 20f;
	public float y_speed = 20f;
	public float health  = 10f;

	public bool alive = true;

	public GameObject player = null;
	public GameObject candy = null;
	public GameObject standard_candy = null;
	public GameObject GUIPrefab = null;
	public GameObject GUIDamage = null;

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
	}

	private void OnCollisionEnter(Collision c) 
	{
		if(c.gameObject.tag == "bullet") {
			Debug.Log("Enemy Hit");
			GUIDamage = Instantiate(GUIPrefab,Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity) as GameObject;
			GUIDamage.guiText.text = "5";
			health -= 5;
			mesh_rend.material = damaged;
		}
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
			GameObject.Destroy (gameObject);
		}	
	}

	void Move() {
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .05f);
	}
}
