using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PeanutBin : MonoBehaviour {

	public Transform peanutSpawnPosition;
	public GameObject peanutPrefab;
	public BoatWeapons boatWeapons;
	public AudioSource peanutBinAudioSource;
	public List<GameObject> displayPeanuts;
	public int pooledAmount = 100;
	private Vector3 _binSize;

//	public Stack<GameObject> peanuts;

	// Use this for initialization
	void Start () {

		_binSize = GetComponentInParent<SpriteRenderer> ().bounds.extents; 
		peanutBinAudioSource = GetComponent<AudioSource> ();
		initializeDisplayPeanuts();

	}
	
//	public IEnumerator createPeanuts(int numPeanuts) {
//		for (int i = 0; i < numPeanuts; i++) {
//			yield return new WaitForSeconds (.1f);
//			peanutBinAudioSource.PlayOneShot(peanutBinAudioSource.clip);                
//			Instantiate (peanutPrefab, pean, Quaternion.identity);
//		}
//	}

	void initializeDisplayPeanuts() {
		for (int i = 0; i < pooledAmount; i++) {   
			GameObject obj = (GameObject)Instantiate (peanutPrefab);
			obj.SetActive(false);
			displayPeanuts.Add (obj);
		}
	}

	public void setPeanutsActive(int numPeanuts) {
		StartCoroutine(setPeanutsActiveCoroutine(numPeanuts));
	}

	public IEnumerator setPeanutsActiveCoroutine(int numPeanuts) {
 		for (int i = 0; i < displayPeanuts.Count; i++) {
			if (!displayPeanuts[i].activeInHierarchy && numPeanuts > 0) {
				yield return new WaitForSeconds (.1f);
				float offset = Random.Range (-_binSize.x*.6f,_binSize.x*.6f);

				Vector3 spawnPos = new Vector3 (peanutSpawnPosition.position.x + offset, peanutSpawnPosition.position.y);

				displayPeanuts[i].transform.position = spawnPos;
				displayPeanuts[i].SetActive(true);
				
//				displayPeanuts[i].GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(Random.Range (-.1f,.1f),Random.Range(-.1f,.1f)), ForceMode2D.Impulse);
				displayPeanuts[i].GetComponentInChildren<Rigidbody2D>().AddTorque(Random.Range (-1f,1f), ForceMode2D.Impulse);

				peanutBinAudioSource.PlayOneShot(peanutBinAudioSource.clip);    
				numPeanuts--;
			}
		}
	}

	public void destroyAPeanut() {
		for (int i = 0; i < displayPeanuts.Count; i++) {
			if (displayPeanuts[i].activeInHierarchy) {
				displayPeanuts[i].SetActive(false);
				break;
			}
		}
	}


}
