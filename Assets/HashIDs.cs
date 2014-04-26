using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	public int coneatk;
	public int catk;
	public int latk;
	public int ciratk;
	public int tatk;
	public int ratk;
	public int move;
	public int Moving;
	public int NMoving;
	void Awake(){
		coneatk = Animator.StringToHash("Upperbody.Hold cone");
		Moving = Animator.StringToHash("LowerBody.Run");
		NMoving = Animator.StringToHash("LowerBody.Idle");
		catk = Animator.StringToHash("Attack");
		latk = Animator.StringToHash("Attack2");
		ciratk = Animator.StringToHash("Attack3");
		tatk = Animator.StringToHash("Attack4");
		ratk = Animator.StringToHash("Resetatk");
		move = Animator.StringToHash("Moving");
	}
}
