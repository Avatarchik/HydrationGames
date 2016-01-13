using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public Camera stitchCamera;

	private bool _doZoomIn = false;
	private bool _doZoomOut = false;
	private bool _doMoveUp = false;
	private bool _doMoveDown = false;
	private bool _doMoveLeft = false;
	private bool _doMoveRight = false;


	private float _moveSpeed = .2f;

	void Update() {
		
		if (_doZoomIn) {
			zoomIn();
		}

		if (_doZoomOut) {
			zoomOut();
		}

		if (_doMoveUp) {
			moveUp();
		}

		if (_doMoveDown) {
			moveDown();
		}

		if (_doMoveLeft) {
			moveLeft();
		}

		if (_doMoveRight) {
			moveRight();
		}
	
	}

	public void setZoomIn(bool isTrue) {
		_doZoomIn = isTrue;
	}

	public void setZoomOut(bool isTrue) {
		_doZoomOut = isTrue;
	}

	public void setMoveUp(bool isTrue) {
		_doMoveUp = isTrue;
	}

	public void setMoveDown(bool isTrue) {
		_doMoveDown = isTrue;
	}

	public void setMoveRight(bool isTrue) {
		_doMoveRight = isTrue;
	}

	public void setMoveLeft(bool isTrue) {
		_doMoveLeft = isTrue;
	}

	 void zoomIn() {
		stitchCamera.orthographicSize -= .1f;
	}

	 void zoomOut() {
		stitchCamera.orthographicSize += .1f;
	}

	void moveUp() {
		stitchCamera.transform.position += new Vector3 (0f, .1f);
	}

	void moveDown() {
		stitchCamera.transform.position -= new Vector3 (0f, .1f);
	}

	void moveLeft() {
		stitchCamera.transform.position -= new Vector3 (.1f, 0f);
	}

	void moveRight() {
		stitchCamera.transform.position += new Vector3 (.1f, 0f);
	}



	public void resetCameraPos() {
		
	}

}
