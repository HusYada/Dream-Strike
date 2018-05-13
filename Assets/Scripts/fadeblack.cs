// Fade Black Script for Dream Strike

// This script doesn't work for some reason, I really don't understand why

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeblack : MonoBehaviour {

	public bool fadein = false;
	public bool fadedin = false;
	public bool fadeout = false;
	public bool fadedout = true;
	private float red = 0f;
	private float gre = 0f;
	private float blu = 0f;
	public float alp = 0f;
	private SpriteRenderer sr;                          // The sprite renderer for the fadeout

	// Use this for initialization
	void Start () {
		sr   = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// The colour of the screen
		sr.color = new Color(red,gre,blu,alp);

		if(Input.GetKeyDown("o")) {
			fadein = true;
		}

		if(Input.GetKeyDown("p")) {
			fadeout = true;
		}

		if(fadein == true && alp <= 1f) {
			alp += 0.1f;
			fadedout = false;
		}

		if(fadeout == true && alp > -0.1f) {
			alp -= 0.1f;
			fadedin = false;
		}

		if(sr.color.a == 0f) {
			fadedout = true;
		}
		
		if(alp == 1f && fadein == true) {
			fadedin = true;
		}

		if(fadedout == true) {
			fadeout = false;
		}
		
		if(fadedin == true) {
			fadein = false;
		}
	}
}
