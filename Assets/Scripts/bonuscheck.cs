// Bonus Check Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonuscheck : MonoBehaviour {

	// Do you like if statements?

	public player plyr;			// A script variable to access variables from the player script
	public abtscreen abt;		// A script variable to access variables from the abtscreen script
	public bonus bns;			// A script variable to access variables from the bonus script

	// Checks DP of the player
	public float olddp = 0f;
	public float olddpmax = 0f;
	public float olddp2 = 0f;
	public float olddpmax2 = 0f;
	public float changedp;
	public float changedpmax;

	// Did you have the ability?
	public bool hadwalkleft = true;
    public bool hadwalkright = true;
    public bool hadjump = true;
    public bool hadattack = true;
    public bool hadhealthbar = true;
    public bool hadwallet = true;
    public bool hadpause = true;
	public bool hadcyberslam;
    public bool hadpeashoot;
    public bool hadmayonaise;
    public bool hadsoap;
    public bool hadgoodgrip;
    public bool hadrollerskates;

    // Was that ability equipped?
    public bool eqpddwalkleft = true;
    public bool eqpddwalkright = true;
    public bool eqpddjump = true;
    public bool eqpddattack = true;
    public bool eqpddhealthbar = true;
    public bool eqpddwallet = true;
	public bool eqpddpause = true;
    public bool eqpddcyberslam;
    public bool eqpddpeashoot;
    public bool eqpddmayonaise;
    public bool eqpddsoap;
    public bool eqpddgoodgrip;
    public bool eqpddrollerskates;

    // Bonus bois
    public bool bonuswalkleft;
    public bool bonuswalkright;
    public bool bonusjump;
    public bool bonusattack;
    public bool bonushealthbar;
    public bool bonuswallet;
	public bool bonuspause;
    public bool bonuscyberslam;
    public bool bonuspeashoot;
    public bool bonusmayonaise;
    public bool bonussoap;
    public bool bonusgoodgrip;
    public bool bonusrollerskates;

	
	void Update () {

		// If the player touches a hot dog stand, there DP is recorded
		if(bns.gohere == plyr.transform.position) {
			olddp = plyr.apcurrent;
			olddpmax = plyr.apmax;
		}

		// Checks what the player has
		if(abt.haswalkleft == true) {
			hadwalkleft = true;
		}

		if(abt.haswalkright == true) {
			hadwalkright = true;
		}

		if(abt.hasjump == true) {
			hadjump = true;
		}

		if(abt.hasattack == true) {
			hadattack = true;
		}

		if(abt.hashealthbar == true) {
			hadhealthbar = true;
		}

		if(abt.haswallet == true) {
			hadwallet = true;
		}

		if(abt.haspause == true) {
			hadpause = true;
		}

		if(abt.hascyberslam == true) {
			hadcyberslam = true;
		}

		if(abt.haspeashoot == true) {
			hadpeashoot = true;
		}

		if(abt.hasmayonaise == true) {
			hadmayonaise = true;
		}

		if(abt.hassoap == true) {
			hadsoap = true;
		}

		if(abt.hasgoodgrip == true) {
			hadgoodgrip = true;
		}

		if(abt.hasrollerskates == true) {
			hadrollerskates = true;
		}

		// Checks what the player equipped
		if(abt.eqpdwalkleft == true) {
			eqpddwalkleft = true;
		}
		
		if(abt.eqpdwalkright == true) {
			eqpddwalkright = true;
		}

		if(abt.eqpdjump == true) {
			eqpddjump = true;
		}

		if(abt.eqpdattack == true) {
			eqpddattack = true;
		}

		if(abt.eqpdhealthbar == true) {
			eqpddhealthbar = true;
		}

		if(abt.eqpdwallet == true) {
			eqpddwallet = true;
		}

		if(abt.eqpdpause == true) {
			eqpddpause = true;
		}

		if(abt.eqpdcyberslam == true) {
			eqpddcyberslam = true;
		}

		if(abt.eqpdpeashoot == true) {
			eqpddpeashoot = true;
		}

		if(abt.eqpdmayonaise == true) {
			eqpddmayonaise = true;
		}

		if(abt.eqpdsoap == true) {
			eqpddsoap = true;
		}

		if(abt.eqpdgoodgrip == true) {
			eqpddgoodgrip = true;
		}

		if(abt.eqpdrollerskates == true) {
			eqpddrollerskates = true;
		}

		// If the player is in a bonus, their DP and ability loadout is changed for the bonus
		if(plyr.isbonus == true && plyr.bonuscomplete == false) {

			if(olddp == plyr.apcurrent || olddpmax == plyr.apmax) {
				plyr.apcurrent = changedp;
				plyr.apmax = changedpmax;
				olddp2 = olddp;
				olddpmax2 = olddpmax;
			}

			// Change dp accordingly
			//plyr.apcurrent = changedp;
			//plyr.apmax = changedpmax;


	// Did you have that? Not anymore, unless it's in the bonus stage
		if(abt.haswalkleft == true && bonuswalkleft == false) {
			abt.haswalkleft = false;
			hadwalkleft = true;
		}

		if(abt.haswalkright == true && bonuswalkright == false) {
			abt.haswalkright = false;
			hadwalkright = true;
		}

		if(abt.hasjump == true && bonusjump == false) {
			abt.hasjump = false;
			hadjump = true;
		}

		if(abt.hasattack == true && bonusattack == false) {
			abt.hasattack = false;
			hadattack = true;
		}

		if(abt.hashealthbar == true && bonushealthbar == false) {
			abt.hashealthbar = false;
			hadhealthbar = true;
		}

		if(abt.haswallet == true && bonuswallet == false) {
			abt.haswallet = false;
			hadwallet = true;
		}

		if(abt.haspause == true && bonuspause == false) {
			abt.haspause = false;
			hadpause = true;
		}

		if(abt.hascyberslam == true && bonuscyberslam == false) {
			abt.hascyberslam = false;
			hadcyberslam = true;
		}

		if(abt.haspeashoot == true && bonuspeashoot == false) {
			abt.haspeashoot = false;
			hadpeashoot = true;
		}

		if(abt.hasmayonaise == true && bonusmayonaise == false) {
			abt.hasmayonaise = false;
			hadmayonaise = true;
		}

		if(abt.hassoap == true && bonussoap == false) {
			abt.hassoap = false;
			hadsoap = true;
		}

		if(abt.hasgoodgrip == true && bonusgoodgrip == false) {
			abt.hasgoodgrip = false;
			hadgoodgrip = true;
		}

		if(abt.hasrollerskates == true && bonusrollerskates == false) {
			abt.hasrollerskates = false;
			hadrollerskates = true;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// Was that equipped? Not anymore
		if(abt.eqpdwalkleft == true && bonuswalkleft == false) {
			abt.eqpdwalkleft = false;
			eqpddwalkleft = true;
		}
		
		if(abt.eqpdwalkright == true && bonuswalkright == false) {
			abt.eqpdwalkright = false;
			eqpddwalkright = true;
		}

		if(abt.eqpdjump == true && bonusjump == false) {
			abt.eqpdjump = false;
			eqpddjump = true;
		}

		if(abt.eqpdattack == true && bonusattack == false) {
			abt.eqpdattack = false;
			eqpddattack = true;
		}

		if(abt.eqpdhealthbar == true && bonushealthbar == false) {
			abt.eqpdhealthbar = false;
			eqpddhealthbar = true;
		}

		if(abt.eqpdwallet == true && bonuswallet == false) {
			abt.eqpdwallet = false;
			eqpddwallet = true;
		}

		if(abt.eqpdpause == true && bonuspause == false) {
			abt.eqpdpause = false;
			eqpddpause = true;
		}

		if(abt.eqpdcyberslam == true && bonuscyberslam == false) {
			abt.eqpdcyberslam = false;
			eqpddcyberslam = true;
		}

		if(abt.eqpdpeashoot == true && bonuspeashoot == false) {
			abt.eqpdpeashoot = false;
			eqpddpeashoot = true;
		}

		if(abt.eqpdmayonaise == true && bonusmayonaise == false) {
			abt.eqpdmayonaise = false;
			eqpddmayonaise = true;
		}

		if(abt.eqpdsoap == true && bonussoap == false) {
			abt.eqpdsoap = false;
			eqpddsoap = true;
		}

		if(abt.eqpdgoodgrip == true && bonusgoodgrip == false) {
			abt.eqpdgoodgrip = false;
			eqpddgoodgrip = true;
		}

		if(abt.eqpdrollerskates == true && bonusrollerskates == false) {
			abt.eqpdrollerskates = false;
			eqpddrollerskates = true;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// Was that equipped

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		//Didn't have that? Now you do

		if(abt.hascyberslam == false && bonuscyberslam == true) {
			abt.hascyberslam = true;
			hadcyberslam = false;
		}

		if(abt.haspeashoot == false && bonuspeashoot == true) {
			abt.haspeashoot = true;
			hadpeashoot = false;
		}

		if(abt.hasmayonaise == false && bonusmayonaise == true) {
			abt.hasmayonaise = true;
			hadmayonaise = false;
		}

		if(abt.hassoap == false && bonussoap == true) {
			abt.hassoap = true;
			hadsoap = false;
		}

		if(abt.hasgoodgrip == false && bonusgoodgrip == true) {
			abt.hasgoodgrip = true;
			hadgoodgrip = false;
		}

		if(abt.hasrollerskates == false && bonusrollerskates == true) {
			abt.hasrollerskates = true;
			hadrollerskates = false;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// Didn't equip that? Now you do

		if(abt.eqpdwalkleft == false && bonuswalkleft == true) {
			abt.eqpdwalkleft = true;
			eqpddwalkleft = false;
		}

		if(abt.eqpdwalkright == false && bonuswalkright == true) {
			abt.eqpdwalkright = true;
			eqpddwalkright = false;
		}

		if(abt.eqpdjump == false && bonusjump == true) {
			abt.eqpdjump = true;
			eqpddjump = false;
		}

		if(abt.eqpdattack == false && bonusattack == true) {
			abt.eqpdattack = true;
			eqpddattack = false;
		}

		if(abt.eqpdhealthbar == false && bonushealthbar == true) {
			abt.eqpdhealthbar = true;
			eqpddhealthbar = false;
		}

		if(abt.eqpdwallet == false && bonuswallet == true) {
			abt.eqpdwallet = true;
			eqpddwallet = false;
		}

		if(abt.eqpdpause == false && bonuspause == true) {
			abt.eqpdpause = true;
			eqpddpause = false;
		}

		if(abt.eqpdcyberslam == false && bonuscyberslam == true) {
			abt.eqpdcyberslam = true;
			eqpddcyberslam = false;
		}

		if(abt.eqpdpeashoot == false && bonuspeashoot == true) {
			abt.eqpdpeashoot = true;
			eqpddpeashoot = false;
		}

		if(abt.eqpdmayonaise == false && bonusmayonaise == true) {
			abt.eqpdmayonaise = true;
			eqpddmayonaise = false;
		}

		if(abt.eqpdsoap == false && bonussoap == true) {
			abt.eqpdsoap = true;
			eqpddsoap = false;
		}

		if(abt.eqpdgoodgrip == false && bonusgoodgrip == true) {
			abt.eqpdgoodgrip = true;
			eqpddgoodgrip = false;
		}

		if(abt.eqpdrollerskates == false && bonusrollerskates == true) {
			abt.eqpdrollerskates = true;
			eqpddrollerskates = false;
		}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// Beat the bonus? Return to previous stuff
		if(plyr.isbonus == false && plyr.bonuscomplete == true) {

			plyr.apcurrent = olddp2;
			plyr.apmax = olddpmax2 + 1;

			if(hadwalkleft == true) {
				abt.haswalkleft = true;
			} else if(hadwalkleft == false) {
				abt.haswalkleft = false;
			}

			if(hadwalkright == true) {
				abt.haswalkright = true;
			} else if(hadwalkright == false) {
				abt.haswalkright = false;
			}

			if(hadjump == true) {
				abt.hasjump = true;
			} else if(hadjump == false) {
				abt.hasjump = false;
			}

			if(hadattack == true) {
				abt.hasattack = true;
			} else if(hadattack == false) {
				abt.hasattack = false;
			}

			if(hadhealthbar == true) {
				abt.hashealthbar = true;
			} else if(hadhealthbar == false) {
				abt.hashealthbar = false;
			}

			if(hadwallet == true) {
				abt.haswallet = true;
			} else if(hadwallet == false) {
				abt.haswallet = false;
			}

			if(hadpause == true) {
				abt.haspause = true;
			} else if(hadpause == false) {
				abt.haspause = false;
			}

			if(hadcyberslam == true) {
				abt.hascyberslam = true;
			} else if(hadcyberslam == false) {
				abt.hascyberslam = false;
			}

			if(hadpeashoot == true) {
				abt.haspeashoot = true;
			} else if(hadpeashoot == false) {
				abt.haspeashoot = false;
			}

			if(hadmayonaise == true) {
				abt.hasmayonaise = true;
			} else if(hadmayonaise == false) {
				abt.hasmayonaise = false;
			}

			if(hadsoap == true) {
				abt.hassoap = true;
			} else if(hadsoap == false) {
				abt.hassoap = false;
			}

			if(hadgoodgrip == true) {
				abt.hasgoodgrip = true;
			} else if(hadgoodgrip == false) {
				abt.hasgoodgrip = false;
			}

			if(hadrollerskates == true) {
				abt.hasrollerskates = true;
			} else if(hadrollerskates == false) {
				abt.hasrollerskates = false;
			}

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		//////  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  //////
		//////  ///////////////////////*********************************BOIBOIBOIBOI*************************************///////////////////////////////  //////
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			//Beat the bonus? Return to previous equips

			if(eqpddwalkleft == true) {
				abt.eqpdwalkleft = true;
			} else if(eqpddwalkleft == false) {
				abt.eqpdwalkleft = false;
			}

			if(eqpddwalkright == true) {
				abt.eqpdwalkright = true;
			} else if(eqpddwalkright == false) {
				abt.eqpdwalkright = false;
			}

			if(eqpddjump == true) {
				abt.eqpdjump = true;
			} else if(eqpddjump == false) {
				abt.eqpdjump = false;
			}

			if(eqpddattack == true) {
				abt.eqpdattack = true;
			} else if(eqpddattack == false) {
				abt.eqpdattack = false;
			}

			if(eqpddhealthbar == true) {
				abt.eqpdhealthbar = true;
			} else if(eqpddhealthbar == false) {
				abt.eqpdhealthbar = false;
			}

			if(eqpddwallet == true) {
				abt.eqpdwallet = true;
			} else if(eqpddwallet == false) {
				abt.eqpdwallet = false;
			}

			if(eqpddpause == true) {
				abt.eqpdpause = true;
			} else if(eqpddpause == false) {
				abt.eqpdpause = false;
			}

			if(eqpddcyberslam == true) {
				abt.eqpdcyberslam = true;
			} else if(eqpddcyberslam == false) {
				abt.eqpdcyberslam = false;
			}

			if(eqpddpeashoot == true) {
				abt.eqpdpeashoot = true;
			} else if(eqpddpeashoot == false) {
				abt.eqpdpeashoot = false;
			}

			if(eqpddmayonaise == true) {
				abt.eqpdmayonaise = true;
			} else if(eqpddmayonaise == false) {
				abt.eqpdmayonaise = false;
			}

			if(eqpddsoap == true) {
				abt.eqpdsoap = true;
			} else if(eqpddsoap == false) {
				abt.eqpdsoap = false;
			}

			if(eqpddgoodgrip == true) {
				abt.eqpdgoodgrip = true;
			} else if(eqpddgoodgrip == false) {
				abt.eqpdgoodgrip = false;
			}

			//if(eqpddrollerskates == true) {
			//	abt.eqpdrollerskates = true;
			//} else if(eqpddrollerskates == false) {
				abt.eqpdrollerskates = false;
			//}
		}
	}
}
