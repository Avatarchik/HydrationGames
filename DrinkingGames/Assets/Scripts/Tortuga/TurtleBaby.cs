using UnityEngine;
using System.Collections;

public class TurtleBaby : TurtleScript {

	private Light _light;
	private AudioSource _wahAudioSource;
	private Animator _animator;
	public BabyContainer babyContainer;
	public bool followTurtle = false;
	public bool wander = false;
	public bool skidSpin = false;
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

	public GameObject debugPoint;

	// Use this for initialization
	void Start () {
		_light = GetComponent<Light> ();
		_wahAudioSource = GetComponent<AudioSource> ();
		_animator = GetComponent<Animator> ();
		_rb2D = GetComponent<Rigidbody2D> ();
		wanderTarget.GetComponent<WanderTarget>().setContainerPosition();

		keepInRange = true;
		followTurtle = false;
		_rotateSpeed = new Vector3 (0f, 0f, Time.deltaTime * 360f);
		lightOn (true);
		//StartCoroutine(skidToWanderTarget());

	}
	
	// Update is called once per frame
	void Update () {
		if (followTurtle) {
			followObject(positionToFollow);
		} else {
			StartCoroutine(skidToWanderTarget());
			if (wander) {
				followObject(wanderTarget.transform);
				OscillateHalo(3f,1f);
			}
		}
	}

	void followObject(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		_rb2D.velocity = moveTo * 5f; //*Time.deltatime
	}

	public IEnumerator skidToWanderTarget() {

		_rb2D.AddForce ((wanderTarget.transform.position - gameObject.transform.position).normalized * .1f, ForceMode2D.Impulse);

		while (Vector2.Distance(gameObject.transform.position, wanderTarget.transform.position) > .5f) {
			transform.Rotate(Vector3.back, 360*Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}

		yield return null;
		wander = true;
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
