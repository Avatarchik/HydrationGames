using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	private Vector3 _slowRotateSpeed;
	private Vector3 _fastRotateSpeed;
	private Vector3 _rotateSpeed;
	private Vector3 _originalScale;
	private Vector3 _bigScale;
	private bool _isOpen = false;

	// Use this for initialization
	void Start () {
		_originalScale = transform.localScale;
		_bigScale = _originalScale * 2.5f;
		_slowRotateSpeed = new Vector3 (0f, 0f, Time.deltaTime * -360);
		_fastRotateSpeed = _slowRotateSpeed * 1.5f;
		_rotateSpeed = _slowRotateSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (_rotateSpeed);
	
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "TurtleParent") {
			if (_isOpen) {
				takeTurtle(coll.gameObject);
				foreach (GameObject turtleBaby in coll.gameObject.GetComponent<TurtleBabyTracker>().babiesOnBoard) {
					takeTurtle(turtleBaby);
				}
				StartCoroutine(loadScoreboardScene(1f));
			}
		}
	}

	public void setToOpen() {
		_isOpen = true;
		_rotateSpeed = _fastRotateSpeed;
		LeanTween.scale (gameObject, _bigScale, 2.5f).setEase (LeanTweenType.easeOutSine);
	}

	public void setToClosed() {
		_isOpen = false;
		_rotateSpeed = _slowRotateSpeed;
		LeanTween.scale (gameObject, _originalScale, .5f).setEase (LeanTweenType.easeOutSine);
	}

	void takeTurtle(GameObject turtle) {
		LeanTween.move (turtle, transform.position, 1f);
		LeanTween.scale (turtle, Vector3.zero, 1f);
	}

	IEnumerator loadScoreboardScene(float delay) {
		yield return new WaitForSeconds(delay);
		Application.LoadLevel ("TortugaScoreboard");
	}

}
