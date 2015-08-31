using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurtleBabyTracker : TurtleScript {

	public int numBabiesOnBoard = 0;
	public List<GameObject> babiesOnBoard;
	public TurtleControls turtleControls;
	bool babyLost = false;

	// Use this for initialization
	void Start () {
		turtleControls = GetComponent<TurtleControls> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) {
			loseBaby();
		}

	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Baby") {
			TurtleBaby turtleBaby = coll.gameObject.GetComponent<TurtleBaby>();
			if (!turtleBaby.follow) {
				babiesOnBoard.Add(coll.gameObject);
				if (babiesOnBoard.Count == 1) {
					turtleBaby.positionToFollow = turtleControls.followPosition;
				} else {
					turtleBaby.positionToFollow = babiesOnBoard[babiesOnBoard.Count - 2].GetComponent<TurtleBaby>().followPosition;
				}
				turtleBaby.follow = true;
			}
		}
	}


	void loseBaby() {
		if (!babyLost) {
			print ("BB: " + babiesOnBoard [0]);
			TurtleBaby turtleBaby = babiesOnBoard[babiesOnBoard.Count - 1].GetComponent<TurtleBaby>();
			turtleBaby.follow = false;
			babiesOnBoard.RemoveAt (babiesOnBoard.Count - 1);
			babyLost = true;
		}
	}
}
