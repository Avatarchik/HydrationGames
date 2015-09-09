using UnityEngine;
using System.Collections;

public class BabyManager : MonoBehaviour {

	public GameObject[] babies;
	public float scatterRange;

	public bool resettingPos = false;

	// Use this for initialization
	void Start () {
//		scatterBabies ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void scatterBabies() {		
		for (int i = 0; i < babies.Length; i++) {
			babies[i].transform.position = new Vector2(Random.Range (-scatterRange,scatterRange), Random.Range (-scatterRange,scatterRange));
		}
	}


}
