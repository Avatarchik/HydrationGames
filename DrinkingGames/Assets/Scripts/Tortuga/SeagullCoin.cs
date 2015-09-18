using UnityEngine;
using System.Collections;

public class SeagullCoin : MonoBehaviour {

	public GameObject blueTurtleParent;
	public GameObject greenTurtleParent;
	public Seagull seagull;
	private float _yBounds = -7f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "TurtleParent") {

			if (coll.gameObject.GetComponent<TurtleScript>().team == TurtleScript.Team.Blue) {
				seagull.setTurtleToAttack(greenTurtleParent);
			} else {
				seagull.setTurtleToAttack(blueTurtleParent);
			}

			seagull.attackTurtle();
		}
	}

	void setInactiveIfOutOfBounds() {
		if (transform.position.y < _yBounds) {
			gameObject.SetActive(false);
		}
	}
}
