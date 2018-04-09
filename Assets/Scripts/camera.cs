// Camera Script for Dream Strike
// Reference - George Games, 12 Dec 2015. Metroidvania Camera Boundaries Unity Tutorial. [online video] Available at: https://www.youtube.com/watch?v=3qfbJ-JSrOc [Accessed at 30 September 2017].
// Helpful source for getting the camera set up

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class camera : MonoBehaviour {

	public Camera cam;
	private Transform player; 		  // The player's position
	private BoxCollider2D cameraview; // The camera's view box

	void Start () {
		// Getting components
		player = GameObject.FindGameObjectWithTag("Plyr").GetComponent<Transform>();
		cameraview = GetComponent<BoxCollider2D>();
	}
	
	void Update () {

		if(Input.GetKey("y")) {
			cam.orthographicSize++;
		}
		if(Input.GetKey("u")) {
			cam.orthographicSize--;
		}
		if(Input.GetKey("i")) {
			cam.orthographicSize = 6.0f;
		}
	
		// Setting the size of the camera view
		if(Camera.main.aspect >= (1.6f) && Camera.main.aspect < 1.7f){
			cameraview.size = new Vector2 (21.35f, 11.97f);
		}

		// If the camera is inside a boundary, the camera view will be locked inside it's box collider until the player moves outside of it
	   	// When that happens, the boundary will switch to the one the player is currently in
		if(GameObject.Find("Boundary")) {
			transform.position = new Vector3 (Mathf.Clamp (player.position.x, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraview.size.x / 2, 
																			  GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraview.size.x / 2),
											  Mathf.Clamp (player.position.y, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraview.size.y / 2, 
											  								  GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraview.size.y / 2),
											  transform.position.z);
		}
	}
}*/

public class camera : MonoBehaviour {

	public bool lockx;
	public bool locky;
	public float boundminx;
	public float boundmaxx;
	public float boundminy;
	public float boundmaxy;
	public float offsetx;
	public float offsety;
	public Camera cam;
	public player plyr;								// A script variable to access variables from the player script
	//private Transform plyr; 		  // The player's position

	void Start() {
		//plyr = GameObject.FindGameObjectWithTag("Plyr").GetComponent<Transform>();
	}

	void Update() {

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