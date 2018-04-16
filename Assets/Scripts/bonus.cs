using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour {

	public player plyr;
	public Vector3 gohere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		plyr.transform.position = gohere;
	}
}
