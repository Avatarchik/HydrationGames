using UnityEngine;
using System.Collections;

public class SeagullCoinManager : MonoBehaviour {


	public GameObject coinPrefab;
	public GameObject coin;
	private float _coinTimer = 3f;

	// Use this for initialization
	void Start () {
		coin = Instantiate(coinPrefab);
		coin.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		_coinTimer -= Time.deltaTime;
		
		if (_coinTimer <= 0 && !coin.activeInHierarchy) {
			coin.SetActive(true);
			coin.transform.position = new Vector2 (7f, Random.Range (-5f,5f));
			coin.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Random.Range (-2f,-3f));
			_coinTimer = Random.Range (3f,5f);
		}
	
	}
}
