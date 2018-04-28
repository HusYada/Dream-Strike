using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonuscheck : MonoBehaviour {

	// Do you like if statements?

	public player plyr;			// A script variable to access variables from the abtscreen script
	public abtscreen abt;			// A script variable to access variables from the abtscreen script
	public bonus bns;

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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(bns.gohere == plyr.transform.position) {
			olddp = plyr.apcurrent;
			olddpmax = plyr.apmax;
		}

		if(plyr.isbonus == true && plyr.bonuscomplete == false) {

			//if(olddp == plyr.apcurrent || olddpmax == plyr.apmax) {
				plyr.apcurrent = changedp;
				plyr.apmax = changedpmax;
				olddp2 = olddp;
				olddpmax2 = olddpmax;
			//}

			// Change cp accordingly
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
			plyr.apmax = olddpmax2;

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
		}
	}
}
