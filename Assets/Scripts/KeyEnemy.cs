using UnityEngine;
using System.Collections;

// This enemy wil drop a key to open a door, allowing the player to move on more quickly
// This enemy will move erratically to increase difficulty of killing it
public class KeyEnemy : MonoBehaviour {

	float move_speed = 2f;		// Movement Speed
	float health = 10f; 		// Will take normal damage + 1
	float time_hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
