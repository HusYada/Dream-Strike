using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		bool xboxp1_start = Input.GetButtonDown("XBOXP1_START");

		// If the return key/Start button is pressed, the game will start
		if((Input.GetKeyDown(KeyCode.Return) || xboxp1_start == true)) {
            SceneManager.LoadScene("level1");
        }
	}
}
