using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class OnBoardingMeter : MonoBehaviour {

	private Slider _slider;
	public bool meterFull;
	private bool explosionInstantiated;
	public string playerInput1;
	public string playerInput2;
	public TextMeshProUGUI readyText;
	private float increment;
	public Color readyColor;
	public GameObject readyExplosion;
	public Transform readyExplosionPosition;

	public AudioClip explosionSound;
	private AudioSource _meterChargeAudioSource;
	private float _meterChargeAudioTimer = 0f;
	private bool _meterChargeSoundJustPlayed = false;
	private float _meterChargeMultiplier = 3f;


	// Use this for initialization
	void Start () {
		_meterChargeAudioSource = GetComponent<AudioSource> ();

		_slider = GetComponent<Slider>();

		explosionInstantiated = false;
		increment = 0.1f;
		_slider.value = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!meterFull) {
			fillMeterOnPlayerInput();
		}

		showReadyWhenMeterFilled();

		float repeatTime = .2f;
		if (_meterChargeAudioTimer > repeatTime && !_meterChargeSoundJustPlayed) {
			_meterChargeAudioSource.PlayOneShot (_meterChargeAudioSource.clip);
			_meterChargeAudioSource.pitch += 0.1f;
			_meterChargeAudioTimer = 0f;
			_meterChargeSoundJustPlayed = true;
		} else {
			_meterChargeSoundJustPlayed = false;
		}
	}
	
	void fillMeterOnPlayerInput() {
		if (Input.GetKey(playerInput1) || Input.GetKey(playerInput2)) {
			_slider.value += Time.deltaTime *_meterChargeMultiplier;
			_meterChargeAudioTimer += Time.deltaTime;
		} 
	}

	void showReadyWhenMeterFilled() {
		if (_slider.value == _slider.maxValue) {
			meterFull = true;
			readyText.color = readyColor;
			if (!explosionInstantiated) {
				_meterChargeAudioSource.Stop();
				_meterChargeAudioSource.pitch = 1f;
				_meterChargeAudioSource.PlayOneShot(explosionSound);
				Instantiate (readyExplosion, readyExplosionPosition.position, Quaternion.identity);
				explosionInstantiated = true;
			}	
		}
	}


}
