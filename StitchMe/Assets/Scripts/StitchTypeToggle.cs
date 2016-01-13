using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StitchTypeToggle : MonoBehaviour {

	[SerializeField] private Toggle _toggle;
	[SerializeField] private Image _stitchImage;
	[SerializeField] private StitchGrid _stitchGrid;

	void Start() {
		setSelectedStitchImage();
	}


	public void setSelectedStitchImage() {

		if (_toggle.isOn) {
			_stitchGrid.selectedStitch = _stitchImage.sprite;
		}
	}
}
