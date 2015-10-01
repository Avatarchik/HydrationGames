using UnityEngine;
using System.Collections;

public class TurtleBabySkidState : ITurtleBabyState {
	private readonly TurtleBaby baby;
	private bool _skidStarted = false;
	public TurtleBabySkidState(TurtleBaby turtleBaby) {
		baby = turtleBaby;
	}
	public void UpdateState(){
		if (!_skidStarted) {
			baby.StartCoroutine(skid ());
			_skidStarted = true;
		}
	}

	public void ToWanderState(){
		baby.currentState = baby.wanderState;
		_skidStarted = false;
		Debug.Log ("falsed skidstarted");
	}
	
	public void ToFollowState(Transform follow){
		baby.currentState = baby.followState;
	}
	
	public void ToSkidState(){
		Debug.Log ("Can't change to same state");
	}

	public void OnTriggerEnter2D(Collider2D coll){}

	IEnumerator skid() {
		float angle = Random.Range (0,360);
		float x = 5 * Mathf.Cos (angle * Mathf.PI/180) + baby.transform.position.x;
		float y = 5 * Mathf.Sin (angle * Mathf.PI/180) + baby.transform.position.y;
	
		baby.rb2D.AddForce(baby.transform.up*-12f, ForceMode2D.Impulse);

		//baby.rb2D.AddForce(new Vector2 ((x-baby.transform.position.x), (y-baby.transform.position.y)), ForceMode2D.Impulse);
		baby.rb2D.AddTorque (20f, ForceMode2D.Impulse);

		LeanTween.value( baby.gameObject, baby.rb2D.velocity, Vector2.zero, 1f).setOnUpdate( (Vector2 val)=>{ 
			baby.rb2D.velocity = val;
		} );

		while (LeanTween.isTweening(baby.gameObject)) {
			yield return null;
		}

		baby.rb2D.velocity = Vector2.zero;
		baby.rb2D.angularVelocity = 0f;
		baby.rb2D.drag = 0f;
		baby.rb2D.angularDrag = 0.05f;
		ToWanderState ();
	}

}
