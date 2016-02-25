using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class TortugaScoreManager : MonoBehaviour {

	private MusicManager _musicManager; 
	public int blueScore = 0;
	public int greenScore = 0;
	private TextMeshProUGUI scoreText;
	private int _prevHighestScore;
	private int _highestScore;

	void Awake() {
		DontDestroyOnLoad(gameObject);
		_musicManager = GameObject.Find ("MusicManager").GetComponent<MusicManager> ();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int level) {
		if (SceneManager.GetActiveScene().name == "TortugaScoreboard") {
			checkHighestScore();
			scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
			scoreText.text = blueScore + " " + greenScore;
			setMusic ();
		}
	}

	public void checkHighestScore() {
		if (blueScore > greenScore) {
			_highestScore = blueScore;
		} else if (greenScore > blueScore) {
			_highestScore = greenScore;
		}

		if (_highestScore > _prevHighestScore) {
			setMusic();
			_prevHighestScore = _highestScore;
		}
	}

	void setMusic() {
		_musicManager.highestScore = _highestScore;
		_musicManager.switchingClip = true;
	}



}
