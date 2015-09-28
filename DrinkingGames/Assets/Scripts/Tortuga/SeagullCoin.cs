using UnityEngine;
using System.Collections;

public class SeagullCoin : MonoBehaviour {

	[SerializeField]
	private GameObject _blueTurtleParent;
	[SerializeField]
	private GameObject _greenTurtleParent;
	[SerializeField]
	private Seagull _seagull;
	private float _yBounds = -7f;

	// Use this for initialization
	void Start () {
		_blueTurtleParent = GameObject.Find("BlueTurtleParent");
		_greenTurtleParent = GameObject.Find ("GreenTurtleParent");
		_seagull = GameObject.Find("Seagull").GetComponent<Seagull>();
	}
	
	// Update is called once per frame
	void Update () {
		setInactiveIfOutOfBounds();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "TurtleParent") {

			if (coll.gameObject.GetComponent<TurtleScript>().team == TurtleScript.Team.Blue) {
				_seagull.setTurtleToAttack(_greenTurtleParent);
			} else {
				_seagull.setTurtleToAttack(_blueTurtleParent);
			}

			_seagull.attack =  true;
		}
	}

	void setInactiveIfOutOfBounds() {
		if (transform.position.y < _yBounds) {
			Destroy(gameObject);
		}
	}
}
