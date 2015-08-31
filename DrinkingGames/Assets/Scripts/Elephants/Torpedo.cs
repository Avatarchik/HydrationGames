using UnityEngine;
using System.Collections;

public class Torpedo : WeaponProjectile {

	public AudioSource takeOffAudioSource;
	public AudioSource explosionAudioSource;
	public AudioClip switchSound;
	private Collider2D _collider2D;
	public GameObject explosion;
	public ParticleSystem fuelParticles;
	private Rigidbody2D _rb2D;
	private  SpriteRenderer _spriteRenderer;
	public Sprite oppositeSprite;


	// Use this for initialization
	protected override void Start () {
		setEnemyBoat ();
		_rb2D = GetComponent<Rigidbody2D> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		_collider2D = GetComponent <Collider2D> ();
		//rotateTowardEnemy (1f);
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject == enemyBoat) {
			enemyBoatHealth.takeTorpedoDamage ();
			explodeTorpedo ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		rotateTowardEnemy (.1f);
		accelerateTowardEnemy ();
	}

	void rotateTowardEnemy(float rotateTime) {
		Vector3 direction = enemyBoat.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		direction = q.eulerAngles;
		LeanTween.rotate (gameObject, direction, rotateTime); 
	}

	void accelerateTowardEnemy() {
		Vector3 direction = enemyBoat.transform.position - transform.position;
		direction.Normalize();
		_rb2D.AddForce(direction/2f,ForceMode2D.Impulse);
	}

	public void switchTeam() {
		if (team == Team.Blue) {
			team = Team.Green;
			enemyBoat = GameObject.Find("BlueBoat");
		} else {
			team = Team.Blue;
			enemyBoat = GameObject.Find ("GreenBoat");
		}

		takeOffAudioSource.PlayOneShot(switchSound);
		_spriteRenderer.sprite = oppositeSprite;
		enemyBoatHealth = enemyBoat.GetComponent<BoatHealth> ();
	}

	public void explodeTorpedo() {
		//make sure particles are destroyed
		explosionAudioSource.Play ();
		_spriteRenderer.enabled = false;
		_rb2D.Sleep ();
		_collider2D.enabled = false;
		fuelParticles.emissionRate = 0f;
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject, 1f);
	}
}
