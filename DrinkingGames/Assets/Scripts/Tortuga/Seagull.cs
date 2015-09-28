using UnityEngine;
using System.Collections;

public class Seagull : MonoBehaviour {


	private Rigidbody2D _rb2D;
	public bool attack;
	public GameObject turtleToAttack;

	void Start () {
		_rb2D = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject == turtleToAttack) {
			TurtleBabyTracker babyTracker = coll.GetComponent<TurtleBabyTracker>();
			int babiesToLose = babyTracker.babiesOnBoard.Count;
			for (int i = 0; i < babiesToLose; i++) {
			
				babyTracker.loseBaby();
			}
		}
	}

//	public void setTurtleToAttack() {
//		turtleToAttack = turtle;
//	}

	public void attackTurtle(GameObject t) {
		turtleToAttack = t;
		Vector2 attackVel = (t.transform.position - transform.position);
		_rb2D.velocity = attackVel.normalized * 5f;
		faceDirectionOfMovement ();
	}

	void faceDirectionOfMovement() {
		float angle = Mathf.Atan2(_rb2D.velocity.x, _rb2D.velocity.y) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
		if (!LeanTween.isTweening(gameObject) && _rb2D.velocity != Vector2.zero) {
			LeanTween.rotate (gameObject, q.eulerAngles, .1f);
		}
	}
}
