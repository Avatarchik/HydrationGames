using UnityEngine;
using System.Collections;

public class BabyManager : MonoBehaviour {

	public GameObject blueBabyPrefab;
	public GameObject greenBabyPrefab;
	public float scatterRange;

	public bool resettingPos = false;

	// Use this for initialization
	void Start () {
		scatterBabies(blueBabyPrefab, 3);
		scatterBabies(greenBabyPrefab, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void scatterBabies(GameObject babyPrefab, int numBabies) {		
		for (int i = 0; i < numBabies; i++) {
			Vector2 spawnPos = new Vector2(Random.Range (-scatterRange,scatterRange), Random.Range (-scatterRange,scatterRange));
			GameObject baby = Instantiate (babyPrefab, spawnPos, Quaternion.identity) as GameObject;
		}
	}


}
