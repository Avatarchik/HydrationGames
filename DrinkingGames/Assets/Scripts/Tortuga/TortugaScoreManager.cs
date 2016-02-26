using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class TortugaScoreManager : MonoBehaviour {


	private MusicManager _musicManager; 
	public int blueScore = 0;
	public int greenScore = 0;
	private TextMeshProUGUI scoreText;
	private TextMeshProUGUI winnerText;
	private int _prevHighestScore;
	private int _highestScore;
	private bool _blueHasHighestScore = false;
	public Color blueColor;
	public Color greenColor;
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
			scoreText.text = "<color=#639242FF>" + greenScore +  "</color>" + " -  <color=#298E94FF>" + blueScore +  "</color>";
			setMusic ();
		}

		if (SceneManager.GetActiveScene().name == "TortugaGameOverScreen") {
			checkHighestScore();
			scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
			scoreText.text = "<color=#639242FF>" + greenScore +  "</color>" + " -  <color=#298E94FF>" + blueScore +  "</color>";
			winnerText = GameObject.Find ("WinnerText").GetComponent<TextMeshProUGUI> ();

			if (_blueHasHighestScore) {
				winnerText.text = "Blue Wins";
				winnerText.color = blueColor;
			} else {
				winnerText.text = "Green Wins";
				winnerText.color = greenColor;
			}


			setMusic ();
		}
	}

	public void checkHighestScore() {
		if (blueScore > greenScore) {
			_highestScore = blueScore;
			_blueHasHighestScore = true;
		} else if (greenScore > blueScore) {
			_blueHasHighestScore = false;
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
