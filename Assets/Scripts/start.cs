using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	public AudioClip omg;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().PlayOneShot(omg, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

		bool xboxp1_start = Input.GetButtonDown("XBOXP1_START");

		if(Input.GetKeyDown("s")) {
			GetComponent<AudioSource>().PlayOneShot(omg, 0.5f);
		}

		// If the return key/Start button is pressed, the game will start
		if((Input.GetKeyDown(KeyCode.Return) || xboxp1_start == true)) {
            SceneManager.LoadScene("breezy_outskirts");
        }
	}
}
