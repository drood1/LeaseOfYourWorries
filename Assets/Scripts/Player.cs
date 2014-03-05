using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health = 5;
	public bool invincible = false;
	public float timer;
	public int damage_time = 5;
	public Texture health1;
	public Texture health2;
	public Texture health3;
	public Texture health4;
	public Texture health5;
	public Texture health6;

	//public GameObject dmg_skin = null;

	Color dmg_color = new Color(255,255,0,.4F);

	SkinnedMeshRenderer dmg_skin = null;
	SkinnedMeshRenderer norm_skin = null;
	Material dmg_mat = null;
	Material norm_mat = null;

	// Use this for initialization
	void Start () {
		timer = Time.time;

		dmg_mat = new Material(Shader.Find("Diffuse"));
		dmg_mat.color = dmg_color;

		//dmg_skin = GetComponentInChildren<SkinnedMeshRenderer>();
		norm_skin = GetComponentInChildren<SkinnedMeshRenderer>();
		norm_mat = norm_skin.material;
		
	}
	
	// Update is called once per frame
	void Update () {
		float temp = Time.time - timer;

		if(invincible && temp > damage_time) {
			invincible = false;
			norm_skin.material = norm_mat;
			//Debug.Log("No more invincibility");
		}
		if(invincible) {
			flash(temp);
		}

	}

	private void flash(float temp) {
		if(temp < .5)
			norm_skin.material = dmg_mat;
		else if(temp > .5 && temp < 1)
			norm_skin.material = norm_mat;
		else if(temp > 1 && temp < 1.5)
			norm_skin.material = dmg_mat;
		else if(temp > 1.5 && temp < 2)
			norm_skin.material = norm_mat;
		else if(temp > 2 && temp < 2.5)
			norm_skin.material = dmg_mat;
		else if(temp > 2.5 && temp < 3)
			norm_skin.material = norm_mat;
		else if(temp > 3 && temp < 3.5)
			norm_skin.material = dmg_mat;
		else if(temp > 3.5 && temp < 4)
			norm_skin.material = norm_mat;
		else if(temp > 4 && temp < 4.5)
			norm_skin.material = dmg_mat;
	}

	private void OnCollisionEnter(Collision c) {
		Debug.Log("Player Collision");
		if(invincible == false) {
			if(c.gameObject.tag == "enemy") {
				//Debug.Log("YOU GOT HIT");
				health--;
				invincible = true;
				timer = Time.time;
			}
		}
	}

	void OnGUI() {
		//GUI.Label ( new Rect (10,Screen.height - 50,100,50), "Health: " + health);
		if (health == 5){
			GUI.DrawTexture(new Rect(10,0,Screen.width/4,50),health1);
		}
		if (health == 4){
			GUI.DrawTexture(new Rect(10,0,Screen.width/4,50),health2);
		}
		if (health == 3){
			GUI.DrawTexture(new Rect(10,0,Screen.width/4,50),health3);
		}
		if (health == 2){
			GUI.DrawTexture(new Rect(10,0,Screen.width/4,50),health4);
		}
		if (health == 1){
			GUI.DrawTexture(new Rect(10,0,Screen.width/4,50),health5);
		}
		if (health <= 0){
			GUI.DrawTexture(new Rect(10,0,Screen.width/4,50),health6);
		}
	}
}
