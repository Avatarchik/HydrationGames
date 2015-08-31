using UnityEngine;
using System.Collections;

public class TurtleControls : Controls {

	//Components
	private Animator _animator;
	public Rigidbody2D rb2D;
	//Variables
	private string _upButton;
	private string _downButton;
	private string _rightButton;
	private string _leftButton;

	private Vector2 turtleVelocity;
	public Transform followPosition;




	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		_animator = GetComponent<Animator> ();

		_upButton = W_UP;
		_downButton = S_DOWN;
		_rightButton = D_RIGHT;
		_leftButton = A_LEFT;
	}
	
	// Update is called once per frame
	void Update () {
		turtleMovement ();
		animateOnMove ();
	
	}

	void turtleMovement() {
	
		float speedMultiplier = 1f;

		if (Input.GetKey (_upButton)) {
			turtleVelocity.y = 1f;
		} else if (Input.GetKey (_downButton)) {
			turtleVelocity.y = -1f;
		} else {
			turtleVelocity.y = 0f;
		}

		if (Input.GetKey (_rightButton)) {
			turtleVelocity.x = 1f;
		} else if (Input.GetKey (_leftButton)) {
			turtleVelocity.x = -1f;
		} else {
			turtleVelocity.x = 0f;
		}

		rb2D.velocity = turtleVelocity * speedMultiplier;

		faceDirectionOfMovement();

	}

	void animateOnMove() {
		if (rb2D.velocity.magnitude > .2f) {
			_animator.SetBool("moving", true);
		} else {
			_animator.SetBool("moving", false);
		}
	}

	void faceDirectionOfMovement() {
		float angle = Mathf.Atan2(turtleVelocity.x, turtleVelocity.y) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
		if (!LeanTween.isTweening(gameObject) && turtleVelocity != Vector2.zero) {
			LeanTween.rotate (gameObject, q.eulerAngles, .1f);
		}
	}
}
