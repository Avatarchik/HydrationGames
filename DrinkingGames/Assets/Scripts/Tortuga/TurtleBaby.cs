using UnityEngine;
using System.Collections;

public class TurtleBaby : TurtleScript {

	private Light _light;
	private AudioSource _wahAudioSource;
	private Animator _animator;
	public BabyContainer babyContainer;
	public bool followTurtle = false;
	public bool wander = false;
	private bool skidCoroutineRunning = false;
	public Transform positionToFollow;
	private Vector3 _rotateSpeed;
	public Rigidbody2D _rb2D;
	public Vector2 moveTo;
	public Transform followPosition;

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

	// Use this for initialization
	void Start () {
		_light = GetComponent<Light> ();
		_wahAudioSource = GetComponent<AudioSource> ();
		_animator = GetComponent<Animator> ();
		_rb2D = GetComponent<Rigidbody2D> ();

		keepInRange = true;
		followTurtle = false;
		_rotateSpeed = new Vector3 (0f, 0f, Time.deltaTime * 360f);
		lightOn (true);
		//StartCoroutine(skidToWanderTarget());

	}
	
	// Update is called once per frame
	void Update () {
		if (followTurtle) {
			_maxSpeed = 4f;
			followObject(positionToFollow);
		} else {
			if (!wander && !skidCoroutineRunning) {
				StartCoroutine(skidToWanderTarget());
			} else {
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

	public IEnumerator skidToWanderTarget() {
		skidCoroutineRunning = true;
		Vector3 randomPosition = new Vector3 (Random.Range (-3f,3f), Random.Range(-3f,3f));
		Debug.DrawLine (transform.position, randomPosition, Color.red, 20f);

//		LeanTween.move (gameObject,randomPosition,1f);
		_rb2D.AddForce ((randomPosition - gameObject.transform.position).normalized * 4f, ForceMode2D.Impulse);

		while (Vector2.Distance(gameObject.transform.position, randomPosition) > .5f) {
			transform.Rotate(Vector3.back, 360*Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}

		yield return null;
		wander = true;
		skidCoroutineRunning = false;

	}

	public void lightOn(bool on) {


			_light.enabled = on;
	

	}

	
	void OscillateHalo(float haloOscillationSpeed, float haloOscillationScale) {
		_osc = Mathf.Sin (Time.time * haloOscillationSpeed) * haloOscillationScale +2f;
		_light.range = _osc;
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
