using UnityEngine;
using System.Collections;

public class StartScreenGoal : TurtleScript {



	[SerializeField] private AudioSource _audSource;
	[SerializeField] private AudioClip _drainClip;
	[SerializeField] private AudioClip _popClip;
	[SerializeField] private GameObject goalParticlesPrefab;

	public TortugaStartGameButton startButton;


	private Vector3 _slowRotateSpeed;
	private Vector3 _fastRotateSpeed;
	private Vector3 _rotateSpeed;

	void Start() {
		_slowRotateSpeed = new Vector3 (0f, 0f, -10);
		_fastRotateSpeed = _slowRotateSpeed * 1.5f;
		_rotateSpeed = _slowRotateSpeed;

	}

	void Update() {
		transform.Rotate (_rotateSpeed);

	}
	void OnTriggerEnter2D(Collider2D coll) {
		
			if (coll.gameObject.tag == "TurtleParent" && coll.gameObject.GetComponent<TurtleBabyTracker>().team == team) {
				StartCoroutine(takeTurtle(coll.gameObject));
			}

	}


	IEnumerator takeTurtle(GameObject turtle) {


		StartCoroutine (playTakeTurtleSounds ());



		turtle.transform.SetParent (gameObject.transform);
//		LeanTween.move (turtle, transform.position, 1f);
//		LeanTween.scale (turtle, Vector3.zero, 1f);
		LeanTween.scale (gameObject, Vector3.zero, 1.2f);


		if (team == Team.Blue) {
			startButton.blueTurtleReady = true;
		} else {
			startButton.greenTurtleReady = true;
		}

		while (LeanTween.isTweening (gameObject)) {
			yield return null;
		}

		GameObject goalParticles = Instantiate (goalParticlesPrefab, transform.position, Quaternion.identity) as GameObject;

		startButton.checkTurtlesReady ();

	}


	IEnumerator playTakeTurtleSounds() {
		_audSource.PlayOneShot (_drainClip);
		yield return new WaitForSeconds (_drainClip.length);
		_audSource.PlayOneShot (_popClip);
		
	}
}
