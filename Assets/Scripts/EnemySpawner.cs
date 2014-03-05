using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public float spawn_speed;
	public GameObject enemy = null;
	public GameObject enemy1 = null;
	public float start_time;
	public Vector3 spawn_loc;
	public GameObject player = null;

	// Use this for initialization
	void Start () {
		start_time = Time.time;
		spawn_speed = 10f;
		player = GameObject.Find("playerChar");
	}
	
	// Update is called once per frame
	void Update () {
		enemy = enemy1;
		if(Time.time - start_time > spawn_speed) {
			float x = Random.Range(-10,10) + player.transform.position.x;
			float y = player.transform.position.y;
			float z = Random.Range(-10,10) + player.transform.position.z;
			spawn_loc = new Vector3(x,y,z);
			start_time = Time.time;
			//Debug.Log("Enemy spawn");
			Instantiate(enemy, spawn_loc,transform.rotation);
		}
	
	}
}
