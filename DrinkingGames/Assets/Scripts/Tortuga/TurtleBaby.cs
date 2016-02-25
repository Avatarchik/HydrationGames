using UnityEngine;
using System.Collections;

public class TurtleBaby : TurtleScript {

	[HideInInspector] public Light turtleLight;
	[HideInInspector] public Animator animator;
	private AudioSource _wahAudioSource;
	public bool followTurtle = false;
	public bool wander = false;
	public Transform positionToFollow;
	public Rigidbody2D rb2D;
	public Vector2 moveTo;
	public Transform followPosition;
	private TurtleRotateAndAnimate _turtleRotateAndAnimate;

	//public CircleCollider2D wanderTarget;

	public bool keepInRange;
	private float _angleInDegrees;
	private float _newAngleTimer;
	public float speed = 1;
	private float _osc;
	public float wanderRange = 10;
	public float steerForceMultiplier = 1f;
	private Vector3 _desiredVel;
	private Vector3 _steer;
	public float maxSpeed = 2f;

	public GameObject wanderTarget;
	public bool exploded = false;
	public bool resumeWander = false;

	[HideInInspector] public ITurtleBabyState currentState;
	[HideInInspector] public TurtleBabyWanderState wanderState;
	[HideInInspector] public TurtleBabyFollowState followState;
	[HideInInspector] public TurtleBabySkidState skidState;


	void Awake() {
		wanderState = new TurtleBabyWanderState (this);
		followState = new TurtleBabyFollowState (this);
		skidState = new TurtleBabySkidState (this);
	}

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		currentState = wanderState;


		turtleLight = GetComponent<Light> ();
		_wahAudioSource = GetComponent<AudioSource> ();
		rb2D = GetComponent<Rigidbody2D> ();
		_turtleRotateAndAnimate = GetComponent<TurtleRotateAndAnimate> ();
//		_turtleRotateAndAnimate.isSkidding = false;
		keepInRange = true;
		followTurtle = false;
//		lightOn (true);
	}
	
	// Update is called once per frame
	void Update () {
		currentState.UpdateState ();
//		KeepInWanderRange();
//		if (followTurtle) {
//			maxSpeed = 4f;
//			followObject(positionToFollow);
//		} else {
//
//			if (!exploded) {
//				StartCoroutine(explode());
//				exploded = true;
//			}
//
//			if (resumeWander) {
//				print ("wandering");
//				maxSpeed = 2f;
//				followObject(wanderTarget.transform);
//				OscillateHalo(3f,1f);
//			}
//		}
	}

	void followObject(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		if (moveTo.magnitude > .2f) {	
			rb2D.velocity = moveTo * maxSpeed;
		} else {
			rb2D.velocity = Vector2.zero;
		} 
	}

	public void lightOn(bool isOn) {
		turtleLight.enabled = isOn;
	}

	void OscillateHalo(float haloOscillationSpeed, float haloOscillationScale) {
		_osc = Mathf.Sin (Time.time * haloOscillationSpeed) * haloOscillationScale +2f;
		turtleLight.range = _osc;
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		currentState.OnTriggerEnter2D (coll);
	}

//	void KeepInWanderRange() {
//		if (transform.localPosition.x > wanderRange) {
//			_desiredVel = new Vector3 (-speed, rb2D.velocity.y);
//		}
//		
//		if (transform.localPosition.x < -wanderRange) {
//			_desiredVel = new Vector3 (speed, rb2D.velocity.y);
//		} 
//		
//		if (transform.localPosition.y > wanderRange) {
//			_desiredVel = new Vector3 (rb2D.velocity.y, -speed);
//		}
//		
//		if (transform.localPosition.y < -wanderRange) {
//			_desiredVel = new Vector3 (rb2D.velocity.y, speed);
//		}
//	}


}
