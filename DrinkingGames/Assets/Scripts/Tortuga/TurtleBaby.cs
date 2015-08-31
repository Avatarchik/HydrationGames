using UnityEngine;
using System.Collections;

public class TurtleBaby : TurtleScript {

	private AudioSource _wahAudioSource;
	private Animator _animator;
	public bool follow = false;
	public Transform positionToFollow;
	public Rigidbody2D _rb2D;
	public Vector2 moveTo;
	public Transform followPosition;


	// Use this for initialization
	void Start () {
		_wahAudioSource = GetComponent<AudioSource> ();
		_animator = GetComponent<Animator> ();
		_rb2D = GetComponent<Rigidbody2D> ();
		follow = false;
	
		//Every turtle has a position to follow
		//and its own follow position
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			followTurtle(positionToFollow);
		}

		animateOnMove ();

	}

	void followTurtle(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		_rb2D.velocity = moveTo * 5f;
		faceDirectionOfMovement ();

	}
 	
	void faceDirectionOfMovement() {
		float angle = Mathf.Atan2(_rb2D.velocity.x, _rb2D.velocity.y) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
		if (!LeanTween.isTweening(gameObject) && _rb2D.velocity.magnitude > .2f) {
			LeanTween.rotate (gameObject, q.eulerAngles, .01f);
		}
	}

	void animateOnMove() {
		if (_rb2D.velocity.magnitude > .2f) {
			_animator.SetBool("moving", true);
		} else {
			_animator.SetBool("moving", false);
		}
	}
}
