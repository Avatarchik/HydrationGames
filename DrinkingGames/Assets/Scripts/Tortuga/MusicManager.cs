using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {


	[SerializeField] private AudioSource _audSource1;
	[SerializeField] private AudioSource _audSource2;
	[SerializeField] private AudioSource _audSource3;
	[SerializeField] private AudioSource _audSource4;
	[SerializeField] private AudioSource _audSource5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.S)) {

			LeanTween.value(gameObject, _audSource1.volume, 0f, _audSource1.clip.length ).setOnUpdate( 
				(float v)=>{
					_audSource1.volume = v;
				}
			);

			LeanTween.value(gameObject, _audSource2.volume, 1f, _audSource1.clip.length ).setOnUpdate( 
				(float v)=>{
					_audSource2.volume = v;
				}
			);
				
			
		}
	}


}
