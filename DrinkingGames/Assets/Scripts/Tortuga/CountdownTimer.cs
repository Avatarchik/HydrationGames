using UnityEngine;
using System.Collections;
using TMPro;

public class CountdownTimer : MonoBehaviour {

	private TextMeshProUGUI _timerText;
	public float timeLeft = 5f;

	// Use this for initialization
	void Start () {
		_timerText = GetComponent<TextMeshProUGUI> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			_timerText.text = Mathf.RoundToInt (timeLeft).ToString ();
		} else {
			Invoke ("startNewRound", 1f);
		}

	}

	void startNewRound() {
		Application.LoadLevel ("TortugaArena");
	}
}
