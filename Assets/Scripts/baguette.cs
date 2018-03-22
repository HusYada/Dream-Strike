using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baguette : MonoBehaviour {

	// The starting y position of the enemy
	private float startposy;

	// The speed the enemy will move at, edit it in the Inspector
	public float speed;

	// The height the enemy will travel before turning around, edit it in the Inspector
 	public float height;

	void Start () {
		// Setting the starting y position to it's current y position
    	startposy = transform.position.y;
	}

	void Update () {
		// If the enemy is going right and travels the height, it will turn around
		// If the enemy is going left and travels past it's intial starting x position, it will turn around
    	if ((speed > 0 && transform.position.y > startposy + height) || (speed < 0 && transform.position.y < startposy)) {

        	speed *= -1;
        }

        transform.Translate (new Vector3 (0.0f, 1.0f, 0.0f) * speed * Time.deltaTime);
        //rb.AddForce()
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Enm") {
			col.gameObject.GetComponent<enemy>().health -= 100;
		}
	}
}
