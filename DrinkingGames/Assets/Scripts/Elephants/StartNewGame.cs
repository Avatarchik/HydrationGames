using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class StartNewGame : MonoBehaviour {


	public OnBoardingMeter blueNavigator;
	public OnBoardingMeter blueGunner;
	public OnBoardingMeter greenNavigator;
	public OnBoardingMeter greenGunner;

	public AudioClip countDownSound;
	public bool countdownSequenceInitiated;
	private bool _elephantSoundPlayed = false;
	public RectTransform countdownPanel;
	public RectTransform elephant;
	public TextMeshProUGUI countdownTimer;
	public float countdown;



	public AudioSource elephantAudioSource;
	
	// Use this for initialization
	void Start () {
		elephantAudioSource = GetComponent<AudioSource>();
		countdown = 5;
		countdownTimer.color = Color.clear;
	}
	
	// Update is called once per frame
	public virtual void Update () {

		if (checkAllPlayersReady ()) {
			StartCoroutine(beginCountDownSequence());
			startCountdown();		
		}

		if (Input.GetKey(KeyCode.Space)) {
			//Application.LoadLevel("ElephantsArena");
		
			StartCoroutine(beginCountDownSequence());
			startCountdown();
		}
	}

	void OnMouseDown() {
		Application.LoadLevel("ElephantsArena");
	}

	bool checkAllPlayersReady() {
		if (blueNavigator.meterFull && blueGunner.meterFull && greenNavigator.meterFull && greenGunner.meterFull) {
			return true;
		} else {
			return false;
		}
	}

	IEnumerator beginCountDownSequence() {
		if (!countdownSequenceInitiated) {
			countdownSequenceInitiated = true;
			//elephantAudioSource.Play ();
			LeanTween.alpha(countdownPanel, 1f, 1f).setEase(LeanTweenType.easeInOutSine);
			LeanTween.alpha(elephant, 1f, 1f).setEase(LeanTweenType.easeInOutSine);
			countdownTimer.color = Color.white;
			//LeanTween.value(gameObject, countdownTimer.color.a, 

		}
		yield return null;
	}

	 void startCountdown() {

		if (countdown > 0.4f) { //.4 because when it rounds down to zero in text, its not actually at zero
			string oldCountDownTimerText = countdownTimer.text;
			countdown -= Time.deltaTime;
			countdownTimer.text = Mathf.RoundToInt(countdown).ToString();
			if (countdownTimer.text != oldCountDownTimerText) {
				elephantAudioSource.PlayOneShot(countDownSound);
			}
		} else {
			if (!elephantAudioSource.isPlaying && !_elephantSoundPlayed) {
				elephantAudioSource.Play();
				_elephantSoundPlayed = true;
			}
			StartCoroutine(delayLevelLoad());
		}
	}

	IEnumerator delayLevelLoad() {
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("ElephantsArena");

	}
}
