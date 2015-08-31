using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

	public float waterLevel =  0f;
	float floatHeight = 2f;
	float bounceDamp = 0.05f;
	Vector3 bouyancyCenterOffset;
	Vector3 gravityZ;

	float forceFactor;
	Vector3 actionPoint;
	Vector3 upLift;

	Rigidbody rigidBody;



	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0f,0f,-9.8f);
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {


		actionPoint = transform.position + transform.TransformDirection (bouyancyCenterOffset);
		forceFactor = 1f - ((actionPoint.z - waterLevel)/ floatHeight);
		//forceFactor = 1f - ((actionPoint.y - waterLevel)/ floatHeight);
		rigidBody.AddForceAtPosition (gravityZ, actionPoint);

		if (forceFactor  > 0f) {
			float bOffset = Random.Range (-.02f, .02f);
			bouyancyCenterOffset = new Vector3 (bOffset, 0f, 0f);
			upLift = -Physics.gravity * (forceFactor - rigidBody.velocity.z * bounceDamp);
			rigidBody.AddForceAtPosition(upLift, actionPoint);
		}
	}
}
