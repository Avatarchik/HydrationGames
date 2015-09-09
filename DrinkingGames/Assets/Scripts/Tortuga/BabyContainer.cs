using UnityEngine;
using System.Collections;

public class BabyContainer : MonoBehaviour {

	Vector2 moveTo;
	Rigidbody2D _rb2D;

	// Use this for initialization
	void Start () {
		_rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void follow(Transform posToFollow) {
		moveTo = posToFollow.position - transform.position;
		_rb2D.velocity = moveTo * 5f;
		
	}
}
