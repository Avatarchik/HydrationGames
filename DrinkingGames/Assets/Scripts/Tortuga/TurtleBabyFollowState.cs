using UnityEngine;
using System.Collections;

public class TurtleBabyFollowState : ITurtleBabyState {
	
		private readonly TurtleBaby baby;
		Vector3 moveTo;
		
		public TurtleBabyFollowState(TurtleBaby turtleBaby) {
			baby = turtleBaby;
		}
		
		public void UpdateState() {
			FollowTurtle ();
		}
		
		public void ToWanderState() {
			Debug.Log ("going to wander state");
			baby.turtleLight.enabled = true;
			baby.maxSpeed = 2f;
			baby.currentState = baby.wanderState;
		}
		
		public void ToFollowState(Transform follow) {
			
			Debug.Log ("Can't transition to same state");

		}
		
		public void ToSkidState() {
			Debug.Log ("to skid");
			baby.turtleLight.enabled = true;
			baby.currentState = baby.skidState;
		}
		
		public void OnTriggerEnter2D(Collider2D coll) {}
		
		
		void FollowTurtle() {
			followObject (baby.positionToFollow);
			faceDirectionOfMovement ();
			animateOnMove ();
		}
		
		void followObject(Transform posToFollow) {
			moveTo = posToFollow.position - baby.transform.position;
			if (moveTo.magnitude > .2f) {	
				baby.rb2D.velocity = moveTo * baby.maxSpeed;
			} else {
				baby.rb2D.velocity = Vector2.zero;
			} 
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

