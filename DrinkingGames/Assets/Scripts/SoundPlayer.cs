using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void playLoopingSound(AudioSource aSource) {
		if (!aSource.isPlaying) {
			aSource.Play ();
		}
	}

	public void stopSound(AudioSource aSource) {
		aSource.Stop ();
	}
}
