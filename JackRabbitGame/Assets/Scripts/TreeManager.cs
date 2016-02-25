using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour {

	[SerializeField] private GameObject _treePrefab;
	[SerializeField] private int _numTrees = 1000;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < _numTrees; i++) {
			Vector3 treePos = new Vector3((i+1) * Random.Range(15f,35f), 4f, Random.Range(1f,9f));
			Instantiate(_treePrefab, treePos, Quaternion.identity);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
