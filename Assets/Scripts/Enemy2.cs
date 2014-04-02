﻿using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	
	public float x_speed = 20f;
	public float y_speed = 20f;
	public float health  = 10f;
	
	public bool alive = true;
	public bool has_shot = false;
	
	public GameObject player = null;
	public GameObject candy = null;
	public GameObject standard_candy = null;
	public GameObject GUIPrefab = null;
	public GameObject GUIDamage = null;
	
	public int drop_chance = 50;
	
	public MeshRenderer mesh_rend = null;
	public Material damaged = null;
	
	public float tp_timer;
	public float last_tp;
	public float shot_time;
	public Transform target;
	
	public GameObject bullet = null;
	public GameObject Circle = null;
	public GameObject spawner = null;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("playerChar");
		gameObject.tag = "enemy";
		
		mesh_rend = GetComponent<MeshRenderer>();
		damaged = new Material(Shader.Find("Diffuse"));
		damaged.color = new Color(1,0,0,.1f);
		
		tp_timer = 10f;
		last_tp = Time.time;
		shot_time = 5f;
		target = player.transform;
		
		bullet = Circle;
		spawner = GameObject.Find ("Terrain");
	}
	
	private void OnCollisionEnter(Collision c) 
	{
		if(c.gameObject.tag == "bullet") {
			/*//Debug.Log("Enemy Hit");
			GUIDamage = Instantiate(GUIPrefab,Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity) as GameObject;
			GUIDamage.guiText.text = "5";
			health -= 5;
			mesh_rend.material = damaged; */
		}
	}
	
	void Update () {
		this.transform.LookAt(target);
		if(Time.time - last_tp > tp_timer) {
			Teleport();
			last_tp = Time.time;
			has_shot = false;
		}
		if(Time.time - last_tp > shot_time && !has_shot) {
			Shoot();
			Debug.Log("shot");
			has_shot = true;
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
	
	void Teleport() {
		float x = Random.Range(-10,10) + player.transform.position.x;
		float y = player.transform.position.y;
		float z = Random.Range(-10,10) + player.transform.position.z;
		this.transform.position = new Vector3(x,y,z);
	}
	
	void Shoot() {
		GameObject shot = Instantiate (bullet, transform.position+transform.forward * 1.5f,transform.rotation) as GameObject;
		shot.gameObject.tag = "Enemy Bullet";
		shot.rigidbody.AddTorque(0,30,0);
		shot.GetComponent<Bullet>().setdis(50f,10f);
		shot.GetComponent<Bullet>().setdmg(1);
		shot.rigidbody.AddForce(transform.forward*250f);
	}

	void getHit(int dmg) {
		GUIDamage = Instantiate(GUIPrefab,Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity) as GameObject;
		GUIDamage.guiText.text = dmg.ToString();
		health -= dmg;
		mesh_rend.material = damaged;
	}
}