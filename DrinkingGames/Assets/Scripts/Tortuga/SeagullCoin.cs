using UnityEngine;
using System.Collections;

public class SeagullCoin : MonoBehaviour {

	[SerializeField] private AudioSource _audSource;
	[SerializeField] private AudioClip _lockedOnClip;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private Collider2D _collider2D;
	[SerializeField] private GameObject _blueTurtleParent;
	[SerializeField] private GameObject _greenTurtleParent;
	[SerializeField] private Seagull _seagull;
	[SerializeField] private GameObject _coinParticlesPrefab;
	[SerializeField] private GameObject _crosshairPrefab;
	private float _yBounds = -7f;
	[SerializeField] private Color _crosshairLockedColor;


	// Use this for initialization
	void Start () {
		_blueTurtleParent = GameObject.Find("BlueTurtleParent");
		_greenTurtleParent = GameObject.Find ("GreenTurtleParent");
		_seagull = GameObject.Find("Seagull").GetComponent<Seagull>();
	}
	
	// Update is called once per frame
	void Update () {
		setInactiveIfOutOfBounds();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "TurtleParent") {
			StartCoroutine(DoSeagullAttackSequence(coll.gameObject));
		}
	}


	IEnumerator DoSeagullAttackSequence(GameObject turtle) {
		if (turtle.tag == "TurtleParent") {
			
			GameObject turtleToAttack;
			if (turtle.GetComponent<TurtleScript>().team == TurtleScript.Team.Blue) {
				turtleToAttack = _greenTurtleParent;
			} else {
				turtleToAttack = _blueTurtleParent;
			}
			_seagull.setTurtleToAttack(turtleToAttack);
	
			Instantiate(_coinParticlesPrefab, transform.position, Quaternion.identity);
			_collider2D.enabled = false;
			_spriteRenderer.enabled = false;

			GameObject crosshair = Instantiate(_crosshairPrefab, turtleToAttack.transform.position, Quaternion.identity) as GameObject;
			crosshair.transform.SetParent(turtleToAttack.transform);
			LeanTween.scale(crosshair, Vector2.one, 1.5f).setEase(LeanTweenType.easeOutExpo);

			_audSource.Play ();
			LeanTween.value (gameObject, _audSource.pitch, 2f, 1.4f).setOnUpdate ((float _p) => {
				_audSource.pitch = _p;	
			});

			while (LeanTween.isTweening(crosshair)) {yield return null;}
			_audSource.Stop ();
			_audSource.pitch = 1f;
			_audSource.PlayOneShot (_lockedOnClip);
			crosshair.GetComponent<SpriteRenderer>().color = _crosshairLockedColor;
			yield return new WaitForSeconds(.6f);
			_seagull.attack =  true;
			_seagull.crossHairToDestroy = crosshair;
			Destroy(gameObject);
		}
	}


	void setInactiveIfOutOfBounds() {
		if (transform.position.y < _yBounds) {
			Destroy(gameObject);
		}
	}
}
