using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Flea;

	public int MaxFleaCounter = 3;
	public int FleaCounter = 0;
	public float percentageSpawn = 60f;
	public float timeBetweenSpawns = 1.25f;
	
	private float timer;
		
	void Update() {
		timer += Time.deltaTime;
		
		if (timer >= timeBetweenSpawns && FleaCounter < MaxFleaCounter) {
			float random = Random.Range(0,100);
			
			if (random > percentageSpawn) {
				Instantiate (Flea, new Vector2 (Random.Range(-5F, 5F), 0), Quaternion.identity);
				FleaCounter++;
			}
			
			timer = 0f;
		}
	}

}
