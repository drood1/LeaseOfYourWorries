using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float rotationDamping = 20f;
	public float runSpeed = 10f;
	public int gravity = 20;
	public float jumpSpeed = 8;
	private Animator anim;
	private HashIDs hash;

	bool canJump;
	float moveSpeed;
	float verticalVel;  // Used for continuing momentum while in air    
	CharacterController controller;
	void Awake(){
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag("Object").GetComponent<HashIDs>();
		anim.SetLayerWeight(1, 1f);
	}

	void Start()
	{
		controller = (CharacterController)GetComponent(typeof(CharacterController));
	}
	float UpdateMovement()
	{
		// Movement
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 inputVec = new Vector3(x, 0, z);
		inputVec *= runSpeed;
		float sumvalue = inputVec.x + inputVec.z;


		controller.Move((inputVec + Vector3.up * -gravity + new Vector3(0, verticalVel, 0)) * Time.deltaTime);


		// Rotation

		
		return inputVec.magnitude;
	}
	void Update()
	{
		// Check for jump
		if (controller.isGrounded )
		{
			canJump = true;
			if ( canJump && Input.GetKeyDown("space") )
			{
				// Apply the current movement to launch velocity
				verticalVel = jumpSpeed;
				canJump = false;
			}
		}else
		{           
			// Apply gravity to our velocity to diminish it over time
			verticalVel += Physics.gravity.y * Time.deltaTime;
		}
		
		// Actually move the character
		moveSpeed = UpdateMovement();  
		
		if ( controller.isGrounded )
			verticalVel = 0f;// Remove any persistent velocity after landing
		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))
			anim.SetBool(hash.move,true);
		else{
			anim.SetBool(hash.move,false);
			//anim.Play(hash.NMoving);
		}
	}
}

