using UnityEngine;
using System.Collections;

public class TurtleRotateAndAnimate : MonoBehaviour {
	public bool isSkidding = true;
	private Rigidbody2D _rb2D;
	private Animator _animator;
	
	// Use this for initialization
	void Start () {
		_rb2D = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		animateOnMove();
		if (!isSkidding) {
			faceDirectionOfMovement();
		}
	}
	
	void animateOnMove() {
		if (_rb2D.velocity.magnitude > .2f) {
			_animator.SetBool("moving", true);
		} else {
			_animator.SetBool("moving", false);
		}
	}
	
	void faceDirectionOfMovement() {
		float angle = Mathf.Atan2(_rb2D.velocity.x, _rb2D.velocity.y) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
		if (!LeanTween.isTweening(gameObject) && _rb2D.velocity != Vector2.zero) {
			LeanTween.rotate (gameObject, q.eulerAngles, .1f);
		}
	}
	
	//    void faceDirectionOfMovement() {
	//        float angle = Mathf.Atan2(turtleVelocity.x, turtleVelocity.y) * Mathf.Rad2Deg;
	//        Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
	//        if (!LeanTween.isTweening(gameObject) && turtleVelocity != Vector2.zero) {
	//            LeanTween.rotate (gameObject, q.eulerAngles, .1f);
	//        }
	//    }
}