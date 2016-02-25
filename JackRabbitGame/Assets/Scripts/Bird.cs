using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + (new Vector3(0f, 0.1f));
	}
}
