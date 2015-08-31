using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	private AudioSource _powerUpAudioSource;
	protected PowerUpManger _powerUpManager;
	public bool pickedUp = false;
	protected BoatWeapons _boatWeapons;
	protected BoatHealth _boatHealth;
	public float osc;
	private SpriteRenderer _spriteRenderer;
	private Vector3 bigScale;
	private Vector3 smallScale;


	// Use this for initialization
	public virtual void Start () {

		_powerUpAudioSource = GetComponent<AudioSource> ();
		_powerUpManager = GameObject.Find ("PowerUpManager").GetComponent<PowerUpManger>();
		_spriteRenderer = GetComponent<SpriteRenderer> ();

		bigScale = transform.localScale * 1.2f;
		smallScale = transform.localScale * .9f;
		oscillateUp ();
	}

	public virtual void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Boat") {
			if (!pickedUp) {
				pickedUp = true;

				_boatWeapons = coll.gameObject.GetComponent<BoatWeapons>();
				_boatHealth = coll.gameObject.GetComponent<BoatHealth>();
				_powerUpAudioSource.PlayOneShot(_powerUpAudioSource.clip);
				//_spriteRenderer.enabled = false;
				LeanTween.cancel(gameObject);
				LeanTween.scale (gameObject, Vector3.zero, .2f);
			
				Destroy(gameObject, _powerUpAudioSource.clip.length);
			}
		} 
	}

//	void oscillate(float speed, float scale) {
//		LeanTween.scale (gameObject, transform.localScale * 1.1f, 1f);
//	}

	void oscillateUp() {

		if (!pickedUp) {
			LeanTween.scale (gameObject, bigScale, 2f).setEase(LeanTweenType.easeOutSine).setLoopPingPong();
		}
		//LeanTween.scale (gameObject, bigScale, 2f).setEase(LeanTweenType.easeOutSine).setOnComplete(oscillateDown);
	}

	void oscillateDown() {
		LeanTween.scale (gameObject, smallScale, 2f).setEase(LeanTweenType.easeOutSine).setOnComplete(oscillateUp);

	}
}
