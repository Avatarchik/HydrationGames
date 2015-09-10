using UnityEngine;
using System.Collections;

public class Crab : MonoBehaviour {

	private AudioSource _crabAudioSource;
	private Rigidbody2D _rb2D;
	private float speedMultiplier;
	public bool _hasKnockedOffBaby = false;

	// Use this for initialization
	void Start () {
		_crabAudioSource = GetComponent<AudioSource> ();
		_rb2D = GetComponent<Rigidbody2D> ();
//		setVelocity ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Space)) {

			print ("testing knock");
			_hasKnockedOffBaby = false;
		}
		
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "TurtleParent") {
			if (!_hasKnockedOffBaby) {
				_crabAudioSource.PlayOneShot(_crabAudioSource.clip);
				coll.gameObject.GetComponent<TurtleBabyTracker>().loseBaby();
				_hasKnockedOffBaby = true;
			}
		}
	}
//
//	void setVelocity() {
//		speedMultiplier = Random.Range (1f, 2f);
//		_rb2D.velocity = new Vector2 (0, -1f) * speedMultiplier;
//	}

	void reset() {
		_hasKnockedOffBaby = false;
	}
}
