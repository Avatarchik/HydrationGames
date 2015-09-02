using UnityEngine;
using System.Collections;

public class TurtleBaby : TurtleScript {

	private AudioSource _wahAudioSource;
	private Animator _animator;
	public bool follow = false;
	public Transform positionToFollow;
	private Vector3 _rotateSpeed;
	public Rigidbody2D _rb2D;
	public Vector2 moveTo;
	public Transform followPosition;

	public CircleCollider2D wanderTarget;

	private float _angleInDegrees;
	private float _newAngleTimer;
	public float speed = 1;
	public bool keepInRange;
	private Vector3 _desiredVel;
	private Vector3 _steer;
	public float wanderRange = 10;
	public float steerForceMultiplier = 1f;
	private float _newAngleCountdown;

	private float minBuffer;
	private float maxBuffer;

	public GameObject debugPoint;



	// Use this for initialization
	void Start () {
		minBuffer = 0f;
		maxBuffer = 30f;
		keepInRange = true;
		_newAngleCountdown = 0.6f;
		_wahAudioSource = GetComponent<AudioSource> ();
		_animator = GetComponent<Animator> ();
		_rb2D = GetComponent<Rigidbody2D> ();
		follow = false;
		_rotateSpeed = new Vector3 (0f, 0f, Time.deltaTime * 360f);
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			followTurtle (positionToFollow);
		} else {
			followTurtle(wanderTarget.transform);
//			wander ();
		}


	}

	void followTurtle(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		_rb2D.velocity = moveTo * 5f;

	}
 	
	public void wander() {
//		moveInCircle (Vector3.zero);
		getNextAngle (_newAngleCountdown);
		steerToTarget ();

		//		StartCoroutine(steerToTarget ());
//		_rb2D.velocity = Vector2.zero;
//		transform.Rotate (_rotateSpeed);
	}

	void steerToTarget() {
//		Vector3 newTargetPos = getWonderPos();
		Vector3 targetPos = getWanderPos();

//		if (!LeanTween.isTweening(debugPoint) {
//			LeanTween.move
//		}

		
		_desiredVel = (targetPos - transform.position).normalized*speed;
		
//		if (keepInRange) {
//			KeepInWanderRange();
//		}


//		LeanTween.value (gameObject,(Vector2)_steer,(Vector2)__steer, .01f);
		_steer = ((Vector2)_desiredVel - _rb2D.velocity);

//		LeanTween.value (gameObject, (Vector2)_rb2D.velocity, (Vector2)_steer, 1f);
		_rb2D.velocity += (Vector2)(_steer*steerForceMultiplier);
	}

	void KeepInWanderRange() {
		if (transform.localPosition.x > wanderRange) {
			_desiredVel = new Vector3 (-speed, _rb2D.velocity.y);
		}
		
		if (transform.localPosition.x < -wanderRange) {
			_desiredVel = new Vector3 (speed, _rb2D.velocity.y);
		} 
		
		if (transform.localPosition.y > wanderRange) {
			_desiredVel = new Vector3 (_rb2D.velocity.y, -speed);
		}
		
		if (transform.localPosition.y < -wanderRange) {
			_desiredVel = new Vector3 (_rb2D.velocity.y, speed);
		}
	}



	void getNextAngle(float timeToCoundown) {
		_newAngleTimer -= Time.deltaTime;

		if (_newAngleTimer <= 0) {
			_angleInDegrees++;
//			if (_angleInDegrees >= 360) {
//				_angleInDegrees = 0;
//			}
			_angleInDegrees = Random.Range (0, 360);
			//_angleInDegrees = Random.Range (minBuffer, maxBuffer);
			_newAngleTimer = timeToCoundown;
		}

		minBuffer+=10;
		maxBuffer+=10;
	}

	Vector3 getWanderPos() {
		float x = (float)(wanderTarget.radius * Mathf.Cos(_angleInDegrees * Mathf.PI / 180F)) + wanderTarget.transform.position.x;
		float y = (float)(wanderTarget.radius * Mathf.Sin(_angleInDegrees * Mathf.PI / 180F)) + wanderTarget.transform.position.y;


		Vector3 pos = new Vector3 (x, y);
		debugPoint.transform.position = pos;		
		return pos;
	}

	void moveInCircle(Vector3 center) {
			Vector3 toCenter = center - transform.position;
		print ("tp center: " + toCenter);
		_rb2D.velocity += (Vector2)toCenter.normalized;
		print ("vel; " + _rb2D.velocity);
		
		//		float angle =0;
//		float speed = (2 * Mathf.PI) / 5; //2*PI in degress is 360, so you get 5 seconds to complete a circle
//		float radius=5;
//		angle += speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
//		float	x = Mathf.Cos(angle)*radius;
//		float y = Mathf.Sin(angle)*radius;
	
	}

}
