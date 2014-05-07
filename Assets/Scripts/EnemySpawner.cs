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

	public GameObject ui = null;
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
	public Wave five = new Wave(5,1,5);
	public Wave six = new Wave(6,1,6);
	public Wave seven = new Wave(7,1,7);
	public Wave eight = new Wave(8,1,8);
	public Wave nine = new Wave(9,1,9);
	public Wave ten = new Wave(10,1,10);
	public Wave eleven = new Wave(11,1,11);
	public Wave twelve = new Wave(12,2,12);
	public Wave thirteen = new Wave(13,2,13);
	public Wave fourteen = new Wave(14,2,14);
	public Wave fifteen = new Wave(15,2,15);
	public Wave sixteen = new Wave(16,2,16);
	public Wave seventeen = new Wave(17,2,17);
	public Wave eighteen = new Wave(18,2,18);
	public Wave nineteen = new Wave(19,2,19);
	public Wave twenty = new Wave(20,2,20);
	public Wave twentyone = new Wave(21,2,21);
	public Wave twentytwo = new Wave(22,2,22);
	public Wave twentythree = new Wave(23,2,23);
	public Wave twentyfour = new Wave(24,2,24);
	public Wave twentyfive = new Wave(25,2,25);

	public GameObject door1 = null;
	public GameObject door2 = null;
	public GameObject door3 = null;
	public GameObject door4 = null;
	public GameObject door5 = null;

	GameObject Foyer = null;
	GameObject Dining_Hall = null;
	GameObject Kitchen = null;
	GameObject Bathroom = null;
	GameObject Bedroom = null;

	public Vector4 room_bounds;
	
	// Use this for initialization
	void Start () {
		start_time = Time.time;
		//spawn_speed = 10f;
		spawn_on = true;
		cooldown = false;
		new_wave = false;
		cooldown_timer = 8.0F;
		player = GameObject.Find("playerChar");
		
		waves.Add (one);
		waves.Add (two);
		waves.Add (three);
		waves.Add (four);
		waves.Add (five);
		waves.Add (six);
		waves.Add (seven);
		waves.Add (eight);
		waves.Add (nine);
		waves.Add (ten);
		waves.Add (eleven);
		waves.Add (twelve);
		waves.Add (thirteen);
		waves.Add (fourteen);
		waves.Add (fifteen);
		current_wave = waves[0];
		spawn_speed = current_wave.spawn_speed;
		place_in_wave = 0;

		ui = GameObject.Find ("Main Camera");
		door1 = GameObject.Find("Door1");
		door2 = GameObject.Find("Door2");
		door3 = GameObject.Find("Door3");
		door4 = GameObject.Find("Door4");
		door5 = GameObject.Find("Door5");

		Foyer = GameObject.Find("FoyerFloor");
		Dining_Hall = GameObject.Find ("Dining_Hall");
		Kitchen = GameObject.Find ("Kitchen");
		Bathroom = GameObject.Find("Bathroom");
		Bedroom = GameObject.Find ("Bedroom");

		room_bounds = WhereIsPlayer();
		player.SendMessage("updateBounds", room_bounds);
	}
	
	// Update is called once per frame
	void Update () {
		sendEnemyCount();

		if(spawn_on && !cooldown && !new_wave) {
			// Only spawns when a wave is active and not in cooldown or wave countdown mode
			if(Time.time - start_time > spawn_speed) {
				// Spawns an enemy every spawn_speed seconds until enemy container is empty
				ChangeEnemy();
				Instantiate(enemy, Make_Spawn_Loc(room_bounds), transform.rotation);
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
				OpenDoors();

				var player_object = GameObject.Find ("playerChar");
				TalkToBoo player_script = player_object.GetComponent<TalkToBoo>();
				player_script.DoorsOpen = true;
			}
		}
		if(!cooldown && new_wave) {
			//float timeLeft = cooldown_timer - (Time.time - start_time);
			//GUI.Label (new Rect(1110,80,89,112), "Next wave starts in " + timeLeft);
			// start new wave
			if(Time.time -  start_time > cooldown_timer) {
				room_bounds = WhereIsPlayer();
				start_time = Time.time;
				new_wave = false;
				CloseDoors();

				var player_object = GameObject.Find ("playerChar");
				TalkToBoo player_script = player_object.GetComponent<TalkToBoo>();
				player_script.DoorsOpen = false;

				int chance = Random.Range (0,10);
				if(chance < 4) {
					enemy = enemy4;
					Instantiate(enemy, Make_Spawn_Loc(room_bounds), transform.rotation);
				}
			}
		}
	}

	Vector4 WhereIsPlayer() {
		if(Foyer.renderer.bounds.min.x < player.transform.position.x 
		   && Foyer.renderer.bounds.max.x > player.transform.position.x
		   && Foyer.renderer.bounds.min.z < player.transform.position.z
		   && Foyer.renderer.bounds.max.z > player.transform.position.z) {

			return new Vector4(Foyer.renderer.bounds.min.x, Foyer.renderer.bounds.max.x, Foyer.renderer.bounds.min.z, Foyer.renderer.bounds.max.z);
		}
		else if(Dining_Hall.renderer.bounds.min.x < player.transform.position.x 
		        && Dining_Hall.renderer.bounds.max.x > player.transform.position.x
		        && Dining_Hall.renderer.bounds.min.z < player.transform.position.z
		        && Dining_Hall.renderer.bounds.max.z > player.transform.position.z) {
			
			return new Vector4(Dining_Hall.renderer.bounds.min.x, Dining_Hall.renderer.bounds.max.x, Dining_Hall.renderer.bounds.min.z, Dining_Hall.renderer.bounds.max.z);
		}
		else if(Kitchen.renderer.bounds.min.x < player.transform.position.x 
		        && Kitchen.renderer.bounds.max.x > player.transform.position.x
		        && Kitchen.renderer.bounds.min.z < player.transform.position.z
		        && Kitchen.renderer.bounds.max.z > player.transform.position.z) {
			
			return new Vector4(Kitchen.renderer.bounds.min.x, Kitchen.renderer.bounds.max.x, Kitchen.renderer.bounds.min.z, Kitchen.renderer.bounds.max.z);
		}	
		else if(Bathroom.renderer.bounds.min.x < player.transform.position.x 
		        && Bathroom.renderer.bounds.max.x > player.transform.position.x
		        && Bathroom.renderer.bounds.min.z < player.transform.position.z
		        && Bathroom.renderer.bounds.max.z > player.transform.position.z) {
			
			return new Vector4(Bathroom.renderer.bounds.min.x, Bathroom.renderer.bounds.max.x, Bathroom.renderer.bounds.min.z, Bathroom.renderer.bounds.max.z);
		}
		else if(Bedroom.renderer.bounds.min.x < player.transform.position.x 
		        && Bedroom.renderer.bounds.max.x > player.transform.position.x
		        && Bedroom.renderer.bounds.min.z < player.transform.position.z
		        && Bedroom.renderer.bounds.max.z > player.transform.position.z) {
			
			return new Vector4(Bedroom.renderer.bounds.min.x, Bedroom.renderer.bounds.max.x, Bedroom.renderer.bounds.min.z, Bedroom.renderer.bounds.max.z);
		}
		else {
			return new Vector4(0,0,0,0);
		}
	}

	Vector3 Make_Spawn_Loc(Vector4 bounds) {
		float x = Random.Range(bounds.x, bounds.y);
		float y = player.transform.position.y;
		float z = Random.Range(bounds.z, bounds.w);
		spawn_loc = new Vector3(x,y,z);

		var checkresult = Physics.OverlapSphere(spawn_loc, 1);
		if(checkresult.Length == 0) {
			return spawn_loc;
		}
		else {
			return Make_Spawn_Loc(bounds);
		}
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

	void OpenDoors() {
		door1.SendMessage("OpenDoor");
		door2.SendMessage("OpenDoor");
		door3.SendMessage("OpenDoor");
		door4.SendMessage("OpenDoor");
		door5.SendMessage("OpenDoor");
	}

	void CloseDoors() {
		door1.SendMessage("CloseDoor");
		door2.SendMessage("CloseDoor");
		door3.SendMessage("CloseDoor");
		door4.SendMessage("CloseDoor");
		door5.SendMessage("CloseDoor");
	}

	void sendEnemyCount() {
		int count = current_wave.spawn_list.Count - death_count;
		ui.SendMessage("DisplayEnemyCount", count);
		if(!cooldown && new_wave) {
			float timeLeft = cooldown_timer - (Time.time - start_time);
			ui.SendMessage("DisplayTimeToNextWave", timeLeft);
		}
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

	};
	
	List<string> two = new List<string>()
	{
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
	List<string> five = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2"
	};
	List<string> six = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy2"
	};
	List<string> seven = new List<string>()
	{
		"Enemy2",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy1",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> eight = new List<string>()
	{
		"Enemy2",
		"Enemy1",
		"Enemy2",
		"Enemy1",
		"Enemy2",
		"Enemy1",
		"Enemy3",
		"Enemy1",
		"Enemy3",
		"Enemy3"
	};
	List<string> nine = new List<string>()
	{
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> ten = new List<string>()
	{
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> eleven = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> twelve = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> thirteen = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> fourteen = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> fifteen = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> sixteen = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> seventeen = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> eighteen = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> nineteen = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> twenty = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> twentyone = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> twentytwo = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> twentythree = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> twentyfour = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
		"Enemy3",
		"Enemy3"
	};
	List<string> twentyfive = new List<string>()
	{
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy1",
		"Enemy2",
		"Enemy2",
		"Enemy2",
		"Enemy3",
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
		wave_list.Add (five);
		wave_list.Add (six);
		wave_list.Add (seven);
		wave_list.Add (eight);
		wave_list.Add (nine);
		wave_list.Add (ten);
		wave_list.Add (eleven);
		wave_list.Add (twelve);
		wave_list.Add (thirteen);
		wave_list.Add (fourteen);
		wave_list.Add (fifteen);
		wave_list.Add (sixteen);
		wave_list.Add (seventeen);
		wave_list.Add (eighteen);
		wave_list.Add (nineteen);
		wave_list.Add (twenty);
		wave_list.Add (twentyone);
		wave_list.Add (twentytwo);
		wave_list.Add (twentythree);
		wave_list.Add (twentyfour);
		wave_list.Add (twentyfive);

		wave_name = name;
		spawn_speed = speed;
		spawn_list = wave_list[num];  
	}
}
