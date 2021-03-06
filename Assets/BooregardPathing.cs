﻿using UnityEngine;
using System.Collections;

public class BooregardPathing : MonoBehaviour {
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
		Patrolling ();
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

				/*
				// ... increment the wayPointIndex.
				if(wayPointIndex == patrolWayPoints.Length - 1){
					wayPointIndex = 0;
				}
				else {
					wayPointIndex++;
				}
				*/

				//set wayPointIndex to a random point.
				wayPointIndex = Random.Range (0, 4);

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