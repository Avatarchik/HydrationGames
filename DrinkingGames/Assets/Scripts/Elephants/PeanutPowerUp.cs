using UnityEngine;
using System.Collections;

public class PeanutPowerUp : PowerUp {
	
	private int numPeanutsToAdd = 10;
	private int maxPeanuts = 100;
	
	// Use this for initialization
	public override void Start () {
		base.Start ();
		
	}
	
	public override void OnTriggerEnter2D(Collider2D coll) {
		base.OnTriggerEnter2D (coll);
		//		updatePeanutCollectedStat ();
		if (coll.gameObject.tag == "Boat") {
			
			if (_boatWeapons.numPeanuts + numPeanutsToAdd < maxPeanuts) {
				_boatWeapons.numPeanuts += numPeanutsToAdd;
			} else {
				_boatWeapons.numPeanuts = maxPeanuts;
			}
			
			_boatWeapons.updatePeanutCounter();
			_boatWeapons.peanutBin.setPeanutsActive(numPeanutsToAdd);
			//StartCoroutine(_boatWeapons.peanutBin.setPeanutsActiveCoroutine(numPeanutsToAdd));
			_powerUpManager.decrementActivePowerUps (ref _powerUpManager.numActivePeanutPowerUps);
		}
	}
	
	//	void updatePeanutCollectedStat() {
	//		if (_boatWeapons.team == BoatScript.Team.Blue) {
	//			GameStats.BluePeanutPowerUps++;
	//		} else {
	//			GameStats.GreenPeanutPowerUps++;	
	//		}
	//	}
	
}
