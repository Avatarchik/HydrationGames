using UnityEngine;
using System.Collections;

public class Peanut : WeaponProjectile {


	public ParticleSystem peanutDebris;
	private SpriteRenderer _spriteRenderer;
	private float timeToExist;
	

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		timeToExist = 1.4f;
		StartCoroutine(fadeAndDestroy (timeToExist));
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) {
		wallOrPeanutHit (coll);
		enemyHit (coll);
		torpedoHit(coll);
	}


	public void wallOrPeanutHit(Collision2D coll) {
		if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Peanut") {
			_spriteRenderer.enabled = false;
			explodePeanut();
		}
	}

	public void enemyHit (Collision2D coll) {
		if (coll.gameObject == enemyBoat) {
			_spriteRenderer.enabled = false;

			if(enemyBoatHealth.team == BoatScript.Team.Blue) {
				GameStats.GreenPeanutHits += 1;  
			} else if (enemyBoatHealth.team == BoatScript.Team.Green) {
				GameStats.BluePeanutHits += 1;
			}
			explodePeanut();
			enemyBoatHealth.takePeanutDamage();
		}
	}

	public void torpedoHit(Collision2D coll) {
		if (coll.gameObject.tag == "Torpedo") {
			//
			if (coll.gameObject.GetComponent<Torpedo>().team != team) {
				coll.gameObject.GetComponent<TorpedoHealth>().takePeanutDamage();
			}
			_spriteRenderer.enabled = false;
			explodePeanut();
		}

	}

	public void explodePeanut() {
		ParticleSystem explosion = Instantiate(peanutDebris,transform.position,Quaternion.identity) as ParticleSystem;
		Destroy(explosion.transform.gameObject, 1.5f);
		Destroy(transform.gameObject,0.1f);
		//Collider is disabled to prevent new peanuts from bouncing off invisible peanuts
		gameObject.GetComponent<Collider2D>().enabled = false;
		Destroy (gameObject, 1f);
	}

	IEnumerator fadeAndDestroy(float aTime) {
		yield return new WaitForSeconds(aTime);
		LeanTween.alpha (gameObject, 0f, .1f);
		while (LeanTween.isTweening(gameObject)) {
			yield return null;	
		}
		Destroy (gameObject);
	}
}
