using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {

	public int ScoreValue;

	private GameObject Main;
	private Spawner spawner;
	private ScoreManager score;

	void Start () {
		Main = GameObject.FindGameObjectWithTag ("Main");
		spawner = Main.GetComponent<Spawner>();
		score = Main.GetComponent<ScoreManager> ();
	}

	void OnMouseDown() {
		score.AddScore (ScoreValue);
		KillFlea ();
	}

	void Update()
	{			
		if (gameObject.transform.position.y < -1f) {
			KillFlea();
		}
	}

	void KillFlea() {
		Destroy(gameObject);
		spawner.FleaCounter--;
	}
	
}
