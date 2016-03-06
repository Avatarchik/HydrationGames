using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CircuitSignalUI : MonoBehaviour {

	public float countdown;
	[SerializeField] private Image _image;

	// Use this for initialization
	void Start () {
		showSignal (false);
	}

	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0) {
			showSignal(true);
		} else {
			showSignal(false);
		}

	}

	public void showSignal(bool isEnabled) {
		_image.enabled = isEnabled;
	}
}
