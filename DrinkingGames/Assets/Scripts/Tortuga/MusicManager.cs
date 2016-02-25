using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {


	[SerializeField] private AudioSource _audSource1;
	[SerializeField] private AudioSource _audSource2;
	[SerializeField] private AudioSource _audSource3;
	[SerializeField] private AudioSource _audSource4;
	[SerializeField] private AudioSource _audSource5;
	[SerializeField] private AudioSource _currentAudSource;

	public int prevHighestScore;
	public int highestScore;
	public bool switchingClip = false;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		_currentAudSource = _audSource1;
	}
	
	// Update is called once per frame
	void Update () {

		if (switchingClip) {

			switch (highestScore) {
			case 1: 
				SwitchClip (_currentAudSource, _audSource2);
				break;
			case 2: 		
				SwitchClip (_currentAudSource, _audSource3);
				break;
			case 3: 
				SwitchClip (_currentAudSource, _audSource4);
				break;
			case 4: 
				SwitchClip (_currentAudSource, _audSource5);
				break;
			case 5:
				SwitchClip (_currentAudSource, _audSource1);
				break;
			}

		}

	}

	void SwitchClip(AudioSource currAudSource, AudioSource nextAudSource) {
		currAudSource.loop = false;
		if (currAudSource.time >= currAudSource.clip.length - 0.01f) {
			print ("CLIP SWITCHED!");
			currAudSource.volume = 0;
			nextAudSource.volume = 1;
			currAudSource.loop = true;
			_currentAudSource = nextAudSource;
			switchingClip = false;
		}
	}

}



