using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private Slider _slider;
	public Image fillImage;
	public Color normalColor;

	// Use this for initialization
	void Start () {
		_slider = GetComponent<Slider> ();
	
	}

	public void matchPlayerHealth(int health) {
		_slider.value = health;
	}

	public void setColor(Color c) {
		fillImage.color = c;
	}

}
