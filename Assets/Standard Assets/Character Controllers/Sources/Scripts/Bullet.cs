using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	public float bulletlife = .5f;
	float dis = 500f;
	float bspeed = 0;
	float starttime = 0f;
	void Start()
	{
		starttime = Time.time;
	}
	private void OnCollisionEnter(Collision c){
		GameObject.Destroy (gameObject);
	}
	void Update () {
		//Debug.Log((Time.time-starttime)*bspeed);
		bulletlife -= Time.deltaTime;
		if(bulletlife <= 0){
			GameObject.Destroy (gameObject);
		}
		if((Time.time-starttime)*bspeed >= dis){
			GameObject.Destroy (gameObject);
		}

	}
	public void setdis(float a, float b){
		dis = a;
		bspeed = b;
	}

}
