using UnityEngine;
using System.Collections;

public class TorpedoHealth : MonoBehaviour {

	private Torpedo _torpedo;
	private int health = 1;
	private bool _torpedoHit = false;
	

	// Use this for initialization
	void Start () {
		_torpedo = GetComponent<Torpedo>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0 && !_torpedoHit) {
			_torpedo.switchTeam();
			_torpedoHit = true;
		}

	}

	public void takePeanutDamage() {
		print ("damage taken");
		health--;
	}
}
