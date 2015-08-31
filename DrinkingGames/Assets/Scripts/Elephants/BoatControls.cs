using UnityEngine;
using System.Collections;

public class BoatControls : Controls {

	//Components
	private Animator _animator;
	private BoatMovement _boatMovement;
	private BoatWeapons _boatWeapons;
	private BoatHealth _boatHealth;

	//Variables
	private string _thrustButton;
	private string _rotateButton;
	private string _peanutButton;
	private string _torpedoButton;

	// Use this for initialization
	void Start () {

		//Get components
		_boatMovement = GetComponent<BoatMovement> ();
		_boatWeapons = GetComponent<BoatWeapons> ();
		_boatHealth = GetComponent<BoatHealth> ();

		//Assign controls
		_thrustButton = W_UP;
		_rotateButton = S_DOWN;
		_peanutButton = D_RIGHT;
		_torpedoButton = A_LEFT;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!_boatHealth.playerDying) {
			thrustAction ();
			rotateAction ();
			peanutAction ();
			torpedoAction ();
		} else {
			_boatMovement.stopThrust();
			_boatMovement.stopRotate();
		}
	}

	void thrustAction() {
		if (Input.GetKey (_thrustButton)) {
			_boatMovement.thrust ();
		} else {
			_boatMovement.stopThrust();
		}
	}

	void rotateAction() {
		if (Input.GetKey (_rotateButton)) {
			_boatMovement.rotate ();
		} else {
			_boatMovement.stopRotate();
		}
	}

	void peanutAction() {
		if (Input.GetKey (_peanutButton)) {
			_boatWeapons.firePeanuts ();
		} else {
			_boatWeapons.stopPeanuts ();
		}
	}

	void torpedoAction() {
		if (Input.GetKey (_torpedoButton)) {
			_boatWeapons.chargeTorpedo ();
		} else {
			_boatWeapons.stopChargeTorpedo();
		}

	}

}
