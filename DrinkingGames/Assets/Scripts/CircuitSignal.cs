using UnityEngine;
using System.Collections;

public class CircuitSignal : MonoBehaviour {
	
	public float countdown;
	private SpriteRenderer[] _spriteRenderers;
	// Use this for initialization
	void Start () {
		_spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

		changeSpritesEnabled (false);


	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0) {
			changeSpritesEnabled(true);
		} else {
			changeSpritesEnabled(false);
		}
		
	}

	public void changeSpritesEnabled(bool enable) {
		foreach (SpriteRenderer sr in _spriteRenderers) {
			sr.enabled = enable;
		}
	}
}
