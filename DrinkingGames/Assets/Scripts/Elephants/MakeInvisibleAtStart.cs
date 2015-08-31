using UnityEngine;
using System.Collections;

public class MakeInvisibleAtStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().enabled = false;
	}

}
