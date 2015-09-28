using UnityEngine;
using System.Collections;

public class TurtleBaby : TurtleScript {

	private Light _light;
	private AudioSource _wahAudioSource;
	private Animator _animator;
	public BabyContainer babyContainer;
	public bool followTurtle = false;
	public bool wander = false;
	public Transform positionToFollow;
	public Rigidbody2D _rb2D;
	public Vector2 moveTo;
	public Transform followPosition;
	private TurtleRotateAndAnimate _turtleRotateAndAnimate;

	public CircleCollider2D wanderTarget;

	public bool keepInRange;
	private float _angleInDegrees;
	private float _newAngleTimer;
	public float speed = 1;
	private float _osc;
	public float wanderRange = 10;
	public float steerForceMultiplier = 1f;
	private Vector3 _desiredVel;
	private Vector3 _steer;
	private float _maxSpeed = 4f;

	public GameObject debugPoint;
	public bool exploded = false;
	public bool resumeWander = false;

	// Use this for initialization
	void Start () {
		_light = GetComponent<Light> ();
		_wahAudioSource = GetComponent<AudioSource> ();
		_animator = GetComponent<Animator> ();
		_rb2D = GetComponent<Rigidbody2D> ();
		_turtleRotateAndAnimate = GetComponent<TurtleRotateAndAnimate> ();
		_turtleRotateAndAnimate.isSkidding = true;
		keepInRange = true;
		followTurtle = false;
		lightOn (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (followTurtle) {
			_maxSpeed = 4f;
			followObject(positionToFollow);
		} else {

			if (!exploded) {
				StartCoroutine(explode());
				exploded = true;
			}

			if (resumeWander) {
				print ("wandering");
				_maxSpeed = 2f;
				followObject(debugPoint.transform);
				OscillateHalo(3f,1f);
			}
		}
	}

	void followObject(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		if (moveTo.magnitude > .2f) {	
			_rb2D.velocity = moveTo * _maxSpeed;
		} else {
			_rb2D.velocity = Vector2.zero;
		} 
	}

	public void lightOn(bool on) {
		_light.enabled = on;
	}

	
	void OscillateHalo(float haloOscillationSpeed, float haloOscillationScale) {
		_osc = Mathf.Sin (Time.time * haloOscillationSpeed) * haloOscillationScale +2f;
		_light.range = _osc;
	}

	IEnumerator explode() {
		float angle = Random.Range (0,360);
		float x = 5 * Mathf.Cos (angle * Mathf.PI/180) + transform.position.x;
		float y = 5 * Mathf.Sin (angle * Mathf.PI/180) + transform.position.y;
		float testX = x-transform.position.x;
		float testY = y-transform.position.y;
		_rb2D.AddForce(new Vector2 ((x-transform.position.x), (y-transform.position.y)), ForceMode2D.Impulse);
		_rb2D.AddTorque (20f, ForceMode2D.Impulse);
		yield return new WaitForSeconds (1f);
		_rb2D.velocity = Vector2.zero;
		_rb2D.angularVelocity = 0f;
		_rb2D.drag = 0f;
		_rb2D.angularDrag = 0.05f;
		_turtleRotateAndAnimate.isSkidding = false;
		resumeWander = true;

	}

//	void KeepInWanderRange() {
//		if (transform.localPosition.x > wanderRange) {
//			_desiredVel = new Vector3 (-speed, _rb2D.velocity.y);
//		}
//		
//		if (transform.localPosition.x < -wanderRange) {
//			_desiredVel = new Vector3 (speed, _rb2D.velocity.y);
//		} 
//		
//		if (transform.localPosition.y > wanderRange) {
//			_desiredVel = new Vector3 (_rb2D.velocity.y, -speed);
//		}
//		
//		if (transform.localPosition.y < -wanderRange) {
//			_desiredVel = new Vector3 (_rb2D.velocity.y, speed);
//		}
//	}


}
