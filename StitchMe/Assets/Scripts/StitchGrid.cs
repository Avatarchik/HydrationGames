using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StitchGrid : MonoBehaviour {

	[SerializeField] private RectTransform _rectTransform;
	[SerializeField] private GameObject _stitchPrefab;
	[SerializeField] private List<GameObject> _stitches;
	private const float _stitchSize = 20f;

	public Sprite bottomLeftTopRightCheckmark;
	public Sprite topLeftBottomRightCheckmark;
	public Sprite xCheckmark;
	public Sprite selectedStitch;
	public Color selectedColor;

	[SerializeField] private InputField _horizontalInput;
	[SerializeField] private InputField _verticalInput;

	// Use this for initialization
	void Start () {
	
	}

	public void makeGrid() {
		int numHorizontalSquares  = int.Parse(_horizontalInput.text);
		int numVerticalSquares = int.Parse(_verticalInput.text);
		int totalSquares = numHorizontalSquares * numVerticalSquares;

		_rectTransform.sizeDelta = new Vector2( numHorizontalSquares * _stitchSize, numVerticalSquares * _stitchSize) ;

		for (int i = 0; i < totalSquares; i++) {
			GameObject stitchSquare = Instantiate(_stitchPrefab, transform.position, Quaternion.identity) as GameObject;
			stitchSquare.GetComponent<Stitch>().stitchGrid = this;
			stitchSquare.transform.SetParent(transform);
			_stitches.Add(stitchSquare);
		}

	}


	public void setStitchSprite(string stitchType) {

		switch (stitchType) {
			case "x":
			print ("x");
				selectedStitch = bottomLeftTopRightCheckmark;
				break;
		
			case "bottomLeftTopRight":
			print ("bltr");
				selectedStitch = bottomLeftTopRightCheckmark;
				break;
			
			case "topLeftBottomRight":
			print ("tlbr");
				selectedStitch = bottomLeftTopRightCheckmark;
				break;

		}
		
	}

}
