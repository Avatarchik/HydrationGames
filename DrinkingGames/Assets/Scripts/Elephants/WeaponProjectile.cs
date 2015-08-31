using UnityEngine;
using System.Collections;

public class WeaponProjectile : MonoBehaviour {
	
	public GameObject enemyBoat;
	public BoatHealth enemyBoatHealth;
	public enum Team {Blue, Green}
	public Team team; //set this on the inspector;

	// Use this for initialization
	protected virtual void Start () {
		setEnemyBoat ();
	}

	//Sets the boat that will take damage when hit by a peanut. 
	public void setEnemyBoat() {
		if (team == Team.Blue) {
			enemyBoat = GameObject.Find ("GreenBoat");
		} else {
			enemyBoat = GameObject.Find("BlueBoat");
		}
		
		enemyBoatHealth = enemyBoat.GetComponent<BoatHealth> ();
	} 

}
