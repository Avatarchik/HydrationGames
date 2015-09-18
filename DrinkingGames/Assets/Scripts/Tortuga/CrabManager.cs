using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrabManager : MonoBehaviour {

	public GameObject crabPrefab;
	public GameObject[] _crabs;
	public int crabPoolSize = 5;

	public Transform spawnPoint;
	private Vector2 _spawnPosLeft;
	private Vector2 _spawnPosRight;
	private Vector2 _spawnPos;
	private Vector2 _crabVelocity;

	public float crabTimer = 3f;
	// Use this for initialization
	void Start () {
		_crabs = new GameObject[crabPoolSize];
		for (int i = 0; i < crabPoolSize; i++) {
			GameObject crab = Instantiate (crabPrefab);
			_crabs[i] = crab;
			crab.SetActive(false);
		}

		_spawnPosLeft = spawnPoint.position;
		_spawnPosRight = _spawnPosLeft * -1f;
	
	}
	
	// Update is called once per frame
	void Update () {
		crabTimer -= Time.deltaTime;
		if (crabTimer <= 0f) {
			launchCrab();
			crabTimer = Random.Range (2f,5f);
		}
	}

	void launchCrab() {
		_crabVelocity = new Vector2(Random.Range(3f,5f), 0f);
		float yOffset = Random.Range (-5f,5f);

		if (Random.value < .5) {
			//Spawn right and move left;
			_spawnPos = new Vector2(_spawnPosLeft.x, yOffset);
			_crabVelocity = _crabVelocity;
		} else {
			_spawnPos = new Vector2(_spawnPosRight.x, yOffset);
			_crabVelocity = _crabVelocity * -1f;
		}

		for (int i = 0; i < crabPoolSize; i++) {
			if (!_crabs[i].activeInHierarchy) {
				_crabs[i].SetActive(true);
				_crabs[i].transform.position = _spawnPos;
				_crabs[i].GetComponent<Rigidbody2D>().velocity = _crabVelocity;
				break;
			}
		}
	}



}
