using UnityEngine;
using System.Collections;

public class PowerUpManger : MonoBehaviour {

	public float dropRangeLeft;
	public float dropRangeRight;
	public float dropRangeUp;
	public float dropRangeDown;
	public GameObject[] powerups;
	//public float powerupDeliveryTime = 5f;
	public float peanutSpawnTime;		// The amount of time between each spawn.
	public float torpedoSpawnTime;
	public float spawnDelay;		// The amount of time before spawning starts.
	
	public int numActiveTorpedoPowerUps;
	public int numActivePeanutPowerUps;
	public int maxActiveTorpedoPowerUps;
	public int maxActivePeanutPowerUps;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnPeanutPowerUp",spawnDelay,peanutSpawnTime);
		InvokeRepeating("SpawnTorpedoPowerUp",spawnDelay,torpedoSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SpawnPeanutPowerUp() {
		if (numActivePeanutPowerUps < maxActivePeanutPowerUps) {
		//	print ("invoked peanut");
			float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);
			float dropPosY = Random.Range (dropRangeUp, dropRangeDown);
			
			// Create a position with the random x coordinate.
			Vector3 dropPos = new Vector3(dropPosX, dropPosY, 20.0f);
			
			Instantiate(powerups[0], dropPos, Quaternion.identity);
			numActivePeanutPowerUps++;
		}
		
	}
	
	void SpawnTorpedoPowerUp() {
		if (numActiveTorpedoPowerUps < maxActiveTorpedoPowerUps) {
		//	print ("numActiveTorpedoPowerUps: " + numActiveTorpedoPowerUps);

		//	print ("invoked torpedo");
			float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);
			float dropPosY = Random.Range (dropRangeUp, dropRangeDown);
			
			// Create a position with the random x coordinate.
			Vector3 dropPos = new Vector3(dropPosX, dropPosY, 20.0f);
			
			Instantiate(powerups[1], dropPos, Quaternion.identity);
			numActiveTorpedoPowerUps++;
		}
	}

	public void decrementActivePowerUps(ref int numActivePowerUps) {
//		print ("decrementing: " + numActivePowerUps);
		if (numActivePowerUps > 0) {
//			print ("before: " + numActivePowerUps);
			numActivePowerUps--;
//			print ("after: " + numActivePowerUps);
		}
	}
}
