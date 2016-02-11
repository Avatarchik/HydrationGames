
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject following;
	public float baseCameraSize = 20f;
	public float maxCameraSize = 60f;
	public float verticalOffset = 12f;
	public float cameraSpeedX = 2.0f;
	public float cameraSpeedY = 1.0f;
	public float maxDistanceAwayFromFollowingX = 7;
	public float maxDistanceAwayFromFollowingY = 7;
	public float lowerFollowLimit = 0;

	private Transform _t;
	private Camera _c;
	private bool isFollowing = true;
	private float verticalBufferSpace = 10f;


	//shaky stuff
	private float xShakeOffset = 0f;
	private float yShakeOffset = 0f;
	private bool isShaking = false;
	public float duration = 0.2f;
	public float magnitude = 1f;

//	void OnEnable()
//	{
//		PauseGame.GamePaused += shouldntFollow;
//		PauseGame.GameUnpaused += shouldFollow;
//	}
//
//	void OnDisable()
//	{
//		PauseGame.GamePaused -= shouldntFollow;
//		PauseGame.GameUnpaused -= shouldFollow;
//	}

	void shouldntFollow()
	{
		isFollowing = false;
	}

	void shouldFollow()
	{
		isFollowing = true;
	}

	// Use this for initialization
	void Start () {
		if (following != null)
			_t = following.transform;

		_c = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {

		if (_t == null && following != null)
		{
			_t = following.transform;
		}

		if (_t != null && isFollowing == true)
		{
			Vector3 pos = new Vector3(_t.position.x, _t.position.y + verticalOffset , transform.position.z);
			Vector3 diff = (pos - transform.position) * Time.deltaTime;

			// clamp distance away
			diff.x *= cameraSpeedX;
			diff.y *= cameraSpeedY;

			// dampen towards
			Vector3 newPos = transform.position + diff;

			if (newPos.x - pos.x > maxDistanceAwayFromFollowingX)
				newPos.x = pos.x + maxDistanceAwayFromFollowingX;
			else if (newPos.x - pos.x < -maxDistanceAwayFromFollowingX)
				newPos.x = pos.x - maxDistanceAwayFromFollowingX;

			if (newPos.y - pos.y > maxDistanceAwayFromFollowingY)
				newPos.y = pos.y + maxDistanceAwayFromFollowingY;
			else if (newPos.x - pos.x < -maxDistanceAwayFromFollowingY)
				newPos.y = pos.y - maxDistanceAwayFromFollowingY;


			// Shake
			newPos.x += xShakeOffset;
			newPos.y += yShakeOffset;

			if(newPos.y >= lowerFollowLimit)
				transform.position = pos;
			else
				transform.position = new Vector3(newPos.x, lowerFollowLimit, newPos.z);

			if(_t.position.y + verticalBufferSpace <= baseCameraSize)
			{
				_c.orthographicSize = baseCameraSize;
			}
			else if(_t.position.y + verticalBufferSpace > baseCameraSize && _t.position.y + verticalBufferSpace <= maxCameraSize)
			{
				_c.orthographicSize = _t.position.y + verticalBufferSpace;
			}
			else{
				_c.orthographicSize = maxCameraSize;
			}
		}
	}

	public void ShakeCamera(){
		if(!isShaking)
			StartCoroutine("Shake");
	}

	public void ShakeCamera(float duration)
	{
		this.duration = duration;
		if(!isShaking)
			StartCoroutine("Shake");
	}

	IEnumerator Shake() {

		float elapsed = 0.0f;

		isShaking = true;
		while (elapsed < duration) {

			elapsed += Time.deltaTime;          

			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			//			float x = Random.value * 2.0f - 1.0f;
			float x = Mathf.PerlinNoise(elapsed / 10f, 0.0f);
			float y = Mathf.PerlinNoise(0.0f, elapsed / 10f);
			//			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;

			xShakeOffset = x;
			yShakeOffset = y;

			yield return null;
		}
		isShaking = false;
		xShakeOffset = 0;
		yShakeOffset = 0;

		//        Camera.main.transform.position = originalCamPos;
	}
}
