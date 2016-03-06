using UnityEngine;
using System.Collections;
using TMPro;

public class StartScreenGoal : TurtleScript {

	[SerializeField] private AudioSource _audSource;
	[SerializeField] private AudioClip _drainClip;
	[SerializeField] private AudioClip _popClip;
	[SerializeField] private GameObject goalParticlesPrefab;
	[SerializeField] private TextMeshProUGUI _goalText;


	public TortugaStartGameButton startButton;

	private bool _hasTakenTurtle= false;
	private Vector3 _slowRotateSpeed;
	private Vector3 _fastRotateSpeed;
	private Vector3 _rotateSpeed;

	void Start() {
		_slowRotateSpeed = new Vector3 (0f, 0f, -5);
		_fastRotateSpeed = _slowRotateSpeed * 1.5f;
		_rotateSpeed = _slowRotateSpeed;
	}

	void Update() {
		transform.Rotate (_rotateSpeed);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (!_hasTakenTurtle) {
			if (coll.gameObject.tag == "TurtleParent" && coll.gameObject.GetComponent<TurtleBabyTracker>().team == team) {
				StartCoroutine(takeTurtle(coll.gameObject));
				_hasTakenTurtle = true;
			}
		}

	}


	IEnumerator takeTurtle(GameObject turtle) {

		turtle.transform.SetParent (gameObject.transform);
		LeanTween.move (turtle, transform.position, .1f);

//		if (!_soundPlayed) {
//			StartCoroutine (playTakeTurtleSoundsAndParticles ());
//			_soundPlayed = true;
//		}

		_audSource.PlayOneShot (_drainClip);



		LeanTween.scale (gameObject, Vector3.zero, 1.2f);
		LeanTween.value (_goalText.gameObject, _goalText.color, Color.clear, 1f).setOnUpdate( (Color c) => {
			_goalText.color = c;		
		});



		if (team == Team.Blue) {
			startButton.blueTurtleReady = true;
		} else {
			startButton.greenTurtleReady = true;
		}

		while (LeanTween.isTweening (gameObject)) {
			yield return null;
		}

		_audSource.PlayOneShot (_popClip);
		Destroy(_goalText);
		GameObject goalParticles = Instantiate (goalParticlesPrefab, transform.position, Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (4f);
		startButton.checkTurtlesReady ();

	}


	IEnumerator playTakeTurtleSoundsAndParticles() {
		_audSource.PlayOneShot (_drainClip);
		yield return new WaitForSeconds (_drainClip.length-.05f);
		_audSource.PlayOneShot (_popClip);
		GameObject goalParticles = Instantiate (goalParticlesPrefab, transform.position, Quaternion.identity) as GameObject;
		Destroy (goalParticles, 2f);
	}
}
