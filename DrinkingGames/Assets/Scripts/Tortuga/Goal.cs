﻿using UnityEngine;
using System.Collections;

public class Goal : TurtleScript {

	[SerializeField] private TortugaScoreManager _tortugaScoreManager; 

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
				takeTurtle(coll.gameObject);
				foreach (GameObject turtleBaby in coll.gameObject.GetComponent<TurtleBabyTracker>().babiesOnBoard) {
					takeTurtle(turtleBaby);
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

	void takeTurtle(GameObject turtle) {
		LeanTween.move (turtle, transform.position, 1f);
		LeanTween.scale (turtle, Vector3.zero, 1f);

		if (!_scoreIncremented) {
			if (team == Team.Blue) {
				_tortugaScoreManager.blueScore++;
			} else {
				_tortugaScoreManager.greenScore++;
			}
			_scoreIncremented = true;
		}
	}



}
