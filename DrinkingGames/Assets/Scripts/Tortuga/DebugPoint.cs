using UnityEngine;
using System.Collections;

public class DebugPoint : MonoBehaviour {
	public Rigidbody2D _rb2D;
	public GameObject target;
	Vector2 moveTo;
	// Use this for initialization
	void Start () {
		_rb2D = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
		followTurtle(target.transform);
	}

	
	void followTurtle(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		_rb2D.velocity = moveTo * 5f;
		
	}
}
