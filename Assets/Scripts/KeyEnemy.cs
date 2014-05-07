using UnityEngine;
using System.Collections;

// This enemy wil drop a key to open a door, allowing the player to move on more quickly
// This enemy will move erratically to increase difficulty of killing it
public class KeyEnemy : MonoBehaviour {

	float move_speed = 2f;		// Movement Speed
	float health = 10f; 		// Will take normal damage + 1
	float time_hit;
	public Transform[] waypoints;
	Transform target;
	int loc = 0;
	int drop_chance = 100;
	public GameObject candy = null;
	public GameObject standard_candy = null;
	public GameObject candy2 = null;
	public GameObject candy3 = null;
	float life_span;
	float life_start;

	// Use this for initialization
	void Start () {
		gameObject.tag = "enemy";
		target = waypoints[loc];
		Physics.IgnoreLayerCollision(8,9);
		life_span = Random.Range(50,100);
		life_start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - life_start > life_span) {
			GameObject.Destroy(gameObject);
		}

		target = waypoints[loc];
		this.transform.LookAt(target);
		this.transform.Translate(Vector3.forward * move_speed *Time.deltaTime);

		if(Vector3.Distance(this.transform.position, target.transform.position) < 1) {
			loc++;
			if(loc > waypoints.Length - 1) {
				loc = 0;
			}
		}

		if(animation.isPlaying)
			Debug.Log("Animation is Playing");
		else {
			Debug.Log ("Animation not playing");
			animation.Play();
		}
	}
	void getHit(int dmg) {
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
	}
}
