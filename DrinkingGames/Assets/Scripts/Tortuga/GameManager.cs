using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool instantiatedGameManagers = false;
	public GameObject musicManagerPrefab;
	public GameObject scoreManagerPrefab;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);


	}

	void Start() {

		if (!instantiatedGameManagers) {
			GameObject mm = Instantiate (musicManagerPrefab) as GameObject;
			GameObject sm = Instantiate (scoreManagerPrefab) as GameObject;
			instantiatedGameManagers = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
