using UnityEngine;
using System.Collections;

public class TurtleBabyWanderState : ITurtleBabyState {

	private readonly TurtleBaby baby;
	private Vector3 _moveTo;
	private float _osc;

	public TurtleBabyWanderState(TurtleBaby turtleBaby) {
		baby = turtleBaby;
	}

	public void UpdateState() {
		Wander ();
		OscillateHalo (3f, 1f);
	}

	public void ToWanderState() {
		Debug.Log ("Can't transition to same state");
	}
	
	public void ToFollowState(Transform follow) {
		//get a reference to the parent turtle baby tracker
		baby.turtleLight.enabled = false;
		baby.positionToFollow = follow;
		baby.maxSpeed = 4f;
		baby.currentState = baby.followState;
	}
	
	public void ToSkidState() {
		Debug.Log ("should change to skid from follow");
	}

	public void OnTriggerEnter2D(Collider2D coll) {
	
	}

	void Wander() {
		followObject (baby.wanderTarget.transform);
		faceDirectionOfMovement();
		animateOnMove ();
	}
	
	void followObject(Transform posToFollow) {
		_moveTo = posToFollow.position - baby.transform.position;
		if (_moveTo.magnitude > .2f) {	
//			Debug.Log ("baby max speed: " + baby.maxSpeed);
			baby.rb2D.velocity = _moveTo * baby.maxSpeed;
		} else {
			baby.rb2D.velocity = Vector2.zero;
		} 
	}

	
	void OscillateHalo(float haloOscillationSpeed, float haloOscillationScale) {
		_osc = Mathf.Sin (Time.time * haloOscillationSpeed) * haloOscillationScale +2f;
		baby.turtleLight.range = _osc;
	}

	void faceDirectionOfMovement() {
		float angle = Mathf.Atan2(baby.rb2D.velocity.x, baby.rb2D.velocity.y) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
		if (!LeanTween.isTweening(baby.gameObject) && baby.rb2D.velocity != Vector2.zero) {
			LeanTween.rotate (baby.gameObject, q.eulerAngles, .1f);
		}
	}

	
	void animateOnMove() {
		if (baby.rb2D.velocity.magnitude > .2f) {
			baby.animator.SetBool("moving", true);
		} else {
			baby.animator.SetBool("moving", false);
		}
	}
}
