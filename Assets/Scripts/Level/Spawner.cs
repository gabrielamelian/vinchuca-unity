using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Flea;
	[System.NonSerialized]
	public int FleaCounter = 0;
	[System.NonSerialized]
	public int fleaScore = 15;

	private int initialMaxFleas = 1;
	private float initialPercentageSpawn = 60f;
	private float timeBetweenSpawns = 0.8f;
	private float timeBetweenDifficulty = 10f;

	private float maxPercentageSpawn = 80f;
	private float minTimeBetweenSpawns = 0.2f;

	private int maxFleas;
	private int currentDiff = 0;
	private float percentageSpawn;
	private float spawnTimer;
	private float difficultyTimer;

	void Start() {
		maxFleas = initialMaxFleas;
		percentageSpawn = initialPercentageSpawn;
	}
		
	void Update() {
		Spawn ();
		IncreaseDifficulty ();
	}

	void Spawn() {
		spawnTimer += Time.deltaTime;
		
		if (spawnTimer >= timeBetweenSpawns && FleaCounter < maxFleas) {
			float random = Random.Range(0,100);
			
			if (random < percentageSpawn) {
				Instantiate (Flea, new Vector2 (Random.Range(-5F, 5F), 0), Quaternion.identity);
				FleaCounter++;
			}
			
			spawnTimer = 0f;
		}
	}

	void IncreaseDifficulty() {
		difficultyTimer += Time.deltaTime;

		if(difficultyTimer > timeBetweenDifficulty) {
			bool increaseMaxFleas = currentDiff % 6 == 0 && currentDiff != 0;
			if(increaseMaxFleas) {
				maxFleas += 1;
			} else {
				float newPercentageSpawn = percentageSpawn + 0.25f;
				if(!(newPercentageSpawn > maxPercentageSpawn)) {
					percentageSpawn = newPercentageSpawn;
				}

				float newTimeBetweenSpawns = timeBetweenSpawns - 0.05f;
				if(!(newTimeBetweenSpawns < minTimeBetweenSpawns)) {
					timeBetweenSpawns -= 0.05f;
				}
			}

			currentDiff += 1;
			difficultyTimer = 0f;

			Debug.Log (string.Format("MaxFleas: {0}, PercentageSpawn: {1}, timeBetweenSpawns: {2}", 
				maxFleas, percentageSpawn, timeBetweenSpawns));

		}
	}

}
