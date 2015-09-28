using UnityEngine;
using System.Collections;

public class WanderTarget : MonoBehaviour {

	public GameObject wanderTargetContainer;
	public GameObject debugPoint;
	public CircleCollider2D wanderTargetCollider;

	private Rigidbody2D _rb2D;
	public GameObject turtle;
	public float angle = 0;

	private bool resettingPos = false;
	float x= 0;
	float y = 0;
	private float _perlin1;
	private float _perlin2;
	// Use this for initialization
	void Start () {
		_perlin1 = Random.Range (0f,1000f);
		_perlin2 = Random.Range (0f,1000f);
		wanderTargetCollider = GetComponent<CircleCollider2D> ();
		_rb2D = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

//		if (!resettingPos) {

			float perlin = Mathf.PerlinNoise(Time.fixedTime+_perlin1,Time.fixedTime+_perlin2);
			float clampedPerlin = ExtensionMethods.Remap(perlin, 0f,1f,-1f,1f) * 4f;

			angle+= clampedPerlin;
			if (angle > 360) {
				angle = 0;
			}

			x = Mathf.Cos (angle * Mathf.PI/180f) * wanderTargetCollider.radius;
			y = Mathf.Sin (angle * Mathf.PI/180f) * wanderTargetCollider.radius;
	
			//float clampedPerlin = ExtensionMethods.Remap(perlin, 0f,1f,-1f,1f) *  .2f;

			debugPoint.transform.localPosition = new Vector2(x,y);
//		}
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
