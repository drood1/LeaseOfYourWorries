using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	public int coneatk;
	public int catk;
	void Awake(){
		coneatk = Animator.StringToHash("Upperbody.Hold cone");
		catk = Animator.StringToHash("Attack");

	}
}
