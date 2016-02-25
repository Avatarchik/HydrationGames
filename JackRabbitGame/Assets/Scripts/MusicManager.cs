using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	[SerializeField] private AudioSource _audSource;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "Rabbit") {
			if (!_audSource.isPlaying) {
				_audSource.Play(); 
			}
		}
	}
}
