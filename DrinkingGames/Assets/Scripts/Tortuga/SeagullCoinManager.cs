using UnityEngine;
using System.Collections;

public class SeagullCoinManager : MonoBehaviour
{

	public bool seagullSequenceInProcess = false;
	public GameObject coinPrefab;
	private float _coinTimer = 3f;
	private Vector2 _spawnPos;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!seagullSequenceInProcess) {
			_coinTimer -= Time.deltaTime;
		}

		if (_coinTimer <= 0) {
			launchCoin ();
			_coinTimer = Random.Range (5f, 9f);
		}

	
	}

	public void launchCoin() {
		_spawnPos = new Vector2 (Random.Range (-5f, 5f), 7f);
		GameObject coin = Instantiate (coinPrefab, _spawnPos, Quaternion.identity) as GameObject;
		coin.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, Random.Range (-2f, -3f));
		coin.GetComponent<SeagullCoin> ().coinManager = this;
	}
}
