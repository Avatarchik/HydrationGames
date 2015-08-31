using UnityEngine;
using System.Collections;

public class LoopScreen : MonoBehaviour {

	public float screenWrapX = 22;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		LoopXAxis();
	}

	public void LoopXAxis() {
		if (transform.position.x < -screenWrapX) {
			transform.position = new Vector3(screenWrapX,transform.position.y,transform.position.z);
		} else if (transform.position.x > screenWrapX) {
			transform.position = new Vector3(-screenWrapX,transform.position.y,transform.position.z);
		}
	}
}
