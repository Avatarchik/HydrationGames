using UnityEngine;
using System.Collections;

public class DelayedDestroy : MonoBehaviour {

	public float seconds;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, seconds);
	}
	

}
