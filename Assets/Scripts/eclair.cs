// Eclair Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eclair : MonoBehaviour {

    // A script variable to access variables from the abtscreen script
	public abtscreen abt;

	// The target the enemy is going to shoot at, edit it in the Inspector
    public Transform eclairpos;

	// The number of way points the enemy can go to, edit it in the Inspector
    public Transform[] waypoints;
    //public Transform[] alternatewaypoints;
    
    // The speed the enemy will go through the way point, edit it in the Inspector
    public float speed;

    //public bool usewaypoints;
    //public bool usealterrwaypoints;

    // Lastpoint of the waypoints
    public int firstpointpos;
    public int lastpointpos;
    
    // The current point the enemy passed through
    private int currentpoint;

	void Update() {

		// If the enemy isn't at a current way point, the enemy will move towards one by moving it's position with it's rigidbody
        if (transform.position != waypoints[currentpoint].position) {
            Vector2 pos = Vector2.MoveTowards(transform.position, waypoints[currentpoint].position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        
        // If there are no more points to go through, the enemy will make it's way back to the start of the graph and repeat
        else currentpoint = (currentpoint + 1) % waypoints.Length;

        // If the eclair reaches the end of it's route, it will start again at the first point
        if(eclairpos.transform.position == waypoints[firstpointpos].position) {
        	eclairpos.transform.position = waypoints[lastpointpos].position;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
    	// Checks if player touches the eclair, if so they will take damage
		if(col.gameObject.tag == "Plyr" && col.gameObject.GetComponent<player>().invincible == false) {
			if(abt.eqpdhealthbar == true) {
				col.gameObject.GetComponent<player>().currenthp -= 1;
				col.gameObject.GetComponent<player>().invincible = true;
			} else {
				col.gameObject.GetComponent<player>().currenthp -= 5;
				col.gameObject.GetComponent<player>().invincible = true;
			}
		}

		// Should kill enemies too
		if(col.gameObject.tag == "Enm" && col.gameObject.GetComponent<enemy>().invincible == false) {
			col.gameObject.GetComponent<enemy>().health -= 10;
			col.gameObject.GetComponent<enemy>().invincible = true;
		}
    }

    void OnTriggerStay2D(Collider2D col) {
    	// Checks if player touches the eclair, if so they will take damage
		if(col.gameObject.tag == "Plyr" && col.gameObject.GetComponent<player>().invincible == false) {			
			if(abt.eqpdhealthbar == true) {
				col.gameObject.GetComponent<player>().currenthp -= 1;
				col.gameObject.GetComponent<player>().invincible = true;
			} else {
				col.gameObject.GetComponent<player>().currenthp -= 5;
				col.gameObject.GetComponent<player>().invincible = true;
			}
		}

		// Should kill enemies too
		if(col.gameObject.tag == "Enm" && col.gameObject.GetComponent<enemy>().invincible == false) {
			col.gameObject.GetComponent<enemy>().health -= 10;
			col.gameObject.GetComponent<enemy>().invincible = true;
		}
    }
}
