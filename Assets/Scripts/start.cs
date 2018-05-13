// Start Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	// Sound clip for tile screen
	public AudioClip omg;

	// Play sound at the title screen once
	void Start () {
		GetComponent<AudioSource>().PlayOneShot(omg, 0.5f);
	}
	
	void Update () {

		// A variable set to the Xbox 360/Xbox One controller's START button to see if it's been pressed
		bool xboxp1_start = Input.GetButtonDown("XBOXP1_START");

		// Press S for the sound effect again
		if(Input.GetKeyDown("s")) {
			GetComponent<AudioSource>().PlayOneShot(omg, 0.5f);
		}

		// If the return key/Start button is pressed, the game will start
		if((Input.GetKeyDown(KeyCode.Return) || xboxp1_start == true)) {
            SceneManager.LoadScene("breezy_outskirts");
        }
	}
}
