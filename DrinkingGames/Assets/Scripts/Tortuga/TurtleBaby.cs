﻿using UnityEngine;
using System.Collections;

public class TurtleBaby : TurtleScript {

	private AudioSource _wahAudioSource;
	private Animator _animator;
	public bool follow = false;
	public Transform positionToFollow;
	private Vector3 _rotateSpeed;
	public Rigidbody2D _rb2D;
	public Vector2 moveTo;
	public Transform followPosition;


	// Use this for initialization
	void Start () {
		_wahAudioSource = GetComponent<AudioSource> ();
		_animator = GetComponent<Animator> ();
		_rb2D = GetComponent<Rigidbody2D> ();
		follow = false;
		_rotateSpeed = new Vector3 (0f, 0f, Time.deltaTime * 360f);
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			followTurtle (positionToFollow);
		} else {
			wander ();
		}


	}

	void followTurtle(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		_rb2D.velocity = moveTo * 5f;

	}
 	
	public void wander() {
		_rb2D.velocity = Vector2.zero;
		transform.Rotate (_rotateSpeed);
	}

}
