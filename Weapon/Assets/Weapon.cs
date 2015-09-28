using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	private Gyroscope gyro;
	// Use this for initialization
	void Start () {
		if (SystemInfo.supportsGyroscope) {
			gyro = Input.gyro;
			gyro.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
		transform.rotation = Input.gyro.attitude;

	}
}
