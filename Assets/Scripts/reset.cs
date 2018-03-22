using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		if (Input.GetKey("r")) {
            SceneManager.LoadScene("start");
        }
	}
}
