using UnityEngine;
using System.Collections;

public class Goal : TurtleScript {

	[SerializeField] private TortugaScoreManager _tortugaScoreManager; 

	[SerializeField] private AudioSource _audSource;
	[SerializeField] private AudioClip _drainClip;
	[SerializeField] private AudioClip _popClip;
	[SerializeField] private GameObject goalParticlesPrefab;
	private Vector3 _slowRotateSpeed;
	private Vector3 _fastRotateSpeed;
	private Vector3 _rotateSpeed;
	private Vector3 _originalScale;
	private Vector3 _bigScale;
	[SerializeField] private bool _isOpen = false;
	private bool _scoreIncremented = false;

	// Use this for initialization
	void Start () {
		_tortugaScoreManager = GameObject.Find ("TortugaScoreManager").GetComponent<TortugaScoreManager>();
		_scoreIncremented = false;
		_originalScale = transform.localScale;
		_bigScale = _originalScale * 2.5f;
		_slowRotateSpeed = new Vector3 (0f, 0f, -10);
		_fastRotateSpeed = _slowRotateSpeed * 1.5f;
		_rotateSpeed = _slowRotateSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (_rotateSpeed);
	}
		
	void OnTriggerEnter2D(Collider2D coll) {
		if (_isOpen) {
			if (coll.gameObject.tag == "TurtleParent" && coll.gameObject.GetComponent<TurtleBabyTracker>().team == team) {
				StartCoroutine(takeParentTurtle(coll.gameObject));
				foreach (GameObject turtleBaby in coll.gameObject.GetComponent<TurtleBabyTracker>().babiesOnBoard) {
					takeBabyTurtle(turtleBaby);
				}
				StartCoroutine(_tortugaScoreManager.loadScoreboardOrGameOver ());

			}
		}
	}

	public void setToOpen() {
		_isOpen = true;
		_rotateSpeed = _fastRotateSpeed;
		LeanTween.cancel (gameObject); 
		LeanTween.scale (gameObject, _bigScale, 1f).setEase (LeanTweenType.easeOutSine);
	}

	public void setToClosed() {
		_isOpen = false;
		_rotateSpeed = _slowRotateSpeed;
		LeanTween.cancel (gameObject);
		LeanTween.scale (gameObject, _originalScale, .5f).setEase (LeanTweenType.easeOutSine);
	}

	IEnumerator takeParentTurtle(GameObject turtle) {

		if (!_scoreIncremented) {
			if (team == Team.Blue) {
				_tortugaScoreManager.blueScore++;
			} else {
				_tortugaScoreManager.greenScore++;
			}
			_scoreIncremented = true;
		}

		turtle.transform.SetParent (gameObject.transform);
		LeanTween.move (turtle, transform.position, .1f);
		_audSource.PlayOneShot (_drainClip);
		LeanTween.scale (gameObject, Vector3.zero, 1.2f);
		while (LeanTween.isTweening (gameObject)) {
			yield return null;
		}
		_audSource.PlayOneShot (_popClip);
		GameObject goalParticles = Instantiate (goalParticlesPrefab, transform.position, Quaternion.identity) as GameObject;
	}

	void takeBabyTurtle(GameObject turtle) {
		turtle.transform.SetParent (gameObject.transform);
		LeanTween.move (turtle, transform.position, .1f);
	}



}
