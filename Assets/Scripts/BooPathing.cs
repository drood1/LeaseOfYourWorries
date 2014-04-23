using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		
		var player_object = GameObject.Find ("playerChar");
		var x = player_object.transform.position.x;
		var z = player_object.transform.position.z;
		
		//if player is in foyer
		if(x > 38 && x < 61 && z < 40.5){
			var Foyer_Points = GameObject.Find ("Foyer Patrol Points");
			
			patrolWayPoints[0] = Foyer_Points.transform.GetChild (0).transform;
			patrolWayPoints[1] = Foyer_Points.transform.GetChild (1).transform;
			patrolWayPoints[2] = Foyer_Points.transform.GetChild (2).transform;
			patrolWayPoints[3] = Foyer_Points.transform.GetChild (3).transform;
		}
		//if player is in bedroom
		if(x > 62 && z < 45){
			var Bedroom_Points = GameObject.Find ("Bedroom Patrol Points");
			
			patrolWayPoints[0] = Bedroom_Points.transform.GetChild (0).transform;
			patrolWayPoints[1] = Bedroom_Points.transform.GetChild (1).transform;
			patrolWayPoints[2] = Bedroom_Points.transform.GetChild (2).transform;
			patrolWayPoints[3] = Bedroom_Points.transform.GetChild (3).transform;
		}
		//if player is in bathroom
		if(x > 56 && z > 45){
			var Bathroom_Points = GameObject.Find ("Bathroom Patrol Points");
			
			patrolWayPoints[0] = Bathroom_Points.transform.GetChild (0).transform;
			patrolWayPoints[1] = Bathroom_Points.transform.GetChild (1).transform;
			patrolWayPoints[2] = Bathroom_Points.transform.GetChild (2).transform;
			patrolWayPoints[3] = Bathroom_Points.transform.GetChild (3).transform;
		}
		//if player is in kitchen
		if( x > 38 && x < 56 && z > 41){
			var Kitchen_Points = GameObject.Find ("Kitchen Patrol Points");
			
			patrolWayPoints[0] = Kitchen_Points.transform.GetChild (0).transform;
			patrolWayPoints[1] = Kitchen_Points.transform.GetChild (1).transform;
			patrolWayPoints[2] = Kitchen_Points.transform.GetChild (2).transform;
			patrolWayPoints[3] = Kitchen_Points.transform.GetChild (3).transform;
		}
		
		//if player is in dining hall
		if( x < 38)
		{
			var Dining_Points = GameObject.Find ("Dining Hall Patrol Points");
			
			patrolWayPoints[0] = Dining_Points.transform.GetChild (0).transform;
			patrolWayPoints[1] = Dining_Points.transform.GetChild (1).transform;
			patrolWayPoints[2] = Dining_Points.transform.GetChild (2).transform;
			patrolWayPoints[3] = Dining_Points.transform.GetChild (3).transform;
		}
		
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