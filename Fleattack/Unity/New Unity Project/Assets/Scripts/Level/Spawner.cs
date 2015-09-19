using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Flea;

	public int MaxFleaCounter = 3;
	public int FleaCounter = 0;
	
	void Start () {
	
	}

	void Update(){
		if (FleaCounter < MaxFleaCounter) {
			Instantiate (Flea, new Vector2 (Random.Range(-5F, 5F), 0), Quaternion.identity);
			FleaCounter++;
		}
	}

}
