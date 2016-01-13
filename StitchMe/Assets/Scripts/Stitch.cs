using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stitch : MonoBehaviour {

	[SerializeField] private Toggle _toggle;
	[SerializeField] private Image _checkmark;

	public StitchGrid stitchGrid;
	public Color color;

	public enum StitchType {None, TopLeftBottonRight, BottomLeftTopRight, Both};
	public StitchType stitchType;


	// Use this for initialization
	void Start () {
//		string json = JsonUtility.ToJson(this);
//		print (json);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setStitch() {

		_checkmark.sprite = stitchGrid.selectedStitch;
		_checkmark.color = stitchGrid.selectedColor;
	}
}
