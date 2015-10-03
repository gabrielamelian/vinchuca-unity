using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {

	public int ScoreValue;
	public int FleaDamage;

	private GameObject Main;

	private Spawner spawner;
	private ScoreManager score;
	private CatHealth health;

	void Start () {
		Main = GameObject.FindGameObjectWithTag ("Main");
		spawner = Main.GetComponent<Spawner>();
		score = Main.GetComponent<ScoreManager> ();
		health = Main.GetComponent<CatHealth> ();
	}

	void OnMouseDown() {
		score.AddScore (ScoreValue);
		KillFlea ();
	}

	void Update()
	{			
		if (gameObject.transform.position.y < -1f) {
			KillFlea();
			health.ReceiveDamage(FleaDamage);
		}
	}

	void KillFlea() {
		Destroy(gameObject);
		spawner.FleaCounter--;
	}
	
}
