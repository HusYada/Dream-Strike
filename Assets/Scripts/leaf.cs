// Leaf Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaf : MonoBehaviour {

    public GameObject platform;         // The platform that will spawn
    public GameObject target;           // The target destination for the leaf
    public bool cango = false;          // Checks if the leaf can go
    public bool makeplatform = false;   // Checks if the leaf made the platform
    private bool reached = false;       // Checks if the leaf reached it's target
    public float speed;                 // The speed the enemy will go through the way point, edit it in the Inspector

	void Update() {

        // If the leaft can go, it will travel to it's target
        if(cango == true) {
            Vector2 pos = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }

        // If the leaf reached it's target then it will make the platform and destroy itself
        if(reached == true) {
            if(makeplatform == true) {
                Transform.Instantiate(platform, transform.position, transform.rotation);
            }

            Destroy(this.gameObject);
        }
	}

    // If the leaf collides with the target, it has reached it 
    void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.gameObject == target) {
            reached = true;
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if(col.transform.gameObject == target) {
            reached = true;
        }
    }
}
