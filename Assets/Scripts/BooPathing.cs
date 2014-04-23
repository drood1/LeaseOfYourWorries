using UnityEngine;
using System.Collections;

public class BooPathing : MonoBehaviour {
	public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
	public float patrolWaitTime = 1f;                       // The amount of time to wait when the patrol way point is reached.
	public Transform[] patrolWayPoints;                     // An array of transforms for the patrol route.
	
	public float walkSpeed  = 1f;
	
	private NavMeshAgent nav;                               // Reference to the nav mesh agent.
	private Transform player;                               // Reference to the player's transform.
	private float patrolTimer;                              // A timer for the patrolWaitTime.
	private int wayPointIndex;                              // A counter for the way point array.
	
	
	void Update()	{
		nav = GetComponent<NavMeshAgent>();
		nav.speed = patrolSpeed;
/*
		var player_object = GameObject.Find ("playerChar");
		var x = player_object.transform.position.x;
		var z = player_object.transform.position.z;

		//if player is in foyer
		if(x > 38 && x < 61 && z < 40.5){
			var Foyer_Points = GameObject.Find ("Foyer Patrol Points");

			patrolWayPoints[0] = Foyer_Points.gameObject("Point A").Transform;
			patrolWayPoints[1] = Foyer_Points.gameObject("Point B").Transform;
			patrolWayPoints[2] = Foyer_Points.gameObject("Point C").Transform;
			patrolWayPoints[3] = Foyer_Points.gameObject("Point D").Transform;
			print ("Foyer");
		}
		//if player is in bedroom
		if(x > 62 && z < 45){
			var Bedroom_Points = GameObject.Find ("Bedroom Patrol Points");

			patrolWayPoints[0] = A;
			patrolWayPoints[1] = B;
			patrolWayPoints[2] = C;
			patrolWayPoints[3] = D;
			print ("bedroom");
		}
		//if player is in bathroom
		if(x > 56 && z > 45){
			var Bathroom_Points = GameObject.Find ("Bathroom Patrol Points");

			patrolWayPoints[0] = A;
			patrolWayPoints[1] = B;
			patrolWayPoints[2] = C;
			patrolWayPoints[3] = D;
			print ("bathroom");
		}
		//if player is in kitchen
		if( x > 38 && x < 56 && z > 41){
			var Kitchen_Points = GameObject.Find ("Kitchen Patrol Points");

			patrolWayPoints[0] = A;
			patrolWayPoints[1] = B;
			patrolWayPoints[2] = C;
			patrolWayPoints[3] = D;
			print ("kitchen");
		}
		
		//if player is in dining hall
		if( x < 38)
		{
			var Dining_Points = GameObject.Find ("Dining Hall Patrol Points");

			patrolWayPoints[0] = A;
			patrolWayPoints[1] = B;
			patrolWayPoints[2] = C;
			patrolWayPoints[3] = D;
			print ("Dining Hall");
		}
*/
		Patrolling ();
	}
	public void Stop(){
		patrolSpeed = 0f;
	}
	public void Start(){
		patrolSpeed = 2f;
	}

	void Patrolling ()
	{
		// Set an appropriate speed for the NavMeshAgent.
		nav.speed = patrolSpeed;
		
		// If near the next waypoint or there is no destination...
		if(nav.remainingDistance < nav.stoppingDistance)
		{
			// ... increment the timer.
			patrolTimer += Time.deltaTime;
			
			// If the timer exceeds the wait time...
			if(patrolTimer >= patrolWaitTime)
			{
				
				//set wayPointIndex to a random point.
				wayPointIndex = Random.Range (0, 3);
				
				// Reset the timer.
				patrolTimer = 0;
			}
		}
		else
		{
			// If not near a destination, reset the timer.
			patrolTimer = 0;
			
		}
		
		// Set the destination to the patrolWayPoint.
		nav.destination = patrolWayPoints[wayPointIndex].position;
	}
}