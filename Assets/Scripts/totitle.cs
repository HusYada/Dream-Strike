// To Title Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class totitle : MonoBehaviour {

	// Touch this to go back to the title screen
	void OnTriggerEnter2D (Collider2D col) {
		if(col.gameObject.tag == "Plyr") {
			SceneManager.LoadScene("start");
		}
	}
}
