using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurtleBabyTracker : TurtleScript {

	private bool babyLost = false;
	public Goal goal;
	private int numBabiesNeeded = 3;
	public int numBabiesOnBoard = 0;
	public List<GameObject> babiesOnBoard;
	public TurtleControls turtleControls;
	private TurtleRotateAndAnimate _turtleRotateAndAnimate;

	private SpriteRenderer _spriteRenderer;
	[SerializeField]
	private Color originalColor;
	[SerializeField]
	private Color hurtColor;



	// Use this for initialization
	void Start () {
		_turtleRotateAndAnimate = GetComponent<TurtleRotateAndAnimate> ();
		turtleControls = GetComponent<TurtleControls> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();

		originalColor = _spriteRenderer.color;
		hurtColor = new Color (originalColor.r, originalColor.g, originalColor.b, .4f);
	}
	
	// Update is called once per frame
	void Update () {

		
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Baby" && coll.gameObject.GetComponent<TurtleBaby>().team == team) {
			TurtleBaby turtleBaby = coll.gameObject.GetComponent<TurtleBaby>();

			if (turtleBaby.currentState != turtleBaby.followState) {
				print ("current state is: " + turtleBaby.currentState);
			//if (!turtleBaby.followTurtle) {
				babiesOnBoard.Add(coll.gameObject);
				if (babiesOnBoard.Count == 1) {
					turtleBaby.positionToFollow = turtleControls.followPosition;
				} else {
					turtleBaby.positionToFollow = babiesOnBoard[babiesOnBoard.Count - 2].GetComponent<TurtleBaby>().followPosition;
				}
				turtleBaby.currentState.ToFollowState(turtleBaby.positionToFollow);

				turtleBaby.wander = false;
				turtleBaby.followTurtle = true;
//				turtleBaby.lightOn(false);
				checkBabiesAndSetGoal();
			}
				

		}


		if (coll.gameObject.tag == "Crab") {
			StartCoroutine(showHurtColor());
			checkBabiesAndSetGoal();

		}


	}
	
	
	public void loseBaby() {
		if (babiesOnBoard.Count > 0) {
			TurtleBaby turtleBaby = babiesOnBoard[babiesOnBoard.Count - 1].GetComponent<TurtleBaby>();
			turtleBaby.followTurtle = false;
//			turtleBaby.lightOn(true);


//			float angle = Random.Range (0,360);
//			float x = 5 * Mathf.Cos (angle * Mathf.PI/180) + turtleBaby.gameObject.transform.position.x;
//			float y = 5 * Mathf.Sin (angle * Mathf.PI/180) + turtleBaby.gameObject.transform.position.y;
//			float testX = x-turtleBaby.gameObject.transform.position.x;
//			float testY = y-turtleBaby.gameObject.transform.position.y;
//			print (testX + " " +  testY);
//			turtleBaby._rb2D.AddForce(new Vector2 ((x-turtleBaby.gameObject.transform.position.x) * 20f, (y-turtleBaby.gameObject.transform.position.y) * 20f), ForceMode2D.Impulse);
			babiesOnBoard.RemoveAt (babiesOnBoard.Count - 1);
			checkBabiesAndSetGoal();
		}
	}

	void checkBabiesAndSetGoal() {
		if (allBabiesOnBoard()) {
			goal.setToOpen();
		} else {
			goal.setToClosed();
		}
	}

	bool allBabiesOnBoard() {
		bool allBabiesOnBoard = (babiesOnBoard.Count == numBabiesNeeded) ? true : false;
		return allBabiesOnBoard;
	}

	IEnumerator showHurtColor() {
		_spriteRenderer.color = hurtColor;
		yield return new WaitForSeconds(.1f);
		_spriteRenderer.color = originalColor;

	}
}