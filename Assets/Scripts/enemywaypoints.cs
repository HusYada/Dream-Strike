// Enemy Waypoints Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemywaypoints : MonoBehaviour {

    // The target the enemy is going to shoot at, edit it in the Inspector
    public Transform player;

	// The number of way points the enemy can go to, edit it in the Inspector
    public Transform[] waypoints;
    
    // The speed the enemy will go through the way point, edit it in the Inspector
    public float speed;
    
    // The current point the enemy passed through
    private int currentpoint;

    // The distance the enemy can see the player before attacking, edit it in the Inspector
    public float distance;

    // Checks if the player is in the range of the enemy
    private bool range = false;

	void Update() {

        // The range is set to be less than the distance
        range = Vector3.Distance (transform.position, player.position) < distance;

        if(range == true) {

		    // If the enemy isn't at a current way point, the enemy will move towards one by moving it's position with it's rigidbody
            if (transform.position != waypoints[currentpoint].position) {
           	    Vector2 pos = Vector2.MoveTowards(transform.position, waypoints[currentpoint].position, speed * Time.deltaTime);
           	    GetComponent<Rigidbody2D>().MovePosition(pos);
            }
        
            // If there are no more points to go through, the enemy will make it's way back to the start of the graph and repeat
            else currentpoint = (currentpoint + 1) % waypoints.Length;
        }
    }
}