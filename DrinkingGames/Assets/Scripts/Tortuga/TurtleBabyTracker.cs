using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurtleBabyTracker : TurtleScript {

	public Goal goal;
	private int numBabiesNeeded = 3;
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

		
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Baby" && coll.gameObject.GetComponent<TurtleBaby>().team == team) {
			TurtleBaby turtleBaby = coll.gameObject.GetComponent<TurtleBaby>();

			if (!turtleBaby.followTurtle) {
				babiesOnBoard.Add(coll.gameObject);
				if (babiesOnBoard.Count == 1) {
					turtleBaby.positionToFollow = turtleControls.followPosition;
				} else {
					turtleBaby.positionToFollow = babiesOnBoard[babiesOnBoard.Count - 2].GetComponent<TurtleBaby>().followPosition;
				}
				turtleBaby.wander = false;
				turtleBaby.followTurtle = true;
				turtleBaby.lightOn(false);
			}
				
		}

		if (checkIfAllBabiesOnBoard()) {
			goal.setToOpen();
		} else {
			goal.setToClosed();
		}
	}
	
	
	public void loseBaby() {
		TurtleBaby turtleBaby = babiesOnBoard[babiesOnBoard.Count - 1].GetComponent<TurtleBaby>();

//		turtleBaby._rb2D.velocity = Vector2.zero;
//		turtleBaby.wanderTarget.GetComponent<WanderTarget>().setContainerPosition();
		turtleBaby.followTurtle = false;
		turtleBaby.lightOn(true);
		babiesOnBoard.RemoveAt (babiesOnBoard.Count - 1);
	}

	bool checkIfAllBabiesOnBoard() {
		bool allBabiesOnBoard = (babiesOnBoard.Count == numBabiesNeeded) ? true : false;
		return allBabiesOnBoard;
	}
}