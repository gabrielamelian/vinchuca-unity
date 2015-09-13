using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Flea;
	
	void Start () {
	//	StartCoroutine(SpawnFlea());
	}
	

	IEnumerator SpawnFlea () {
		for (var i = 0; i < 10; i++) {
			Instantiate (Flea, new Vector2 (Random.Range(-5F, 5F), 0), Quaternion.identity);
			yield return new WaitForSeconds(2);
		}
	}		

	void Update(){
		Instantiate (Flea, new Vector2 (Random.Range(-5F, 5F), 0), Quaternion.identity);
	}

}
