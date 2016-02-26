using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TortugaStartGameButton : MonoBehaviour {

	public bool blueTurtleReady = false;
	public bool greenTurtleReady = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void checkTurtlesReady() {
		if (blueTurtleReady && greenTurtleReady) {
			startGame ();
		}
		
	}

	public void startGame() {
		SceneManager.LoadScene ("TortugaScoreboard");		
	}
}
