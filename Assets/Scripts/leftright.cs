// Left Right Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftright : MonoBehaviour {

	// The starting x position of the object
	private float startposx;

	// The speed the object will move at, edit it in the Inspector
	public float speed;

	// The width the object will travel before turning around, edit it in the Inspector
 	public float width;

 	//private Rigidbody2D rb;

	void Start () {
		// Setting the starting x position to it's current x position
    	startposx = transform.position.x;

    	// Getting the components
		//rb   = this.GetComponent<Rigidbody2D>();
	}

	void Update () {
		// If the object is going right and travels the width, it will turn around
		// If the object is going left and travels past it's intial starting x position, it will turn around
    	if ((speed > 0 && transform.position.x > startposx + width) || (speed < 0 && transform.position.x < startposx)) {

        	speed *= -1;
        }

        transform.Translate (new Vector3 (1.0f, 0.0f, 0.0f) * speed * Time.deltaTime);
        //rb.AddForce(transform.right * speed);
	}
}
