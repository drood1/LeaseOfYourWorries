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
	public Texture gameover;
	public GUISkin playagain = null;
	public Vector4 room_bounds;
	
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
			//Debug.Log("Invincible");
			flash(temp);
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
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
	
	private void OnControllerColliderHit(ControllerColliderHit c) {
		//Debug.Log("Player Collision");
		if(invincible == false) {
			if(c.gameObject.tag == "enemy") {
				//Debug.Log("Player Collision");
				//Debug.Log("YOU GOT HIT");
				getHit(1);
				Vector3 target = c.gameObject.transform.position;
				Vector3 current = this.transform.position;

				target.y = 0;
				current.y = 0;

				//Vector3 heading = target - current;
				//this.transform.Translate (heading * 2);
			}
		}
	} 
	
	private void OnCollisionEnter(Collision c) {
		//Debug.Log("Player Collision");
		if(invincible == false) {
			if(c.gameObject.tag == "enemy") {
				//Debug.Log("Player Collision");
				//Debug.Log("YOU GOT HIT");
				getHit(1);
				Vector3 target = c.gameObject.transform.position;
				Vector3 current = this.transform.position;
				
				target.y = 0;
				current.y = 0;
				
				//Vector3 heading = target - current;
				//this.transform.Translate (heading * 2);
			}
		}
	} 
	
	void OnGUI() {
		//GUI.Label ( new Rect (10,Screen.height - 50,100,50), "Health: " + health);
		if (health == 5){
			GUI.DrawTexture(new Rect(8,10,413,88),health1);
		}
		if (health == 4){
			GUI.DrawTexture(new Rect(8,10,413,88),health2);
		}
		if (health == 3){
			GUI.DrawTexture(new Rect(8,10,413,88),health3);
		}
		if (health == 2){
			GUI.DrawTexture(new Rect(8,10,413,88),health4);
		}
		if (health == 1){
			GUI.DrawTexture(new Rect(8,10,413,88),health5);
		}
		if (health <= 0){
			GUI.DrawTexture(new Rect(8,10,413,88),health6);
			GUI.DrawTexture(new Rect(Screen.width/2 - (722/2),200,722,319),gameover);
			GameObject a = GameObject.FindGameObjectWithTag("Player");
			a.GetComponent<PlayerMovement>().enabled = false;
			GUI.skin = playagain;
			if(GUI.Button(new Rect(Screen.width/2 - (300/2),400,300,100),"")){
				Application.LoadLevel("splash");
			}
		}
	}

	void getHit(int dmg) {
		if(invincible == false) {
			health -= dmg;
			invincible = true;
			timer = Time.time;
		}
	}


	void updateBounds(Vector4 bounds) {
		room_bounds = bounds;
	}
}
