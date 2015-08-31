using UnityEngine;
using System.Collections;
using TMPro;
public class ReturnToStartScreen : MonoBehaviour {
	
	float countdown;
	public TextMeshProUGUI countdownTimer;
	// Use this for initialization
	void Start () {
		countdown = 30;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		countdown -= Time.deltaTime;
		countdownTimer.text = Mathf.RoundToInt(countdown).ToString();
		
		if (countdown <= 0) {
			Application.LoadLevel("ElephantsStartScreen");
		}
	}

	void OnMouseDown() {
		Application.LoadLevel("ElephantsStartScreen");
	}
}