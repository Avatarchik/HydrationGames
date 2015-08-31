using UnityEngine;
using System.Collections;

public class IconAlpha : MonoBehaviour {

	public CircuitSignal circuitSignal;
	private SpriteRenderer _spriteRenderer;

	public Color originalColor;
	private Color fadedColor;
	public string input;

//	
	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
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
		circuitSignal.countdown = 5;
		_spriteRenderer.color = originalColor;
	}

	public void turnOff() {
		_spriteRenderer.color = fadedColor;

	}
}
