using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	public float bulletlife = .5f;
	float dis = 500f;
	float bspeed = 0;
	float starttime = 0f;
	public int dmg = 0;
	void Start()
	{
		starttime = Time.time;
	}
	private void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "enemy"){
			//Debug.Log("Hit enemy");
			c.gameObject.SendMessage("getHit", dmg);
			GameObject.Destroy (gameObject);
		}
		if(c.gameObject.tag == "Enemy Bullet"){
			GameObject.Destroy (gameObject);
		}
		if(c.gameObject.tag == "Player" && this.gameObject.tag != "bullet") {
			GameObject player = GameObject.Find("playerChar");
			player.SendMessage("getHit", dmg);
			GameObject.Destroy(gameObject);
		}
		if(c.gameObject.layer == 8)
		{
			GameObject.Destroy(gameObject);
		}
	}
	void Update () {
		//Debug.Log((Time.time-starttime)*bspeed);
		if((Time.time-starttime)*bspeed >= dis){
			GameObject.Destroy (gameObject);
		}

	}
	public void setdis(float a, float b){
		dis = a;
		bspeed = b;
	}
	public void setdmg(int a){
		dmg = a;
	}

}
