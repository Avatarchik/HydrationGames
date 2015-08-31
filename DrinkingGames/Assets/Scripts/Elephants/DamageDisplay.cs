using UnityEngine;
using System.Collections;
using TMPro;

public class DamageDisplay : MonoBehaviour {

	public TextMeshPro text; 
	private float timeToFade;

	// Use this for initialization
	void Start () {

		text = GetComponent <TextMeshPro> ();
		timeToFade = 1f;
		StartCoroutine (fadeAndDestroy (0, timeToFade));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
//	IEnumerator FadeTo(float aValue, float aTime)
//	{
//		float alpha = transform.renderer.material.color.a;
//		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
//		{
//			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
//			transform.renderer.material.color = newColor;
//			yield return null;
//		}
//	}



	IEnumerator fadeAndDestroy(float aValue, float aTime) {

		yield return new WaitForSeconds (.2f);

		float alpha = text.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
			Color newColor = new Color (text.color.r, text.color.g, text.color.b, Mathf.Lerp (alpha,aValue,t));
			text.color = newColor;
			yield return null;
		}
		Destroy (gameObject);
	}
	
}
