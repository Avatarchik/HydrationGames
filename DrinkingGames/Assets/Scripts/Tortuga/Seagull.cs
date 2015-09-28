using UnityEngine;
using System.Collections;

public class Seagull : MonoBehaviour {

	public bool attack;
	public GameObject turtleToAttack;
	private Rigidbody2D _rb2D;
	[SerializeField]
	private Vector3 _startPosition;

	void Start () {
		_startPosition = transform.position;
		_rb2D = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		if (attack) {
			attackTurtle();
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject == turtleToAttack) {
			TurtleBabyTracker babyTracker = coll.GetComponent<TurtleBabyTracker>();
			int babiesToLose = babyTracker.babiesOnBoard.Count;
			for (int i = 0; i < babiesToLose; i++) {
				babyTracker.loseBaby();
			}
			explode();
		}
	}

	public void setTurtleToAttack(GameObject turtle) {
		turtleToAttack = turtle;
	}

	public void attackTurtle() {
		Vector2 attackVel = (turtleToAttack.transform.position - transform.position);
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

	void explode() {
		attack = false;
		_rb2D.velocity = Vector2.zero;
		transform.position = _startPosition;
	}

}
