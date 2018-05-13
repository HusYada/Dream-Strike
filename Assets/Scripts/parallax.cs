// Parallax Script for Dream Strike

// Not using this as it does not follow the speed of the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {

	public float parallaxspeed;		// The speed of the parallax scroll, edit it in the Inspector
	public camera cam;				// A script variable to access variables from the player script
	
	void Update () {

		// If the camera is moving left, the background will scroll that way and vice versa
		if(cam.ismovingleft == true) {
			transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * parallaxspeed * -1 * Time.deltaTime);
		} else if(cam.ismovingright == true) {
			transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * parallaxspeed * Time.deltaTime);
		}
	}
}