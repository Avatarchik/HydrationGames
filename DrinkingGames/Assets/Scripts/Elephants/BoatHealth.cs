using UnityEngine;
using System.Collections;
using TMPro;

public class BoatHealth : BoatScript {

	public AudioSource peanutBounceAudioSource;
	public AudioSource deathBeepsAudioSource;
	public AudioSource depthChargeAudioSource;
	public Color hurtColor;
	public Color normalColor;
	private SpriteRenderer _spriteRenderer;
	public GameObject damageDisplayPeanut;
	public GameObject damageDisplayTorpedo;
	public GameObject deathExplosion;
	public RectTransform torpedoChargeMeter;
	public HealthBar healthBar;

	private bool _deathBeepsPlayed = false;
	private bool _depthChargePlayed = false;
	public bool playerDying = false;
	public static bool winnerSet = false; //prevents a late kill from making the 2nd player to get the kill the winner.
	public int health;


	// Use this for initialization
	void Start () {
		winnerSet = false;
		playerDying = false;
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	
	}
	
	public void takeTorpedoDamage() {
		int torpedoDamage = Random.Range (4,7);
		if (!playerDying) {
			showDamage (damageDisplayTorpedo, torpedoDamage);
			StartCoroutine(showHurtColor());
			health-=torpedoDamage;
			healthBar.matchPlayerHealth(health);
			checkForDead();
		}

	}
	
	
	public void takePeanutDamage() {
		int peanutDamage = Random.Range (1,4);
		if (!playerDying) {
			showDamage (damageDisplayPeanut, peanutDamage);
			StartCoroutine(showHurtColor());
			health-=peanutDamage;
			healthBar.matchPlayerHealth(health);
			checkForDead ();
		}
		peanutBounceAudioSource.Play();
		
	}

	public void showDamage(GameObject damageDisplay, int damageAmount) {
		GameObject dd = Instantiate (damageDisplay, transform.position, Quaternion.identity) as GameObject;
		dd.GetComponent<TextMeshPro>().text = damageAmount.ToString();
		dd.GetComponent<Rigidbody2D>().velocity = new Vector2(0,15f);
	}

	IEnumerator showHurtColor() {
		_spriteRenderer.color = hurtColor;
		healthBar.setColor (hurtColor);
		yield return new WaitForSeconds(.05f);
		_spriteRenderer.color = normalColor;
		healthBar.setColor (healthBar.normalColor);	
	}

	void checkForDead() {
		if (health <= 0) {
			playerDying = true;
			deathSequence();
			if (!winnerSet) {
				setWinnerOnDeath();
			}
		}
	}

	void deathSequence() {
		playDeathBeeps ();
		_spriteRenderer.material.color = normalColor;

		StartCoroutine (tweenToDeath (deathBeepsAudioSource.clip.length - 1f));

	}

	void playDeathBeeps() {
		if (!deathBeepsAudioSource.isPlaying && !_deathBeepsPlayed) {
			deathBeepsAudioSource.Play ();
			_deathBeepsPlayed =  true;
		}
	}

	void playDepthChargeSound() {
		if (!depthChargeAudioSource.isPlaying && !_depthChargePlayed) {
			depthChargeAudioSource.Play();
			_depthChargePlayed = true;
		}
	}

	IEnumerator tweenToDeath(float seconds) {
		//playDeathBeeps ();
		//_spriteRenderer.color = Color.Lerp (_spriteRenderer.color, hurtColor, Time.deltaTime * seconds);
		LeanTween.color (gameObject, hurtColor, seconds).setDelay (.1f); //delay so showHurtColor coroutine is definitely over;

		while (LeanTween.isTweening(gameObject)) {
			yield return null;
		}

		explode ();
	}

	void explode() {
		_spriteRenderer.enabled = false;
		Destroy (torpedoChargeMeter);
	
		playDepthChargeSound ();
		Instantiate (deathExplosion, transform.position, Quaternion.identity);
		StartCoroutine (deathAfterExplosion (team));
	}

	void destroyTorpedoShields() {
		foreach (RectTransform torpedoShield in GetComponent<BoatWeapons>().torpedoShields) {
			Destroy(torpedoShield.gameObject);
		}
	}

	IEnumerator deathAfterExplosion(Team team) {
		yield return new WaitForSeconds(4);
		Application.LoadLevel("ElephantsGameOver");
	}

	void setWinnerOnDeath() {
		winnerSet = true;
		if (team == Team.Blue) { 
			GameStats.winner = "Green";
		
		} else {
			GameStats.winner = "Blue";
		}
		print("Winner: " + GameStats.winner);

	}
}
