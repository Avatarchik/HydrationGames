using UnityEngine;
using System.Collections;

public class MatchBoatRotation : MonoBehaviour {
	
	public Transform boat;

	// Update is called once per frame
	void Update () {
		var targetRot = boat.transform.eulerAngles;
		gameObject.transform.eulerAngles = targetRot;
		
		
	}
}