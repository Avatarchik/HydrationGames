using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class BoatWeapons : BoatScript {

	//Components
	private Animator _animator;
	public AudioSource trunkPopAudioSource;
	public AudioSource torpedoChargeMeterAudioSource;
	public AudioSource torpedoShieldAudioSource;
	public RectTransform[] torpedoShields;
	public PeanutBin peanutBin;
	public Slider torpedoChargeMeter;
	private SoundPlayer _soundPlayer;
	public Transform trunkTip;
	public Transform torpedoLaunchPoint;
	public TextMeshProUGUI peanutCounter;
	public TextMeshProUGUI peanutAlert;
	public TextMeshProUGUI torpedoAlert;
	public IconAlpha peanutsIcon;
	public IconAlpha torpedoIcon;

	//Prefabs
	public GameObject peanutPrefab;
	public GameObject torpedoPrefab;


	//Variables
	public int numPeanuts = 10;
	private float _torpedoChargeMultiplier;
	private float _peanutForceMultiplier;
	private float _torpedoChargeAudioTimer;
	public bool torpedoEquipped;
	private bool _torpedoFullyCharged;
	private bool _torpedoChargeSoundJustPlayed;
	public int peanutPoolSize = 100;
	public List<GameObject> peanuts;


	
	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		_soundPlayer = GetComponent<SoundPlayer>();

		_peanutForceMultiplier = 10f;
		_torpedoChargeMultiplier = 3f;
		_torpedoChargeAudioTimer = 0f;
		_torpedoChargeSoundJustPlayed = false;

		updatePeanutCounter();
		peanutBin.setPeanutsActive(numPeanuts);
	}

	public void firePeanuts () {
		peanutsIcon.turnOn ();
		if (canShootPeanuts()) {
			_animator.SetBool("shootingPeanuts", true);
		} else {
			turnOnAlert(peanutAlert);
			_animator.SetBool("shootingPeanuts", false);
		}
	}

	public void stopPeanuts() {
		turnOffAlert (peanutAlert);
		peanutsIcon.turnOff ();
		_animator.SetBool ("shootingPeanuts", false);
	}

	public void shootPeanut() {
		trunkPopAudioSource.Play ();
		GameObject peanut = Instantiate(peanutPrefab, trunkTip.position, transform.rotation) as GameObject;
		peanut.GetComponent<Rigidbody2D>().AddForce(transform.up * _peanutForceMultiplier);
		numPeanuts--;
		peanutBin.destroyAPeanut();
		updatePeanutCounter();
		updatePeanutFiredStat ();
	}

	public bool canShootPeanuts() {
		if (numPeanuts > 0) {
			return true;
		} else {
			return false;
		}
	}

	public void chargeTorpedo() {
		torpedoIcon.turnOn();
		if (torpedoEquipped) {
			if (torpedoChargeMeter.value < torpedoChargeMeter.maxValue) {

				torpedoChargeMeter.value += Time.deltaTime * _torpedoChargeMultiplier;
				_torpedoChargeAudioTimer += Time.deltaTime;

				float repeatTime = .2f;
				if (_torpedoChargeAudioTimer > repeatTime && !_torpedoChargeSoundJustPlayed) {
					torpedoChargeMeterAudioSource.PlayOneShot (torpedoChargeMeterAudioSource.clip);
					torpedoChargeMeterAudioSource.pitch += 0.1f;
					_torpedoChargeAudioTimer = 0f;
					_torpedoChargeSoundJustPlayed = true;
				} else {
					_torpedoChargeSoundJustPlayed = false;
				}
			
			} else {
				fireTorpedo ();
			}
		} else {
			turnOnAlert(torpedoAlert);
		}

	}

	public void stopChargeTorpedo() {
		turnOffAlert (torpedoAlert);
		torpedoIcon.turnOff();
	}

	public void fireTorpedo() {
		Instantiate (torpedoPrefab, torpedoLaunchPoint.position, Quaternion.identity);
		torpedoChargeMeter.value = 0f;
		torpedoChargeMeterAudioSource.pitch = 1f;
		_torpedoChargeAudioTimer = 0f;
		torpedoEquipped = false;
		replaceTorpedoShield ();
	}

	public void equipTorpedo() {
		removeTorpedoShield ();
		torpedoEquipped = true;
	}

	public void removeTorpedoShield() {
		StartCoroutine(DelayPlaySound (torpedoShieldAudioSource, .1f));
		torpedoShieldAudioSource.Play ();
		foreach (RectTransform torpedoShield in torpedoShields) {
			Vector3 removedScale = new Vector3 (0,torpedoShield.localScale.y);
			LeanTween.scale(torpedoShield, removedScale, 1f);
		}

	}

	IEnumerator DelayPlaySound(AudioSource auSrc, float delay) {
		yield return new WaitForSeconds (delay);
		auSrc.Play ();
	}

	public void replaceTorpedoShield() {
	//	torpedoShieldAudioSource.Play ();
		foreach (RectTransform torpedoShield in torpedoShields) {
			Vector3 replacedScale = new Vector3 (1,torpedoShield.localScale.y);
			LeanTween.scale(torpedoShield, replacedScale, 1f);
		}	
	}

	public void updatePeanutCounter() {
		peanutCounter.text = numPeanuts.ToString();
	}

	public void updatePeanutFiredStat() {
		if (team == Team.Blue) {
			GameStats.BluePeanutsFired++;
		} else {
			GameStats.GreenPeanutsFired++;
		}
	}

	public void turnOnAlert(TextMeshProUGUI alertText) {
		alertText.color = Color.white;
	}

	public void turnOffAlert(TextMeshProUGUI alertText) {
		alertText.color = Color.clear;
	}

//	public IEnumerator setPeanutActiveCoroutine(int numPeanuts) {
//		print ("numPeanuts: " + numPeanuts);
//		for (int i = 0; i < peanuts.Count; i++) {
//			if (!peanuts[i].activeInHierarchy && numPeanuts > 0) {
//				yield return new WaitForSeconds (.1f);
//				float offset = Random.Range (-2f,2f);
//				
//				Vector3 spawnPos = new Vector3 (peanutSpawnPosition.position.x + offset, peanutSpawnPosition.position.y);
//				
//				displayPeanuts[i].transform.position = spawnPos;
//				displayPeanuts[i].SetActive(true);
//				
//				peanutBinAudioSource.PlayOneShot(peanutBinAudioSource.clip);    
//				numPeanuts--;
//			}
//		}
//	}


//	void updateTorpedoFiredStat() {
//		if (team == BoatScript.Team.Blue) {
//			GameStats.BlueTorpedoPowerUps++;
//		} else {
//			GameStats.GreenTorpedoPowerUps++;	
//		}
//	}
}
