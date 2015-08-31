using UnityEngine;
using System.Collections;

public class TorpedoPowerUp : PowerUp {

	// Use this for initialization
	public override void Start () {
		base.Start ();
	}

	public override void OnTriggerEnter2D(Collider2D coll) {

		base.OnTriggerEnter2D(coll);
//		updateTorpedoCollectedStat ();
		//Check to see if player is dying so a destroyed boat isn't equipped
		if (coll.gameObject.tag == "Boat" && !_boatHealth.playerDying) {
	
			if (!_boatWeapons.torpedoEquipped) {
				_boatWeapons.equipTorpedo ();
				_powerUpManager.decrementActivePowerUps (ref _powerUpManager.numActiveTorpedoPowerUps);
			}
		}
	}

//	void updateTorpedoCollectedStat() {
//		if (_boatWeapons.team == BoatScript.Team.Blue) {
//			GameStats.BlueTorpedoPowerUps++;
//		} else {
//			GameStats.GreenTorpedoPowerUps++;	
//		}
//	}

}
