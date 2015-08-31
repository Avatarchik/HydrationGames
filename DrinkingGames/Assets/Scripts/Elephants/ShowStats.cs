using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ShowStats : MonoBehaviour {
	
	public TextMeshProUGUI bluePeanutsFiredText;
	public TextMeshProUGUI blueAccuracyText;
	public TextMeshProUGUI greenPeanutsFiredText;
	public TextMeshProUGUI greenAccuracyText;
	public TextMeshProUGUI blueTorpedoPowerUpsText;
	public TextMeshProUGUI bluePeanutPowerUpsText;
	public TextMeshProUGUI greenTorpedoPowerUpsText;
	public TextMeshProUGUI greenPeanutPowerUpsText;

	public TextMeshProUGUI winText;

	public GameObject endElephant;

	public Color blue;
	public Color green;
	
	// Use this for initialization
	void Start () {
		displayStats ();
	}


	void displayStats() {
		bluePeanutsFiredText.text += " " + GameStats.BluePeanutsFired.ToString();
		blueAccuracyText.text += " " + GameStats.BlueAccuracy;
		greenPeanutsFiredText.text += " " + GameStats.GreenPeanutsFired.ToString();
		greenAccuracyText.text += " " + GameStats.GreenAccuracy;
		bluePeanutPowerUpsText.text += " " + GameStats.BluePeanutPowerUps;
		blueTorpedoPowerUpsText.text += " " + GameStats.BlueTorpedoPowerUps;
		greenPeanutPowerUpsText.text += " " + GameStats.GreenPeanutPowerUps;
		greenTorpedoPowerUpsText.text += " " + GameStats.GreenTorpedoPowerUps;
	}

	public void displayWinScreen(string winner) {
		if (winner == "Blue") {
			fadeElephantToWinColor(blue);
			setWinText(winner);
		} else {
			fadeElephantToWinColor(green);
			setWinText(winner);
		}
		
	}
	
	void fadeElephantToWinColor(Color color) {
		LeanTween.color (endElephant, color, 2f);
	}

	void setWinText(string winner) {
		if (winner == "Blue") {
			winText.text = "A blue elephant has won. \n A green elephant never forgets...";
			winText.color = blue;
		} else {
			winText.text = "A green elephant has won. \n A blue elephant never forgets...";
			winText.color = green;
		}
	}
}
