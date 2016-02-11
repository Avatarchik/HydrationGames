using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class TortugaScoreManager : MonoBehaviour {

	public int blueScore = 0;
	public int greenScore = 0;

	private TextMeshProUGUI scoreText;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int level) {

		if (level == 4) {
			
		}

		if (SceneManager.GetActiveScene().name == "TortugaScoreboard") {
			scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
			scoreText.text = blueScore + " " + greenScore;
		}
	}
}
