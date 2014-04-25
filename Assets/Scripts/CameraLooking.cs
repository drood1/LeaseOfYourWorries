using UnityEngine;
using System.Collections;

public class CameraLooking : MonoBehaviour {
	public float damping = 10;
	Vector3 offset;
	GameObject target = null;
	public int value;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player");
		offset = transform.position - target.transform.position;
	}
	
	void LateUpdate() {
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = target.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
		
		Quaternion rotation = Quaternion.Euler((-180) - (value), 0, 0);
		transform.position = target.transform.position - (rotation * offset);
		transform.LookAt(target.transform);
		
		//transform.LookAt(target.transform.position);
	}
}
