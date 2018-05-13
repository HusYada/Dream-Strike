// Camera Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public bool lockx;					// Checks if the camera can move on the x axis
	public bool locky;					// Checks if the camera can move on the y axis
	public float boundminx;				// The most left boundary for the camera
	public float boundmaxx;				// The most right boundary for the camera
	public float boundminy;				// The lower boundary for the camera
	public float boundmaxy;				// The upper boundary for the camera
	public float offsetx;				// The x axis offset for the camera
	public float offsety;				// The y axis offset for the camera
	public Camera cam;					// The camera to use
	public player plyr;					// A script variable to access variables from the player script
	public bool ismovingleft;			// Checks if the player is moving left
	public bool ismovingright;			// Checks if the player is moving right
	private Vector3 campos;				// The camera's position

	void Start() {
		
		// Setting the camera position
		campos = this.transform.position;
	}

	void Update() {

     	// Is moving left
     	if (campos.x > this.transform.position.x) {
         	ismovingleft = true;
     	} else {
     		ismovingleft = false;
     	}

     	// Is moving right
     	if (campos.x < this.transform.position.x) {
         	ismovingright = true;
     	} else {
     		ismovingright = false;
     	}

     	// The camera's x position should be the same as the gameObject
     	campos.x = this.transform.position.x;

		// If locked on an axis, the camera won't move along it
		if(lockx == false && locky == false) {
			transform.position = new Vector3(plyr.transform.position.x, plyr.transform.position.y, this.transform.position.z);
		}

		if(lockx == true && locky == true) {
			transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		}

		if(lockx == true && locky == false) {
			transform.position = new Vector3(this.transform.position.x, plyr.transform.position.y, this.transform.position.z);
		}

		if(lockx == false && locky == true) {
			transform.position = new Vector3(plyr.transform.position.x, this.transform.position.y, this.transform.position.z);
		}

		if(this.transform.position.x <= boundminx || this.transform.position.x >= boundmaxx) {
			lockx = true;
		}

		if(plyr.transform.position.x > boundminx && plyr.transform.position.x < boundmaxx) { 
			lockx = false;
		}

		if(this.transform.position.y <= boundminy || this.transform.position.y >= boundmaxy) {
			locky = true;
		}

		if(plyr.transform.position.y > boundminy && plyr.transform.position.y < boundmaxy) {
			locky = false;
		}

		// Hotkeys for zooming in or out the camera for debugging
		if(Input.GetKey("y")) {
			cam.orthographicSize++;
		}
		if(Input.GetKey("u")) {
			cam.orthographicSize--;
		}
		if(Input.GetKey("i")) {
			cam.orthographicSize = 6.0f;
		}
	}
}