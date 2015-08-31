using UnityEngine;
using System.Collections;

public class ResetBoatPosition : MonoBehaviour {

	public GameObject blueBoat;
	public GameObject greenBoat;
	public Vector3 blueOrigPosition;
	public Vector3 greenOrigPosition;

	// Use this for initialization
	void Start () {
		blueOrigPosition = blueBoat.transform.position;
		greenOrigPosition = greenBoat.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			blueBoat.transform.position = blueOrigPosition;
			greenBoat.transform.position = greenOrigPosition;
		}
	
	}

	void OnMouseDown() {
		blueBoat.transform.position = blueOrigPosition;
		greenBoat.transform.position = greenOrigPosition;
	}
}
