using UnityEngine;
using System.Collections;

public class TortugaWave : MonoBehaviour {


	[Range(0.01f, 0.05f)] public float A;
	[Range(.5f, 1.2f)] public float B;
	[Range(0.0f, 10.0f)] public float C;
	[Range(0.0f, 10.0f)] public float D;
	[Range(.01f,1f)] public float ampScale;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		float offset = A * Mathf.Cos(B*Time.time + C) + D; 
		transform.position = new Vector2(transform.position.x, transform.position.y +  A * ampScale * Mathf.Cos(Time.time*B + C));
	}
}
