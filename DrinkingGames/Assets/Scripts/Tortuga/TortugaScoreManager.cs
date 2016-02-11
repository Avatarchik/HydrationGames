using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class TortugaScoreManager : MonoBehaviour {

	private MusicManager _musicManager; 
	public int blueScore = 0;
	public int greenScore = 0;
	private TextMeshProUGUI scoreText;

	void Awake() {
		DontDestroyOnLoad(gameObject);
		_musicManager = GameObject.Find ("MusicManager").GetComponent<MusicManager> ();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int level) {
		if (SceneManager.GetActiveScene().name == "TortugaScoreboard") {
			scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
			scoreText.text = blueScore + " " + greenScore;
			setMusic ();
		}
	}

	void setMusic() {


		
	}
}
