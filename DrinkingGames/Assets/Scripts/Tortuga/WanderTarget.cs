using UnityEngine;
using System.Collections;

public class WanderTarget : MonoBehaviour {

	public GameObject turtle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround (turtle.transform.position, Vector3.back, 30 * Time.deltaTime);
	}
}
