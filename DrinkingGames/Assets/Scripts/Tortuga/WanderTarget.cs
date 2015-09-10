using UnityEngine;
using System.Collections;

public class WanderTarget : MonoBehaviour {

	public GameObject wanderTargetContainer;
	private Rigidbody2D _rb2D;
	public GameObject turtle;
	public float angle = 0;
	private bool resettingPos = false;
	float x= 0;
	float y = 0;
	// Use this for initialization
	void Start () {
		_rb2D = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (!resettingPos) {
			
			angle+=1f;
			if (angle > 360) {
				angle = 0;
			}

			float perlin = Mathf.PerlinNoise(Time.fixedTime,Time.fixedTime+1000);
			x = Mathf.Cos (angle * Mathf.PI/180f) + 0f;
			y = Mathf.Sin (angle * Mathf.PI/180f) + 0f;
	
			float clampedPerlin = ExtensionMethods.Remap(perlin, 0f,1f,-1f,1f) *  .2f;

			transform.localPosition = new Vector2(x+clampedPerlin,y+clampedPerlin);
		}
//		transform.RotateAround (turtle.transform.position, Vector3.back, 30 * Time.deltaTime);
	}

	public void setContainerPosition() {
		Vector2 newPos = new Vector2(Random.Range(-5f,5f), Random.Range (-3f,3f));
		wanderTargetContainer.transform.position = newPos;

	}

//	public IEnumerator resetPosition(Vector3 pos) {
//		resettingPos = true;
//		print ("reseting to: " + pos);
//		transform.position = pos;
//		yield return new WaitForSeconds(0.014f);
//		resettingPos = false;
//
//	}

}
