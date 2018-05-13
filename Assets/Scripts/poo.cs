// Poo Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poo : MonoBehaviour {

	public enemy enem;	// The enemy variable thing

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// If it's enemy is dead then this will be destroyed

		if(enem.dead == true) {
			Destroy(this.gameObject);
		}
		
	}
}
