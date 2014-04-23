using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	public int coneatk;
	public int catk;
	public int latk;
	public int ciratk;
	public int hatk;
	public int ratk;
	public int move;
	void Awake(){
		coneatk = Animator.StringToHash("Upperbody.Hold cone");
		catk = Animator.StringToHash("Attack");
		latk = Animator.StringToHash("Attack2");
		ciratk = Animator.StringToHash("Attack3");
		hatk = Animator.StringToHash("Attack4");
		ratk = Animator.StringToHash("Resetatk");
		move = Animator.StringToHash("Moving");
	}
}
