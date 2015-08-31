using UnityEngine;
using System.Collections;

public class GetItemAlert : MonoBehaviour {
	
	public Quaternion initRotation;
	public Vector3 parentPos;
	public float posY;
	
	// Use this for initialization
	void Start () {
		initRotation = transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {
		parentPos = gameObject.transform.parent.transform.position;
		
	}
	
	void LateUpdate() {
		transform.rotation = initRotation;
		transform.position = new Vector3(parentPos.x,parentPos.y,0);
	}
}
