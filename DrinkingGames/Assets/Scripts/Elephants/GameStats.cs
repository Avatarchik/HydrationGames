using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {


	public Color greenColor;
	public Color blueColor;
	public static string winner;

	//Stats
	public static float BluePeanutsFired;
	public static float GreenPeanutsFired;
	public static string BlueAccuracy;
	public static float BluePeanutHits; //Number of times blue hit green with peanuts
	public static float GreenPeanutHits;
	public static string GreenAccuracy;
	public static float BlueTorpedoPowerUps;
	public static float BluePeanutPowerUps;
	public static float GreenTorpedoPowerUps;
	public static float GreenPeanutPowerUps;
	public static float BlueTorpedosFired;
	public static float GreenTorpedosFired;
	
	// Use this for initialization
	void Start () {
		GameStats.Reset ();
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//		print ("BluePeanutsFired: " + BluePeanutsFired);
		//		print ("BluePeanutHits: " + BluePeanutHits);
		//		print ("GreenPeanutsFired: " + GreenPeanutsFired);
		//		print ("GreenPeanutHits: " + GreenPeanutHits);
		//		print ("GreenPeanutPowerUps: " + GreenPeanutPowerUps);
		//		print ("BluePeanutPowerUos: " + BluePeanutPowerUps); 
		
		if (BluePeanutsFired>0) {
			BlueAccuracy =  Mathf.Round ((BluePeanutHits/BluePeanutsFired)*100f).ToString() + "%";
			//print ("BlueAccuracy: " + Mathf.Round ((BluePeanutHits/BluePeanutsFired)*100f)+"%");
		}
		
		if (GreenPeanutsFired>0) {
			GreenAccuracy = Mathf.Round ((GreenPeanutHits/GreenPeanutsFired)*100f).ToString ()+ "%";
		}
		
		
	}
	
	public static void Reset() {
		BluePeanutsFired = 0;
		BluePeanutHits = 0;
		BluePeanutPowerUps = 0;
		BlueTorpedoPowerUps = 0;
		GreenPeanutsFired = 0;
		GreenPeanutHits = 0;
		GreenPeanutPowerUps = 0;
		GreenTorpedoPowerUps = 0;
		BlueTorpedosFired = 0;
		GreenTorpedosFired = 0;
	}

	void OnLevelWasLoaded(int level) {
		if (Application.loadedLevelName == "ElephantsGameOver") {
			GameObject.Find ("StatsDisplay").GetComponent<ShowStats>().displayWinScreen(winner);
		}
	}


}
