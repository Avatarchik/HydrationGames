using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorToggle : MonoBehaviour {
	[SerializeField] private Toggle _toggle;
	[SerializeField] private StitchGrid _stitchGrid;
	[SerializeField] private Color _stitchColor;

	void Start() {
		setStitchColor();
	}

	public void setStitchColor() {
		if (_toggle.isOn) {
			_stitchGrid.selectedColor = _stitchColor;
		}
	}
}
