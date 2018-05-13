// Health Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

	public player plyr;				// A script variable to access variables from the player script
	public abtscreen abt;			// A script variable to access variables from the abtscreen script
	public Texture2D healthbar5;	// Texture for the health bar when the current HP = 5
	public Texture2D healthbar4;	// Texture for the health bar when the current HP = 4
	public Texture2D healthbar3;	// Texture for the health bar when the current HP = 3
	public Texture2D healthbar2;	// Texture for the health bar when the current HP = 2
	public Texture2D healthbar1;	// Texture for the health bar when the current HP = 1

	void OnGUI() {

		// If the "Health Bar" ability is equipped, you can see your health bar on the HUD and it's various states depending on how much health the player has
		if(abt.eqpdhealthbar == true) {

			if(plyr.currenthp == 5) {
				GUI.DrawTexture(new Rect(Screen.width/100f, Screen.height/1.2f, Screen.width/4f, Screen.height/6f), healthbar5, ScaleMode.ScaleToFit);
			}

			if(plyr.currenthp == 4) {
				GUI.DrawTexture(new Rect(Screen.width/100f, Screen.height/1.2f, Screen.width/4f, Screen.height/6f), healthbar4, ScaleMode.ScaleToFit);
			}

			if(plyr.currenthp == 3) {
				GUI.DrawTexture(new Rect(Screen.width/100f, Screen.height/1.2f, Screen.width/4f, Screen.height/6f), healthbar3, ScaleMode.ScaleToFit);
			}

			if(plyr.currenthp == 2) {
				GUI.DrawTexture(new Rect(Screen.width/100f, Screen.height/1.2f, Screen.width/4f, Screen.height/6f), healthbar2, ScaleMode.ScaleToFit);
			}

			if(plyr.currenthp == 1) {
				GUI.DrawTexture(new Rect(Screen.width/100f, Screen.height/1.2f, Screen.width/4f, Screen.height/6f), healthbar1, ScaleMode.ScaleToFit);
			}

			GUI.Label(new Rect(Screen.width/40f, Screen.height/1.11f, Screen.width/4f, Screen.height/8f), plyr.currenthp.ToString() + "/" + plyr.hpmax.ToString(), plyr.hud_fontoffsettl);
			GUI.Label(new Rect(Screen.width/40f, Screen.height/1.11f, Screen.width/4f, Screen.height/8f), plyr.currenthp.ToString() + "/" + plyr.hpmax.ToString(), plyr.hud_fontoffsettr);
			GUI.Label(new Rect(Screen.width/40f, Screen.height/1.11f, Screen.width/4f, Screen.height/8f), plyr.currenthp.ToString() + "/" + plyr.hpmax.ToString(), plyr.hud_fontoffsetbl);
			GUI.Label(new Rect(Screen.width/40f, Screen.height/1.11f, Screen.width/4f, Screen.height/8f), plyr.currenthp.ToString() + "/" + plyr.hpmax.ToString(), plyr.hud_fontoffsetbr);
			GUI.Label(new Rect(Screen.width/40f, Screen.height/1.11f, Screen.width/4f, Screen.height/8f), plyr.currenthp.ToString() + "/" + plyr.hpmax.ToString(), plyr.hud_font);
		}
	}
}
