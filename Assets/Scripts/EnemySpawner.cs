using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	public float spawn_speed;			// Time inbetween enemy spawns
	public bool spawn_on;				// Wave system status. true = on, false = off
	public bool cooldown;				// Whether or not the game is between waves
	public bool new_wave;				// When set to true, new wave will start after cooldown_timer
	public float cooldown_timer;		// Actual time between waves
	public GameObject enemy = null;		// Enemy that will be spawned at each Instantiate. 
	// This object will change according to what enemy will be spawned
	
	public GameObject enemy1 = null;	// Basic enemy, follows player around
	public GameObject enemy2 = null;	// Basic enemy, can only be hurt before it attacks
	public GameObject enemy3 = null;	// Basic enemy, only moves when player isn't looking
	public GameObject enemy4 = null;	// Basic enemy, disappears when hit, reappears in random location
	public float start_time;			// Time that last enemy spawned
	public Vector3 spawn_loc;			// location of enemy spawn. Determined at time of spawn
	public GameObject player = null;	// Object to hold player's position and behavior.
	public Wave current_wave = null;	// Current Wave the game is on;
	public int place_in_wave;			// Which enemy will be spawned next
	public int death_count = 0;			// How many enemies in current wave killed
	
	public List<Wave> waves = new List<Wave>();	// Container for Waves
	public Wave one = new Wave(1,2,1);			
	public Wave two = new Wave(2,1,2);
	public Wave three = new Wave(3,1,3);
	public Wave four = new Wave(4,1,4);
	
	
	// Use this for initialization
	void Start () {
		start_time = Time.time;
		//spawn_speed = 10f;
		spawn_on = true;
		cooldown = false;
		new_wave = false;
		cooldown_timer = 5.0F;
		player = GameObject.Find("playerChar");
		
		waves.Add (one);
		waves.Add (two);
		waves.Add (three);
		waves.Add (four);
		current_wave = waves[0];
		spawn_speed = current_wave.spawn_speed;
		place_in_wave = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(spawn_on && !cooldown && !new_wave) {
			// Only spawns when a wave is active and not in cooldown or wave countdown mode
			if(Time.time - start_time > spawn_speed) {
				// Spawns an enemy every spawn_speed seconds until enemy container is empty
				ChangeEnemy();
				Instantiate(enemy, Make_Spawn_Loc(), transform.rotation);
				//Debug.Log ("Current Wave: " + current_wave.wave_name + " Count: " + place_in_wave);
				if(current_wave.spawn_list.Count - 1 == place_in_wave) {
					//Ends All Spawning at end of waves
					if(current_wave.wave_name == waves.Count) {
						spawn_on = false;
					}
					else {
						place_in_wave = 0;
						//current_wave = waves[current_wave.wave_name]; 
						//spawn_speed = current_wave.spawn_speed;
						//Debug.Log("Change Wave");
						cooldown = true;
						new_wave = true;
						start_time = Time.time;
					}
				}
				else {
					place_in_wave++;
				}
				start_time = Time.time;
				
			}
		}
		
		if(cooldown) {
			// count the number of deaths before starting new wave counter
			if(current_wave.spawn_list.Count == death_count) {
				cooldown = false;
				death_count = 0;
				current_wave = waves[current_wave.wave_name]; 
				spawn_speed = current_wave.spawn_speed;
				start_time = Time.time;
			}
		}
		if(!cooldown && new_wave) {
			// start new wave
			if(Time.time -  start_time > cooldown_timer) {
				start_time = Time.time;
				new_wave = false;
			}
		}
	}
	
	Vector3 Make_Spawn_Loc() {
		float x = Random.Range(-10,10) + player.transform.position.x;
		float y = player.transform.position.y;
		float z = Random.Range(-10,10) + player.transform.position.z;
		spawn_loc = new Vector3(x,y,z);
		return spawn_loc;
	}
	
	void ChangeEnemy() {
		if(current_wave.spawn_list[place_in_wave] == "Enemy1")
			enemy = enemy1;
		else if(current_wave.spawn_list[place_in_wave] == "Enemy2")
			enemy = enemy2;
		else if(current_wave.spawn_list[place_in_wave] == "Enemy3")
			enemy = enemy3;
	}
	
	void increase_death_count() {
		death_count++;
	}
	
}

public class Wave {
	public int wave_name;
	public int spawn_speed;
	public List<string> spawn_list;
	public List<List<string>> wave_list = new List<List<string>>();
	List<string> one = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
	};
	
	List<string> two = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
	};
	List<string> three = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy3",
	};
	List<string> four = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3"
	};
	
	
	public Wave(int name, int speed, int num) 
	{
		wave_list.Add (null);
		wave_list.Add (one);
		wave_list.Add (two);
		wave_list.Add (three);
		wave_list.Add (four);
		
		wave_name = name;
		spawn_speed = speed;
		spawn_list = wave_list[num];  
	}
}
