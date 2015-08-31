using UnityEngine;
using System.Collections;

public class Crab : MonoBehaviour {


	private Rigidbody2D _rb2D;
	private float speedMultiplier;

	// Use this for initialization
	void Start () {
		_rb2D = GetComponent<Rigidbody2D> ();
		setVelocity ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setVelocity() {
		speedMultiplier = Random.Range (1f, 2f);
		_rb2D.velocity = new Vector2 (0, -1f) * speedMultiplier;
	}
}
