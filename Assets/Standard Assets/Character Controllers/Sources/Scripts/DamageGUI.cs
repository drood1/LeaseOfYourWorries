using UnityEngine;
using System.Collections;

public class DamageGUI : MonoBehaviour {
	private float time;
	public int time_to_fade = 1;

	// Use this for initialization
	void Start () {
		//Debug.Log("DAMAGE GUI ON");
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.0F,0.001F,0.0F);
		//guiText.material.color.a = Mathf.Cos((Time.time - time)*((Mathf.PI/2)/time_to_fade));
		if(Time.time - time > time_to_fade) {
			//Debug.Log("DAMAGE GUI OFF");
			Destroy (gameObject);
		}
	}
}
