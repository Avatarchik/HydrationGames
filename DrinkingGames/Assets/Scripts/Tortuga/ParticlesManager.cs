using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour {

	public int timeToLive;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeToLive);
	}




}
