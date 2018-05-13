// Reset Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class reset : MonoBehaviour {

	// Press R to go back to the title
	void Update() {
		if (Input.GetKey("r")) {
            SceneManager.LoadScene("start");
        }
	}
}
