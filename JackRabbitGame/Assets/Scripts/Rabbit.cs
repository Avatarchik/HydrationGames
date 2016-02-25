using UnityEngine;
using System.Collections;

public class Rabbit : MonoBehaviour {
	[SerializeField] private MusicManager _musicManager;
	[SerializeField] private Rigidbody2D _rb2D;
	[SerializeField] private Animator _animator;


	public float maxVelocity = 10f;
	private int _jumpCount = 0;


	// Use this for initialization
	void Start () {
		maxVelocity = 10f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.RightArrow)) {
			if (_rb2D.velocity.x < maxVelocity) {
				_rb2D.AddForce(new Vector2 (2f, 0f), ForceMode2D.Impulse);
			}
			_animator.SetBool("Running", true);
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			if (_rb2D.velocity.x > -maxVelocity) {
				_rb2D.AddForce(new Vector2 (-2f, 0f), ForceMode2D.Impulse);
			}
			_animator.SetBool("Running", true);
		} else {
			_animator.SetBool("Running", false);
		}
	
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (_jumpCount == 0){
				
				_rb2D.AddForce(new Vector2(4f, 7f), ForceMode2D.Impulse);
				_animator.SetBool("Jumping", true);
				_jumpCount++;
			}
		} else {
			_animator.SetBool("Jumping", false);
		}

		faceDirectionOfMovement();
		

	}



	public void faceDirectionOfMovement() {
		if (_rb2D.velocity.x > 0.1f) {
			transform.rotation = Quaternion.Euler(Vector3.zero);
		} else if (_rb2D.velocity.x < -0.1f) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			_jumpCount = 0;
		}
	}
}
