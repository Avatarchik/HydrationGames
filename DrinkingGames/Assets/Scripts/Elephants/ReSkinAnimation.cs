using UnityEngine;
using System;
using System.Collections;

public class ReSkinAnimation : MonoBehaviour {

	public string spriteSheetName;

	// Use this for initialization
	void Start () {

	
	}

	void LateUpdate() {
		var subSprites = Resources.LoadAll<Sprite>(spriteSheetName);
		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>()) {
			string spriteName = renderer.sprite.name;
			var newSprite = Array.Find(subSprites, item => item.name == spriteName);
			if (newSprite)
				renderer.sprite = newSprite;
		}
	}
}
