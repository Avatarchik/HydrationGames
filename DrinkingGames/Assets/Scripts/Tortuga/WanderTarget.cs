using UnityEngine;
using System.Collections;

public class WanderTarget : MonoBehaviour {

	public GameObject turtle;
	public float angle = 0;
	float x= 0;
	float y = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		angle+=1f;
		if (angle > 360) {
			angle = 0;
		}

		float perlin = Mathf.PerlinNoise(Time.fixedTime,Time.fixedTime+1000);

		x = Mathf.Cos (angle * Mathf.PI/180f) + 2f;
		y = Mathf.Sin (angle * Mathf.PI/180f) + 2f;

		transform.position = new Vector2(x+perlin,y+perlin);
//		transform.RotateAround (turtle.transform.position, Vector3.back, 30 * Time.deltaTime);
	}

//	Vector3 getWanderPos() {
//		float x = (float)(wanderTarget.radius * Mathf.Cos(_angleInDegrees * Mathf.PI / 180F)) + wanderTarget.transform.position.x;
//		float y = (float)(wanderTarget.radius * Mathf.Sin(_angleInDegrees * Mathf.PI / 180F)) + wanderTarget.transform.position.y;
//		
//		
//		Vector3 pos = new Vector3 (x, y);
//		debugPoint.transform.position = pos;		
//		return pos;
//	}

}
