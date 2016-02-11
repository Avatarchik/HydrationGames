using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour {

	[SerializeField] private Light candleFlameLight;
	float _lightRange;
	float p;
	// Use this for initialization
	void Start () {
		StartCoroutine(flickerLight());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator flickerLight() {
		p++;
//		_lightRange = Mathf.PerlinNoise(p,p)*10f;
//		candleFlameLight.range = _lightRange;
		candleFlameLight.range = Random.Range(1, 1.25f);
		yield return new WaitForSeconds(.05f);
		StartCoroutine(flickerLight());
	}
}
