using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IconAlphaUI : MonoBehaviour {

	[SerializeField] CircuitSignalUI _circuitSignalUI;
	[SerializeField] private Image _image;

	public Color originalColor;
	private Color fadedColor;
	public string input;

	//	
	// Use this for initialization
	void Start () {
		fadedColor = new Color (originalColor.r, originalColor.g, originalColor.b, .3f);
	}

	// Update is called once per frame
	void Update () {

		//		if (Input.GetKey(input)) {
		//			circuitSignal.countdown = 5;
		//			_spriteRenderer.color = originalColor;
		//		} else {
		//			_spriteRenderer.color = fadedColor;
		//		}

	}

	public void turnOn() {
		_circuitSignalUI.countdown = 5;
		_image.color = originalColor;
	}

	public void turnOff() {
		_image.color = fadedColor;

	}
}
